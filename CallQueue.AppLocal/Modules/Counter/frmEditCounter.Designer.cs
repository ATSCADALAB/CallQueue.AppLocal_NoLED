namespace CallQueue.AppLocal
{
    partial class frmEditCounter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraBars.BarShortcut barShortcut1 = new DevExpress.XtraBars.BarShortcut();
            DevExpress.XtraBars.BarShortcut barShortcut2 = new DevExpress.XtraBars.BarShortcut();
            DevExpress.XtraBars.BarShortcut barShortcut3 = new DevExpress.XtraBars.BarShortcut();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditCounter));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnClearAllServices = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelectAllService = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.clbServices = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.txbId = new DevExpress.XtraEditors.TextEdit();
            this.txbName = new DevExpress.XtraEditors.TextEdit();
            this.cobVoice = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clbServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobVoice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnSave,
            this.btnSaveAndClose,
            this.btnRestore,
            this.btnClose,
            this.btnClearAllServices,
            this.btnSelectAllService});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 10;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(800, 156);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 1;
            this.btnSave.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.save_16x161;
            this.btnSave.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.save_32x321;
            this.btnSave.ItemShortcut = barShortcut1;
            this.btnSave.Name = "btnSave";
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Caption = "Lưu Và Thoát";
            this.btnSaveAndClose.Id = 4;
            this.btnSaveAndClose.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.saveandclose_16x16;
            this.btnSaveAndClose.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.saveandclose_32x32;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            // 
            // btnRestore
            // 
            this.btnRestore.Caption = "Phục hồi";
            this.btnRestore.Id = 5;
            this.btnRestore.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.reset2_16x161;
            this.btnRestore.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.reset2_32x321;
            this.btnRestore.ItemShortcut = barShortcut2;
            this.btnRestore.Name = "btnRestore";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Thoát";
            this.btnClose.Id = 6;
            this.btnClose.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.close_16x16;
            this.btnClose.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.close_32x32;
            this.btnClose.ItemShortcut = barShortcut3;
            this.btnClose.Name = "btnClose";
            // 
            // btnClearAllServices
            // 
            this.btnClearAllServices.Caption = "Bỏ chọn tất cả dịch vụ";
            this.btnClearAllServices.Id = 8;
            this.btnClearAllServices.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.clearall_16x16;
            this.btnClearAllServices.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.clearall_32x32;
            this.btnClearAllServices.Name = "btnClearAllServices";
            // 
            // btnSelectAllService
            // 
            this.btnSelectAllService.Caption = "Chọn tất cả dịch vụ";
            this.btnSelectAllService.Id = 9;
            this.btnSelectAllService.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.checkbox2_16x16;
            this.btnSelectAllService.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.checkbox2_32x32;
            this.btnSelectAllService.Name = "btnSelectAllService";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Action";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.layoutControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 294);
            this.panel1.TabIndex = 11;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.clbServices);
            this.layoutControl1.Controls.Add(this.txbId);
            this.layoutControl1.Controls.Add(this.txbName);
            this.layoutControl1.Controls.Add(this.cobVoice);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 289, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 294);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // clbServices
            // 
            this.clbServices.CheckMode = DevExpress.XtraEditors.CheckMode.Single;
            this.clbServices.CheckOnClick = true;
            this.clbServices.Location = new System.Drawing.Point(12, 52);
            this.clbServices.Name = "clbServices";
            this.clbServices.Size = new System.Drawing.Size(776, 230);
            this.clbServices.StyleController = this.layoutControl1;
            this.clbServices.TabIndex = 8;
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(91, 12);
            this.txbId.MenuManager = this.ribbonControl1;
            this.txbId.Name = "txbId";
            // 
            // 
            // 
            this.txbId.Properties.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(90, 20);
            this.txbId.StyleController = this.layoutControl1;
            this.txbId.TabIndex = 4;
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(264, 12);
            this.txbName.MenuManager = this.ribbonControl1;
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(235, 20);
            this.txbName.StyleController = this.layoutControl1;
            this.txbName.TabIndex = 5;
            // 
            // cobVoice
            // 
            this.cobVoice.EditValue = "0";
            this.cobVoice.Location = new System.Drawing.Point(582, 12);
            this.cobVoice.MenuManager = this.ribbonControl1;
            this.cobVoice.Name = "cobVoice";
            // 
            // 
            // 
            this.cobVoice.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cobVoice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobVoice.Properties.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cobVoice.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cobVoice.Size = new System.Drawing.Size(206, 20);
            this.cobVoice.StyleController = this.layoutControl1;
            this.cobVoice.TabIndex = 9;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 294);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txbId;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(173, 24);
            this.layoutControlItem1.Text = "Mã";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(76, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.clbServices;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(780, 250);
            this.layoutControlItem5.Text = "Dịch vụ";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(76, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cobVoice;
            this.layoutControlItem3.Location = new System.Drawing.Point(491, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(289, 24);
            this.layoutControlItem3.Text = "Âm nhận dạng";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(76, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txbName;
            this.layoutControlItem2.Location = new System.Drawing.Point(173, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(318, 24);
            this.layoutControlItem2.Text = "Tên quầy";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(76, 13);
            // 
            // frmEditCounter
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditCounter";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clbServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobVoice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnRestore;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txbId;
        private DevExpress.XtraEditors.TextEdit txbName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckedListBoxControl clbServices;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraBars.BarButtonItem btnClearAllServices;
        private DevExpress.XtraBars.BarButtonItem btnSelectAllService;
        private DevExpress.XtraEditors.ComboBoxEdit cobVoice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}