using CallQueue.Core;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallQueue.AppLocal
{
    public partial class frmSelectCounter : DevExpress.XtraEditors.XtraForm
    {
        public object SelectedValue { get; set; }
        public frmSelectCounter(List<Counter> counters, object SelectValue)
        {
            InitializeComponent();

            lueCounter.Properties.DataSource = counters;
            lueCounter.Properties.DisplayMember = "Name";
            lueCounter.Properties.ValueMember = "Id";
            lueCounter.Properties.ShowFooter = false;
            lueCounter.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            lueCounter.Properties.ShowHeader = false;
            lueCounter.EditValue = SelectValue;
            //lueCounter.Properties.PopulateColumns();
            //foreach (LookUpColumnInfo col in lueCounter.Properties.Columns)
            //{
            //    if (col.FieldName != "Name")
            //        col.Visible = false;
            //}
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SelectedValue = lueCounter.EditValue;
            this.Close();
        }
    }
}
