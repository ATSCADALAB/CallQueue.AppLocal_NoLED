using System;
using System.Windows.Forms;

namespace CallQueue.AppLocal
{
    public partial class frmSelectPiorityNumber : DevExpress.XtraEditors.XtraForm
    {
        public int PiorityNumber { get; set; }

        public frmSelectPiorityNumber()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            PiorityNumber = Convert.ToInt32(spinEdit1.EditValue);
        }
    }
}
