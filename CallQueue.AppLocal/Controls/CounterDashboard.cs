//using CallQueue.Core;
//using System.Windows.Forms;

//namespace CallQueue.AppLocal
//{
//    public partial class CounterDashboard : UserControl
//    {
//        Counter counter;
//        UnitOfWork unitOfWork;

//        public CounterDashboard()
//        {
//            InitializeComponent();
//        }

//        public CounterDashboard(Counter counter, UnitOfWork unitOfWork) 
//        {
//            InitializeComponent();

//            this.unitOfWork = unitOfWork;
//            this.counter = counter;

//            groupCounter.Text = counter.Name;
//        }


//        public void UpdateDashboard(QueueInfor queueInfor)
//        {
//            if (queueInfor != null)
//            {
//                string displaynumber = GetDisplayNumber(queueInfor);
//                if (lbCurrentNumber.Text != displaynumber)
//                {
//                    unitOfWork.SQLHelper.ExecuteNonQuery($"update counter set LCDDisplay = '{displaynumber}' where Id = {queueInfor.CounterId}");
//                    lbCurrentNumber.SetCrossThread(x => x.Text = displaynumber);
//                }
//            }
//            else if (queueInfor == null || queueInfor.CounterId != counter.Id)
//            {
//                if (lbCurrentNumber.Text != "0000")
//                {
//                    unitOfWork.SQLHelper.ExecuteNonQuery($"update counter set LCDDisplay = '0000' where Id = {queueInfor.CounterId}");
//                    lbCurrentNumber.SetCrossThread(x => x.Text = "0000");
//                }
//            }
//        }

//        public void UpdateDashboard(int counterId, string displayNumber)
//        {
//            if (counterId > 0 && counterId == counter.Id)
//            {
//                if (lbCurrentNumber.Text != displayNumber)
//                {
//                    unitOfWork.SQLHelper.ExecuteNonQuery($"update counter set LCDDisplay = '{displayNumber}' where Id = {counterId}");
//                    lbCurrentNumber.SetCrossThread(x => x.Text = displayNumber);
//                }
//            }
//        }

//        public string GetDisplayNumber(QueueInfor queue)
//        {
//            string number = queue.Number.ToString();
//            if (!string.IsNullOrEmpty(queue.NumberFormat))
//                number = queue.Number.ToString(queue.NumberFormat);
//            number = number.Insert(0, queue.Mark);
//            return number;
//        }
//        public string GetDisplayNumber(int number, string numberFormat, string mark)
//        {
//            string numberstr = number.ToString();
//            if (!string.IsNullOrEmpty(numberFormat))
//                numberstr = number.ToString(numberFormat);
//            numberstr = numberstr.Insert(0, mark);
//            return numberstr;
//        }
//    }
//}
using CallQueue.Core;
using System.Drawing;
using System.Windows.Forms;

namespace CallQueue.AppLocal
{
    public partial class CounterDashboard : UserControl
    {
        Counter counter;
        UnitOfWork unitOfWork;
        private string currentRoomStatus = "unknown";

        // Label để hiển thị trạng thái
        private Label lbRoomStatus;

        public CounterDashboard()
        {
            InitializeComponent();
            InitializeRoomStatus();
        }

        public CounterDashboard(Counter counter, UnitOfWork unitOfWork)
        {
            InitializeComponent();
            this.unitOfWork = unitOfWork;
            this.counter = counter;
            groupCounter.Text = counter.Name;
            InitializeRoomStatus();
        }

        // Khởi tạo label trạng thái phòng
        private void InitializeRoomStatus()
        {
            // Tạo label trạng thái
            lbRoomStatus = new Label();
            lbRoomStatus.Dock = DockStyle.Bottom;
            lbRoomStatus.Height = 30;
            lbRoomStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbRoomStatus.TextAlign = ContentAlignment.MiddleCenter;
            lbRoomStatus.Text = "KHÔNG RÕ";
            lbRoomStatus.BackColor = Color.LightGray;
            lbRoomStatus.ForeColor = Color.DarkGray;

            // Thêm vào GroupControl
            groupCounter.Controls.Add(lbRoomStatus);

            // Điều chỉnh lại height của số hiện tại
            lbCurrentNumber.Height = 70;
        }

