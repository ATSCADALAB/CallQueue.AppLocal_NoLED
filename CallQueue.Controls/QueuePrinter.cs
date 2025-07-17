using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Xml;

namespace CallQueue.Controls
{
    public partial class QueuePrinter : Component
    {
        #region Public members

        public string ConnectionString { get; set; }
        public string Query { get; set; }
        public string ReportPath { get; set; }
        public bool IsPrinting { get; set; }

        #endregion

        #region Private members


        #endregion

        #region Constructors

        public QueuePrinter()
        {
            InitializeComponent();
        }

        public QueuePrinter(IContainer container) : base()
        {
            container.Add(this);
        }

        #endregion

        #region Public methods

        public void ReloadReport()
        {
            using (MySqlConnection con = new MySqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query;
                    cmd.Connection = con;
                    using (MySqlDataAdapter adp = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string reportXml = dt.Rows[0][0].ToString();
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(reportXml);
                            using (MemoryStream ms = new MemoryStream())
                            {
                                doc.Save(ms);
                                //report = XtraReport.FromXmlStream(ms);
                                //report.RequestParameters = false;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Private methods

        #endregion

    }
}
