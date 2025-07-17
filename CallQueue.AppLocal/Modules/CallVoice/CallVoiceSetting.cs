using CallQueue.Controls;
using CallQueue.Core;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CallQueue.AppLocal
{
    public partial class CallVoiceSetting : UserControl
    {
        Point p = Point.Empty;
        VoiceManager voiceManager;
        VoiceParameter VoiceParameter { get; set; }
        CallVoice MainCallVoice { get; set; }

        public CallVoiceSetting(CallVoice callVoice, VoiceManager voiceManager)
        {
            InitializeComponent();
            MainCallVoice = callVoice;
            this.voiceManager = voiceManager;
            VoiceParameter = voiceManager.GetVoiceParameter();

            ckbAllowPlayStartSound.Checked = callVoice.AllowPlayStartSound;
            ckbEnable.Checked = callVoice.Enabled;
            txbContent.Text = VoiceParameter.CallVoiceContent;
            
            lsbVoiceName.DataSource = new List<VoiceItem>(callVoice1.VoiceNames.Select(x => new VoiceItem() { Name = x }));
            lsbVoiceName.DataSource = callVoice1.VoiceNames;

            searchVoiceNames.Client = lsbVoiceName;
            lsbVoiceName.MouseDown += lsbVoiceName_MouseDown;
            lsbVoiceName.MouseMove += lsbVoiceName_MouseMove;
            lsbVoiceName.ContextButtonClick += LsbVoiceName_ContextButtonClick;
            txbContent.DragDrop += txbContent_DragDrop;
            txbContent.DragOver += txbContent_DragOver;
        }

        private void LsbVoiceName_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {
            if (!callVoice1.IsPlaying)
            {
                callVoice1.Content = e.DataItem.ToString();
                callVoice1.PlayAsync();
            }
        }

        private void lsbVoiceName_MouseDown(object sender, MouseEventArgs e)
        {
            ListBoxControl c = sender as ListBoxControl;
            p = new Point(e.X, e.Y);
            int selectedIndex = c.IndexFromPoint(p);
            if (selectedIndex == -1)
                p = Point.Empty;
        }

        private void lsbVoiceName_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if ((p != Point.Empty) && ((Math.Abs(e.X - p.X) > SystemInformation.DragSize.Width) || (Math.Abs(e.Y - p.Y) > SystemInformation.DragSize.Height)))
                    lsbVoiceName.DoDragDrop(sender, DragDropEffects.Move);
        }

        private void txbContent_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void txbContent_DragDrop(object sender, DragEventArgs e)
        {
            txbContent.Text += lsbVoiceName.SelectedItem.ToString();
            txbContent.Text = txbContent.Text.Trim();
        }

        private void btnRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txbContent.Text = MainCallVoice.Content;
            ckbAllowPlayStartSound.Checked = MainCallVoice.AllowPlayStartSound;
            ckbAllowPlayStartSound.Checked = MainCallVoice.Enabled;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                VoiceParameter.Enabled = ckbEnable.Checked;
                VoiceParameter.AllowPlayStartSound = ckbAllowPlayStartSound.Checked;
                VoiceParameter.CallVoiceContent = txbContent.Text?.Trim();
                if (voiceManager.SetVoiceParameter(VoiceParameter) == 0)
                {
                    Utils.ShowExclamation("Cập nhật dữ liệu thất bại !");
                    return;
                }
                MainCallVoice.Enabled = VoiceParameter.Enabled;
                MainCallVoice.AllowPlayStartSound = VoiceParameter.AllowPlayStartSound;
                Utils.ShowInformation("Đã cập nhật thành công !");                
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }
    }

    public class VoiceItem
    {
        public string Name { get; set; }
    }
}
