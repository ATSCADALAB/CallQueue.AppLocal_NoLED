using DevExpress.XtraReports.UI;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace CallQueue.AppLocal
{
    public partial class frmReportOrderSetting : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmReportOrderSetting()
        {
            InitializeComponent();
            Load += FrmReportOrderSetting_Load;
        }

        private void FrmReportOrderSetting_Load(object sender, EventArgs e)
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\rptOrder.repx";
            reportDesigner1.OpenReport(filePath);
        }
    }
}