        // Property để lấy Counter ID
        public int CounterId
        {
            get { return counter != null ? counter.Id : 0; }
        }

        // Update trạng thái phòng
        public void UpdateRoomStatus(string status)
        {
            if (currentRoomStatus == status) return;

            currentRoomStatus = status;

            // Update UI trên UI thread
            if (this.InvokeRequired)
            {
                this.Invoke(new System.Action(() => UpdateRoomStatusUI(status)));
            }
            else
            {
                UpdateRoomStatusUI(status);
            }
        }

        private void UpdateRoomStatusUI(string status)
        {
            switch (status.ToLower())
            {
                case "available":
                    lbRoomStatus.Text = "PHÒNG TRỐNG";
                    lbRoomStatus.BackColor = Color.FromArgb(76, 175, 80); // Green
                    lbRoomStatus.ForeColor = Color.White;

                    // Thêm border xanh cho toàn bộ control
                    groupCounter.Appearance.BorderColor = Color.FromArgb(76, 175, 80);
                    groupCounter.Appearance.Options.UseBorderColor = true;
                    groupCounter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    break;

                case "busy":
                    lbRoomStatus.Text = "ĐANG BẬN";
                    lbRoomStatus.BackColor = Color.FromArgb(244, 67, 54); // Red
                    lbRoomStatus.ForeColor = Color.White;

                    // Thêm border đỏ
                    groupCounter.Appearance.BorderColor = Color.FromArgb(244, 67, 54);
                    groupCounter.Appearance.Options.UseBorderColor = true;
                    groupCounter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    break;

                default:
                    lbRoomStatus.Text = "KHÔNG RÕ";
                    lbRoomStatus.BackColor = Color.LightGray;
                    lbRoomStatus.ForeColor = Color.DarkGray;

                    // Border mặc định
                    groupCounter.Appearance.Options.UseBorderColor = false;
                    groupCounter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    break;
            }
        }

        public void UpdateDashboard(QueueInfor queueInfor)
        {
            if (queueInfor != null)
            {
                string displaynumber = GetDisplayNumber(queueInfor);
                if (lbCurrentNumber.Text != displaynumber)
                {
                    unitOfWork.SQLHelper.ExecuteNonQuery($"update counter set LCDDisplay = '{displaynumber}' where Id = {queueInfor.CounterId}");
                    lbCurrentNumber.SetCrossThread(x => x.Text = displaynumber);
                }
            }
            else if (queueInfor == null || queueInfor.CounterId != counter.Id)
            {
                if (lbCurrentNumber.Text != "0000")
                {
                    unitOfWork.SQLHelper.ExecuteNonQuery($"update counter set LCDDisplay = '0000' where Id = {counter.Id}");
                    lbCurrentNumber.SetCrossThread(x => x.Text = "0000");
                }
            }
        }

        public void UpdateDashboard(int counterId, string displayNumber)
        {
            if (counterId > 0 && counterId == counter.Id)
            {
                if (lbCurrentNumber.Text != displayNumber)
                {
                    unitOfWork.SQLHelper.ExecuteNonQuery($"update counter set LCDDisplay = '{displayNumber}' where Id = {counterId}");
                    lbCurrentNumber.SetCrossThread(x => x.Text = displayNumber);
                }
            }
        }

        public string GetDisplayNumber(QueueInfor queue)
        {
            string number = queue.Number.ToString();
            if (!string.IsNullOrEmpty(queue.NumberFormat))
                number = queue.Number.ToString(queue.NumberFormat);
            number = number.Insert(0, queue.Mark);
            return number;
        }

        public string GetDisplayNumber(int number, string numberFormat, string mark)
        {
            string numberstr = number.ToString();
            if (!string.IsNullOrEmpty(numberFormat))
                numberstr = number.ToString(numberFormat);
            numberstr = numberstr.Insert(0, mark);
            return numberstr;
        }
    }
}