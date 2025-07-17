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

        public QueueInfor GetLastCalledQueueInfor(int counterId, string query = "call proc_getlastqueueinfo({0})")
        {
            query = string.Format(query, counterId);
            return GetQueueInforByQuery(query);
        }

        public List<QueueInfor> GetAllQueue(string query = "call proc_getallqueue()")
        {
            return GetAllQueueInforByQuery(query);
        }

        public List<QueueInfor> GetAllQueue(int serviceId, string query = "call proc_getallqueuebyservice({0})")
        {
            query = string.Format(query, serviceId);
            return GetAllQueueInforByQuery(query);
        }

        public int CountRemainInQueue(int counterId)
        {
            try
            {
                string query = $"proc_countremaininqueuebycounterid({counterId})";
                return Convert.ToInt32(sqlHelper.ExecuteScalarQuery(query));
            }
            catch { return 0; }
        }

        public int CountRemainInQueue()
        {
            try
            {
                string query = $"call proc_countremaininqueue()";
                return Convert.ToInt32(sqlHelper.ExecuteScalarQuery(query));
            }
            catch { return 0; }
        }
    }
}
