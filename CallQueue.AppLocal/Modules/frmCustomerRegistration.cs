using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CallQueue.AppLocal.Modules
{
    public partial class frmCustomerRegistration : XtraForm
    {
        public string CustomerName { get; private set; }
        public int ServiceId { get; private set; } = 1; // Mặc định service 1

        public frmCustomerRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            CustomerName = txtCustomerName.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập chữ cái, số và khoảng trắng
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void frmCustomerRegistration_Load(object sender, EventArgs e)
        {
            txtCustomerName.Focus();
        }
    }
}