using CallQueue.Core;
using System.Windows.Forms;

namespace CallQueue.AppLocal
{
    public partial class ServiceDashboard : UserControl
    {
        Service service;

        public ServiceDashboard()
        {
            InitializeComponent();
        }

        public ServiceDashboard(Service service)
        {
            InitializeComponent();
            this.service = service;
            groupService.Text = service.Name;
        }

        public void UpdateDashboard(Service service, string numberFormat)
        {
            if (service != null && service.Id == this.service.Id)
            {
                if (groupService.Text != service.Name)
                    groupService.SetCrossThread(x => x.Text = service.Name);
                string printedNumber = GetPrintedNumber(service, numberFormat);
                if (lbSoDaIn.Text != printedNumber)
                    lbSoDaIn.SetCrossThread(x => x.Text = printedNumber);
                string currentNumber = GetCurrentNumberNumber(service, numberFormat);
                if (lbSoDangXuLy.Text != currentNumber)
                    lbSoDangXuLy.SetCrossThread(x => x.Text = GetCurrentNumberNumber(service, numberFormat));
                string remain = (service.PrintedNumber - service.CurrentNumber).ToString();
                if (lbRemainService.Text != remain)
                    lbRemainService.SetCrossThread(x => x.Text = remain);
            }
        }

        public string GetCurrentNumberNumber(Service currentService, string numberFomat)
        {
            string number = currentService.CurrentNumber.ToString();
            if (!string.IsNullOrEmpty(numberFomat))
                number = currentService.CurrentNumber.ToString(numberFomat);
            number = number.Insert(0, currentService.Mark);
            return number;
        }

        public string GetPrintedNumber(Service currentService, string numberFomat)
        {
            string number = currentService.PrintedNumber.ToString();
            if (!string.IsNullOrEmpty(numberFomat))
                number = currentService.PrintedNumber.ToString(numberFomat);
            number = number.Insert(0, currentService.Mark);
            return number;
        }

    }
}
