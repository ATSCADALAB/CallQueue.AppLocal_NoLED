using SQLHelper;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System;
using Raspberry.IO.GeneralPurpose;
using System.Linq;

namespace CallQueue.Core
{
    public class PrinterManager
    {
        ISQLHelper sqlHelper;

        public PrinterManager(ISQLHelper sqlHelper)
        {
            this.sqlHelper = sqlHelper;
        }

        public List<Line> GetAllLines(string query = "select * from common")
        {
            List<Line> lines = new List<Line>();
            DataTable dt = new DataTable();
            dt = sqlHelper.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                string linesJsonString = dt.Rows[0]["Lines"].ToString();
                lines = JsonConvert.DeserializeObject<List<Line>>(linesJsonString);
            }
            return lines;
        }

        public int UpdateLines(List<Line> lines, string query = "update common set `Lines` = @param1")
        {
            string linesJsonString = JsonConvert.SerializeObject(lines);
            return sqlHelper.ExecuteNonQuery(query, linesJsonString);
        }

        public List<Service> GetAllServices(string query = "select * from service")
        {
            List<Service> services = new List<Service>();
            DataTable dt = sqlHelper.ExecuteQuery(query);
            if (dt != null)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    Service service = new Service()
                    {
                        Id = int.Parse(dtRow["Id"].ToString()),
                        Name = dtRow["Name"].ToString(),
                        Description = dtRow["Description"].ToString(),
                        CurrentNumber = int.Parse(dtRow["CurrentNumber"].ToString()),
                        PrintedNumber = int.Parse(dtRow["PrintedNumber"].ToString()),
                        PiorityLevel = int.Parse(dtRow["PiorityLevel"].ToString()),
                        TotalUseCount = int.Parse(dtRow["TotalUseCount"].ToString()),
                        UseCountOfDay = int.Parse(dtRow["UseCountOfDay"].ToString()),
                        UseCountOfWeek = int.Parse(dtRow["UseCountOfWeek"].ToString()),
                        UseCountOfMonth = int.Parse(dtRow["UseCountOfMonth"].ToString()),
                        UseCountOfYear = int.Parse(dtRow["UseCountOfYear"].ToString()),
                        Mark = dtRow["Mark"].ToString(),
                        InputPin = int.Parse(dtRow["InputPin"].ToString()),
                    };
                    services.Add(service);
                }
            }
            return services;
        }

        public int GetResetInputPin(string query = "select * from common")
        {
            int pin = -1;
            DataTable dt = sqlHelper.ExecuteQuery(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                pin = int.Parse(dt.Rows[0]["ResetInputPin"].ToString());
            }
            return pin;
        }

        public int GetSirenInputPin(string query = "select * from common")
        {
            int pin = -1;
            DataTable dt = sqlHelper.ExecuteQuery(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                pin = int.Parse(dt.Rows[0]["SirenInputPin"].ToString());
            }
            return pin;
        }

        public string GetNumberFormat(string query = "select * from common")
        {
            string result = "";
            DataTable dt = sqlHelper.ExecuteQuery(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["NumberFormat"].ToString();
            }
            return result;
        }

        public PrintParameter GetNextPrintParameter(int serviceId, string query = "call proc_printnumber({0})")
        {
            PrintParameter printParameter = new PrintParameter();

            try
            {
                query = string.Format(query, serviceId);
                DataTable dt = sqlHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        printParameter.CurrentTime = Convert.ToDateTime(dtRow[0].ToString());
                        if (int.TryParse(dtRow[1].ToString(), out int nextNumber))
                            printParameter.NextNumber = nextNumber;
                        if (int.TryParse(dtRow[2].ToString(), out int sId))
                            printParameter.ServiceId = sId;
                        printParameter.Mask = dtRow[3].ToString();
                        printParameter.ServiceName = dtRow[4].ToString();
                        break;
                    }
                }
            }
            catch { }

            return printParameter;
        }

        public int Reset()
        {
            return sqlHelper.ExecuteNonQuery("call proc_reset()");
        }
        public int Reset_1(int counterId)
        {
            try
            {
                // Gọi stored procedure proc_reset_now để reset toàn bộ hệ thống
                var query = "CALL proc_reset_now()";
                sqlHelper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                var a = 1;
            }
            return 1;
        }

        public static List<ConnectorPin> GetConnectorPins()
        {
            return Enum.GetValues(typeof(ConnectorPin)).Cast<ConnectorPin>().ToList();
        }
    }
}
