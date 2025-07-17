using CallQueue.Core;
using DevExpress.Mvvm;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
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
    public partial class frmCounterModbusConfig : RibbonForm
    {
        #region Public members

        public bool IsBusy { get; set; }

        #endregion

        #region Private members

        List<ModbusMasterParameter> modbusParameters;
        Counter counter;
        UnitOfWork unitOfWork;
        ModbusManager modbusManager;

        DelegateCommand saveAndCloseCommand;
        DelegateCommand restoreCommand;
        DelegateCommand closeCommand;

        #endregion

        #region Constructors

        public frmCounterModbusConfig(int counterId, ModbusManager modbusManager, UnitOfWork unitOfWork)
        {
            InitializeComponent();

            this.unitOfWork = unitOfWork;
            this.modbusManager = modbusManager;
            this.counter = unitOfWork.CounterRepository.GetByPrimaryKey(counterId);
            if (counter == null)
            {
                Utils.ShowErrorMessageBox("Không tìm thấy quầy để cấu hình truyền thống !");
                Close();
            }
            else
            {
                Text = $"Cấu hình truyền thông - {counter.Id}";
            }

            modbusParameters = modbusManager.GetAllModbusMasterParameters();

            FillProperties(counter);

            btnSave.ItemClick += BtnSave_ItemClick;
            saveAndCloseCommand = new DelegateCommand(SaveAndClose);
            restoreCommand = new DelegateCommand(Restore);
            closeCommand = new DelegateCommand(Exit);
            btnSaveAndClose.BindCommand(saveAndCloseCommand);
            btnRestore.BindCommand(restoreCommand);
            btnClose.BindCommand(closeCommand);

            lokModbusMasterKeyboard.Properties.DataSource = modbusParameters;
            lokModbusMasterKeyboard.Properties.DisplayMember = "Name";
            lokModbusMasterKeyboard.Properties.ValueMember = "Id";
            lokModbusMasterKeyboard.Properties.ShowFooter = true;
            lokModbusMasterKeyboard.EditValue = counter.MasterKeyBoardId;
            lokModbusMasterKeyboard.EditValueChanged += LokModbusMasterKeyboard_EditValueChanged;

            lokModbusMasterLed.Properties.DataSource = modbusParameters;
            lokModbusMasterKeyboard.Properties.DisplayMember = "Name";
            lokModbusMasterLed.Properties.ValueMember = "Id";
            lokModbusMasterLed.Properties.ShowFooter = true;
            lokModbusMasterLed.EditValue = counter.MasterDisplayLedId;
            lokModbusMasterLed.EditValueChanged += LokModbusMasterLed_EditValueChanged;
        }

        #endregion

        #region Private methods

        private bool Save()
        {
            int masterKeyboardId = lokModbusMasterKeyboard.EditValue == null ? 0 : int.Parse(lokModbusMasterKeyboard.EditValue.ToString());
            int masterLedId = lokModbusMasterLed.EditValue == null ? 0 : int.Parse(lokModbusMasterLed.EditValue.ToString());
            string query = $"update counter set MasterKeyBoardId = {masterKeyboardId}, KeyboardId = '{speDevicdeIdKeyboard.EditValue}', AddressCallCommand = '{speCallCommandAddress.EditValue}', " +
                $"AddressPiorityNumber = '{spePiorityAddress.EditValue}', AddressDisplayNumber = '{speDisplayNumberKeyboardAddress.EditValue}', " +
                $"AddressRemainNumber = '{speRemainAddress.EditValue}', MasterDisplayLedId = {masterLedId}, DisplayLedId = '{speDevicdeIdLed.EditValue}', AddressDisplayLedMode = '{speDisplayModeLedAddress.EditValue}', AddressDisplayLedNumber = '{speDisplayNumberLedAddress.EditValue}' where Id = {counter.Id}";
            if (unitOfWork.SQLHelper.ExecuteNonQuery(query) != 0)
                return true;
            return false;
        }

        private void BtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                Utils.ShowInformation("Đã lưu cấu hình modbus thành công !");
            }
            else
            {
                Utils.ShowErrorMessageBox("Lưu thông tin cấu hình thất bại !");
            }
        }


        private void Exit()
        {
            Close();
        }


        private void SaveAndClose()
        {
            if (Save())
                Exit();
            else
                Utils.ShowErrorMessageBox("Lưu thông tin cấu hình thất bại !");
        }

        private void Restore()
        {
            FillProperties(counter);
        }

        private void FillProperties(Counter counter)
        {
            if (counter == null)
            {
                txbId.ResetText();
                txbName.ResetText();
                lokModbusMasterKeyboard.EditValue = null;
                lokModbusMasterLed.EditValue = null;
                txbPortKeyboard.ResetText();
                txbBaudrateKeyboard.ResetText();
                txbDataBitsKeyboard.ResetText();
                txbParityKeyboard.ResetText();
                txbStopBitsKeyboard.ResetText();
                txbPortKeyboard.ResetText();
                txbBaudrateKeyboard.ResetText();
                txbDataBitsKeyboard.ResetText();
                txbParityKeyboard.ResetText();
                txbStopBitsKeyboard.ResetText();
                speCallCommandAddress.ResetText();
                speDevicdeIdKeyboard.ResetText();
                speDevicdeIdLed.ResetText();
                speDisplayModeLedAddress.ResetText();
                speDisplayNumberKeyboardAddress.ResetText();
                speDisplayNumberLedAddress.ResetText();
                spePiorityAddress.ResetText();
                speRemainAddress.ResetText();
            }
            else
            {
                txbId.Text = counter.Id.ToString();
                txbName.Text = counter.Name.ToString();
                FillModbusKeyboardProperties(counter.MasterKeyBoardId);
                FillModbusLedProperties(counter.MasterDisplayLedId);

                speCallCommandAddress.Text = counter.AddressCallCommand;
                speDevicdeIdKeyboard.Text = counter.KeyboardId.ToString();
                speDevicdeIdLed.Text = counter.DisplayLedId.ToString();
                speDisplayModeLedAddress.Text = counter.AddressDisplayLedMode;
                speDisplayNumberKeyboardAddress.Text = counter.AddressDisplayNumber;
                speDisplayNumberLedAddress.Text = counter.AddressDisplayLedNumber;
                spePiorityAddress.Text = counter.AddressPiorityNumber;
                speRemainAddress.Text = counter.AddressRemainNumber;
            }
        }

        private void FillModbusKeyboardProperties(int modbusId)
        {
            if (modbusId > 0)
            {
                var param = modbusParameters.FirstOrDefault(x => x.Id == modbusId);
                if (param != null)
                {
                    txbPortKeyboard.Text = param.Port;
                    txbBaudrateKeyboard.Text = param.Baudrate.ToString();
                    txbDataBitsKeyboard.Text = param.DataBits.ToString();
                    txbParityKeyboard.Text = param.Parity;
                    txbStopBitsKeyboard.Text = param.StopBits;
                    return;
                }
            }
            txbPortKeyboard.ResetText();
            txbBaudrateKeyboard.ResetText();
            txbDataBitsKeyboard.ResetText();
            txbParityKeyboard.ResetText();
            txbStopBitsKeyboard.ResetText();
        }

        private void FillModbusLedProperties(int modbusId)
        {
            if (modbusId > 0)
            {
                var param = modbusParameters.FirstOrDefault(x => x.Id == modbusId);
                if (param != null)
                {
                    txbPortLed.Text = param.Port;
                    txbBaudrateLed.Text = param.Baudrate.ToString();
                    txbDataBitsLed.Text = param.DataBits.ToString();
                    txbParityLed.Text = param.Parity;
                    txbStopBitsLed.Text = param.StopBits;
                    return;
                }
            }
            txbPortKeyboard.ResetText();
            txbBaudrateKeyboard.ResetText();
            txbDataBitsKeyboard.ResetText();
            txbParityKeyboard.ResetText();
            txbStopBitsKeyboard.ResetText();
        }

        #endregion

        #region Event handlers

        private void LokModbusMasterLed_EditValueChanged(object sender, EventArgs e)
        {
            int modbusId = 0;
            if (lokModbusMasterLed.GetSelectedDataRow() is ModbusMasterParameter param)
                modbusId = param.Id;
            FillModbusLedProperties(modbusId);
        }

        private void LokModbusMasterKeyboard_EditValueChanged(object sender, EventArgs e)
        {
            int modbusId = 0;
            if (lokModbusMasterKeyboard.GetSelectedDataRow() is ModbusMasterParameter param)
                modbusId = param.Id;
            FillModbusKeyboardProperties(modbusId);
        }

        private void ClearButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (sender is ButtonEdit btnEdit)
            {
                btnEdit.ResetText();
            }
        }

        #endregion

        private void lokModbusMasterLed_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            {
                lokModbusMasterLed.EditValue = null;
            }
        }

        private void lokModbusMasterKeyboard_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
            {
                lokModbusMasterKeyboard.EditValue = null;
            }
        }
    }
}
