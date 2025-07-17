using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CallQueue.Core;

namespace CallQueue.AppLocal
{
    public partial class ReportByTime : UserControl
    {
        UnitOfWork unitOfWork;

        public ReportByTime(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            this.unitOfWork = unitOfWork;
            this.Load += ReportByTime_Load;

        }

        private void ReportByTime_Load(object sender, EventArgs e)
        {
            dteFrom.DateTime = Convert.ToDateTime($"{DateTime.Now.ToString("yyyy-MM-dd 00:00:00")}");
            dteTo.DateTime = Convert.ToDateTime($"{DateTime.Now.ToString("yyyy-MM-dd 23:59:59")}");
            RefreshData(dteFrom.DateTime, dteTo.DateTime);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            RefreshData(dteFrom.DateTime, dteTo.DateTime);
        }

        private void RefreshData(DateTime from, DateTime to)
        {
            try
            {
                gridControl1.DataSource = null;
                // Get Number format
                DataTable dtCommon = unitOfWork.SQLHelper.ExecuteQuery("select * from common");
                if (dtCommon != null && dtCommon.Rows.Count > 0)
                {
                    string numberFormat = dtCommon.Rows[0]["NumberFormat"].ToString();
                    DataTable dt = unitOfWork.SQLHelper.ExecuteQuery($"call proc_getcallhistorybytime('{dteFrom.DateTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{dteTo.DateTime.ToString("yyyy-MM-dd HH:mm:ss")}')");
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        if (int.TryParse(dtRow["PrintedNumber"].ToString(), out int printedNumber))
                        {
                            dtRow["PrintedNumber"] = GetDisplayNumber(printedNumber, dtRow["Mark"].ToString(), numberFormat);
                        }
                    }
                    gridControl1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                RichTextBox rtb = new RichTextBox();
                rtb.AppendText("LỊCH SỬ GỌI SỐ \n\n");
                rtb.SelectAll();
                var headerFont = new Font(rtb.Font.FontFamily, 16, FontStyle.Bold);
                rtb.SelectionFont = headerFont;
                rtb.AppendText($"TỪ: {dteFrom.DateTime.ToString("yyyy-MM-dd HH:mm:ss")} - ĐẾN: {dteTo.DateTime.ToString("yyyy-MM-dd HH:mm:ss")}\n");
                rtb.SelectAll();
                rtb.SelectionAlignment = HorizontalAlignment.Center;
                gridView1.OptionsPrint.RtfReportHeader = rtb.Rtf;
                gridControl1.ShowRibbonPrintPreview();
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }

        public string GetDisplayNumber(int printedNumber, string mark, string numberFomat)
        {
            string number = printedNumber.ToString();
            if (!string.IsNullOrEmpty(numberFomat))
                number = printedNumber.ToString(numberFomat);
            number = number.Insert(0, mark);
            return number;
        }

        private void btnQuickPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                RichTextBox rtb = new RichTextBox();
                rtb.AppendText("LỊCH SỬ GỌI SỐ \n\n");
                rtb.SelectAll();
                var headerFont = new Font(rtb.Font.FontFamily, 16, FontStyle.Bold);
                rtb.SelectionFont = headerFont;
                rtb.AppendText($"TỪ: {dteFrom.DateTime.ToString("yyyy-MM-dd HH:mm:ss")} - ĐẾN: {dteTo.DateTime.ToString("yyyy-MM-dd HH:mm:ss")}\n");
                rtb.SelectAll();
                rtb.SelectionAlignment = HorizontalAlignment.Center;
                gridView1.OptionsPrint.RtfReportHeader = rtb.Rtf; gridControl1.Print();
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }

        private void btnExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Excel Files | *.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    RichTextBox rtb = new RichTextBox();
                    rtb.AppendText("LỊCH SỬ GỌI SỐ \n\n");
                    rtb.SelectAll();
                    var headerFont = new Font(rtb.Font.FontFamily, 16, FontStyle.Bold);
                    rtb.SelectionFont = headerFont;
                    rtb.AppendText($"TỪ: {dteFrom.DateTime.ToString("yyyy-MM-dd HH:mm:ss")} - ĐẾN: {dteTo.DateTime.ToString("yyyy-MM-dd HH:mm:ss")}\n");
                    rtb.SelectAll();
                    rtb.SelectionAlignment = HorizontalAlignment.Center;
                    gridView1.OptionsPrint.RtfReportHeader = rtb.Rtf; gridControl1.ExportToXlsx(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }

        private void btnExportToPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Pdf Files | *.pdf";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    RichTextBox rtb = new RichTextBox();
                    rtb.AppendText("LỊCH SỬ GỌI SỐ \n\n");
                    rtb.SelectAll();
                    var headerFont = new Font(rtb.Font.FontFamily, 16, FontStyle.Bold);
                    rtb.SelectionFont = headerFont;
                    rtb.AppendText($"TỪ: {dteFrom.DateTime.ToString("yyyy-MM-dd HH:mm:ss")} - ĐẾN: {dteTo.DateTime.ToString("yyyy-MM-dd HH:mm:ss")}\n");
                    rtb.SelectAll();
                    rtb.SelectionAlignment = HorizontalAlignment.Center;
                    gridView1.OptionsPrint.RtfReportHeader = rtb.Rtf; gridControl1.ExportToXlsx(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }

        private void btnShowFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowFilterEditor(gridColumn1);
        }
    }
}
