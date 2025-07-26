using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace CallQueue.Core
{
    public class QueueManager
    {
        ISQLHelper sqlHelper;

        public QueueManager(ISQLHelper sqlHelper)
        {
            this.sqlHelper = sqlHelper;
        }

        public static string GetDisplayNumber(QueueInfor queue)
        {
            string number = queue.Number.ToString();
            if (!string.IsNullOrEmpty(queue.NumberFormat))
                number = queue.Number.ToString(queue.NumberFormat);
            number = number.Insert(0, queue.Mark);
            return number;
        }

        private QueueInfor GetQueueInforByQuery(string query)
        {
            QueueInfor queueInfor = new QueueInfor();

            try
            {
                DataTable dt = sqlHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                    return dt.Rows[0].ToObject<QueueInfor>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return queueInfor;
        }

        private List<QueueInfor> GetAllQueueInforByQuery(string query)
        {
            try
            {
                DataTable dt = sqlHelper.ExecuteQuery(query);
                return dt.ToObjects<QueueInfor>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return new List<QueueInfor>();
        }

        public QueueInfor CallNext(int counterId, string query = "call proc_callnext({0})")
        {
            query = string.Format(query, counterId);
            return GetQueueInforByQuery(query);
        }

        public bool CanCallNext(int counterId, out QueueInfor queueInfor)
        {
            queueInfor = CallNext(counterId);
            return queueInfor.Id != 0;
        }

        public QueueInfor CallPrevious(int counterId, int number, string query = "call proc_callprevious({0}, {1})")
        {
            query = string.Format(query, counterId, number);
            return GetQueueInforByQuery(query);
        }

        public bool CanCallPrevious(int counterId, int number, out QueueInfor queueInfor)
        {
            queueInfor = CallPrevious(counterId, number);
            return queueInfor.Id != 0;
        }

        public QueueInfor CallPiority(int counterId, int number, string query = "call proc_callpiority({0}, {1})")
        {
            query = string.Format(query, counterId, number);
            return GetQueueInforByQuery(query);
        }

        public bool CanCallPiority(int counterId, int number, out QueueInfor queueInfor)
        {
            queueInfor = CallPiority(counterId, number);
            return queueInfor.Id != 0;
        }

        public QueueInfor GetLastCalledQueueInfor(int counterId, string query = "call proc_getlastcalledqueue({0})")
        {
            query = string.Format(query, counterId);
            return GetQueueInforByQuery(query);
        }

        public List<QueueInfor> GetWaitingQueueList(int counterId, string query = "call proc_getwaitingqueue({0})")
        {
            query = string.Format(query, counterId);
            return GetAllQueueInforByQuery(query);
        }

        // ============= THÊM CÁC METHOD MỚI =============

        /// <summary>
        /// Kết quả đăng ký khách hàng
        /// </summary>
        public class CustomerRegistrationResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public int QueueNumber { get; set; }
            public string CustomerName { get; set; }
        }

        /// <summary>
        /// Đăng ký khách hàng vào hàng chờ
        /// </summary>
        /// <param name="customerName">Tên khách hàng</param>
        /// <param name="serviceId">ID dịch vụ (mặc định = 1)</param>
        /// <returns>Kết quả đăng ký</returns>
        public CustomerRegistrationResult RegisterCustomer(string customerName, int serviceId = 1)
        {
            var result = new CustomerRegistrationResult();

            try
            {
                if (string.IsNullOrWhiteSpace(customerName))
                {
                    result.Success = false;
                    result.Message = "Tên khách hàng không được để trống!";
                    return result;
                }

                // Lấy số thứ tự tiếp theo
                int nextNumber = GetNextQueueNumber(serviceId);

                if (nextNumber <= 0)
                {
                    result.Success = false;
                    result.Message = "Không thể tạo số thứ tự mới!";
                    return result;
                }

                // Escape tên khách hàng để tránh SQL injection
                string escapedCustomerName = customerName.Trim().Replace("'", "''");
                DateTime now = DateTime.Now;

                // Insert vào queue
                string insertQueueQuery = $@"
                    INSERT INTO queue (DateTime, ServiceId, Number, customername) 
                    VALUES ('{now:yyyy-MM-dd HH:mm:ss}', {serviceId}, {nextNumber}, '{escapedCustomerName}')";

                // Insert vào callhistory
                string insertHistoryQuery = $@"
                    INSERT INTO callhistory (PrintTime, ServiceId, PrintedNumber, customername, CallTime, CounterId) 
                    VALUES ('{now:yyyy-MM-dd HH:mm:ss}', {serviceId}, {nextNumber}, '{escapedCustomerName}', NULL, NULL)";

                // Cập nhật service
                string updateServiceQuery = $@"
                    UPDATE service 
                    SET PrintedNumber = {nextNumber}, 
                        UseCountOfDay = UseCountOfDay + 1,
                        UseCountOfWeek = UseCountOfWeek + 1,
                        UseCountOfMonth = UseCountOfMonth + 1,
                        UseCountOfYear = UseCountOfYear + 1
                    WHERE Id = {serviceId}";

                // Thực hiện các query
                sqlHelper.ExecuteNonQuery(insertQueueQuery);
                sqlHelper.ExecuteNonQuery(insertHistoryQuery);
                sqlHelper.ExecuteNonQuery(updateServiceQuery);

                result.Success = true;
                result.Message = "Đăng ký thành công!";
                result.QueueNumber = nextNumber;
                result.CustomerName = customerName.Trim();

                Debug.WriteLine($"✅ Đăng ký thành công: {customerName} - Số {nextNumber}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Lỗi đăng ký: {ex.Message}";
                Debug.WriteLine($"❌ Lỗi đăng ký khách hàng: {ex}");
            }

            return result;
        }

        /// <summary>
        /// Lấy số thứ tự tiếp theo cho service
        /// </summary>
        private int GetNextQueueNumber(int serviceId)
        {
            try
            {
                string query = $"SELECT PrintedNumber FROM service WHERE Id = {serviceId}";

                DataTable dt = sqlHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    var result = dt.Rows[0]["PrintedNumber"];
                    if (result != null && int.TryParse(result.ToString(), out int currentNumber))
                    {
                        return currentNumber + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Lỗi lấy số thứ tự: {ex}");
            }

            return 0;
        }

        /// <summary>
        /// Lấy danh sách queue chờ với tên khách hàng
        /// </summary>
        /// <param name="serviceId">ID dịch vụ</param>
        /// <returns>Danh sách queue chờ</returns>
        public List<QueueInfor> GetQueueWithCustomerName(int serviceId = 1)
        {
            try
            {
                string query = $@"
           SELECT q.DateTime, 
                  COALESCE(q.customername, '') as CustomerName,
                  q.Number
           FROM queue q 
           WHERE q.ServiceId = {serviceId} 
           ORDER BY q.DateTime ASC";

                DataTable dt = sqlHelper.ExecuteQuery(query);
                var queueList = new List<QueueInfor>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var queue = new QueueInfor
                        {
                            DateTime = Convert.ToDateTime(row["DateTime"]),
                            CustomerName = row["CustomerName"]?.ToString() ?? "",
                            Number = Convert.ToInt32(row["Number"]),

                            // Các trường không có trong query set null
                            Id = 0,
                            ServiceId = 0,
                            Mark = null,
                            NumberFormat = null,
                            CallVoiceContent = null
                        };
                        queueList.Add(queue);
                    }
                }
                return queueList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Lỗi lấy danh sách queue: {ex}");
                return new List<QueueInfor>();
            }
        }
    }
}