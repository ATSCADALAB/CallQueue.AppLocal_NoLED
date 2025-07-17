using CallQueue.Core;
using System.Windows.Forms;

namespace CallQueue.AppLocal
{
    public partial class CounterDashboard : UserControl
    {
        Counter counter;
        UnitOfWork unitOfWork;

        public CounterDashboard()
        {
            InitializeComponent();
        }

        public CounterDashboard(Counter counter, UnitOfWork unitOfWork) 
        {
            InitializeComponent();

            this.unitOfWork = unitOfWork;
            this.counter = counter;

            groupCounter.Text = counter.Name;
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
                    unitOfWork.SQLHelper.ExecuteNonQuery($"update counter set LCDDisplay = '0000' where Id = {queueInfor.CounterId}");
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
