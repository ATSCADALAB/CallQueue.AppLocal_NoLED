using CallQueue.Core;
using DevExpress.Mvvm;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CallQueue.AppLocal
{
    public partial class frmEditModbusMasterParameter : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Public members

        public bool IsBusy { get; set; }

        #endregion

        #region Private members

        bool isNew;
        ModbusMasterParameter modbusParam;
        ModbusManager modbusManager;
        UnitOfWork unitOfWork;

        DelegateCommand saveAndCloseCommand;
        DelegateCommand restoreCommand;
        DelegateCommand closeCommand;

        #endregion

        #region Constructors

        public frmEditModbusMasterParameter(ModbusMasterParameter modbusParam, UnitOfWork unitOfWork, ModbusManager modbusManager)
        {
            InitializeComponent();

            this.unitOfWork = unitOfWork;
            this.modbusParam = modbusParam;
            this.modbusManager = modbusManager;
            if (modbusParam == null)
            {
                isNew = true;
                Text = "Thêm kết nối";
            }
            else
            {
                Text = $"Chỉnh sửa kết nối - {modbusParam.Id}";
            }


            btnSave.ItemClick += BtnSave_ItemClick;
            saveAndCloseCommand = new DelegateCommand(SaveAndClose);
            restoreCommand = new DelegateCommand(Restore);
            closeCommand = new DelegateCommand(Exit);
            btnSaveAndClose.BindCommand(saveAndCloseCommand);
            btnRestore.BindCommand(restoreCommand);
            btnClose.BindCommand(closeCommand);

            cobPort.Properties.Items.AddRange(ModbusManager.GetPortNames());
            cobBaudrate.Properties.Items.AddRange(ModbusManager.GetBaudrates());
            cobDataBits.Properties.Items.AddRange(ModbusManager.GetDatabits());
            cobParity.Properties.Items.AddRange(ModbusManager.GetParities());
            cobStopBits.Properties.Items.AddRange(ModbusManager.GetStopBits());

            cobPort.Text = "";
            cobBaudrate.SelectedIndex = 0;
            cobDataBits.SelectedIndex = 0;
            cobParity.SelectedIndex = 0;
            cobStopBits.SelectedIndex = 0;
            FillProperties(modbusParam);

        }

        #endregion

        #region Private methods

        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(txbName.Text))
            {
                Utils.ShowExclamation("Tên kết nối không được để trống.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cobPort.Text))
            {
                Utils.ShowExclamation("Trường Port không được để trống.");
                return false;
            }
            try
            {
                ModbusMasterParameter newModbusParam = new ModbusMasterParameter();
                newModbusParam.Name = txbName.Text?.Trim();
                newModbusParam.Baudrate = int.Parse(cobBaudrate.EditValue.ToString());
                newModbusParam.Port = cobPort.Text;
                newModbusParam.DataBits = int.Parse(cobDataBits.EditValue.ToString());
                newModbusParam.Parity = cobParity.EditValue.ToString();
                newModbusParam.StopBits = cobStopBits.EditValue.ToString();

                if (isNew)
                {

                    if (modbusManager.InsertModbusMasterParameter(newModbusParam) != 1)
                    {
                        Utils.ShowErrorMessageBox("Không thể thêm kết nối mới !");
                        return false;
                    }
                }
                else
                {
                    newModbusParam.Id = int.Parse(txbId.Text);
                    if (modbusManager.UpdateModbusMasterParameter(newModbusParam) != 0)
                    {
                        modbusParam = newModbusParam;
                        FillProperties(newModbusParam);
                    }
                    else
                    {
                        Utils.ShowExclamation("Không thể cập nhất kết nối !");
                    }
                }

                return true;
            }
            catch (MySqlException sqlEx)
            {
                if (sqlEx.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
                {
                    Utils.ShowErrorMessageBox("Tên kết nối đã tồn tại. Xin mời nhập tên kết vụ khác.");
                    txbName.Focus();
                }
                else
                {
                    sqlEx.ShowErrorMessageBox();
                }
                return false;
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
                return false;
            }
        }

        private void BtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }


        private void Exit()
        {
            Close();
        }


        private void SaveAndClose()
        {
            if (Save())
                Exit();
        }

        private void Restore()
        {
            FillProperties(modbusParam);
        }

        private void FillProperties(ModbusMasterParameter modbusParam)
        {
            if (modbusParam == null)
            {
                txbId.ResetText();
                txbName.ResetText();
                cobPort.SelectedIndex = -1;
                cobDataBits.SelectedIndex = 0;
                cobParity.SelectedIndex = 0;
                cobStopBits.SelectedIndex = 0;
                cobBaudrate.SelectedIndex = 0;
            }
            else
            {
                txbId.Text = modbusParam.Id.ToString();
                txbName.Text = modbusParam.Name;
                cobPort.Text = modbusParam.Port;
                cobDataBits.EditValue = modbusParam.DataBits;
                cobParity.EditValue = modbusParam.Parity;
                cobStopBits.EditValue = modbusParam.StopBits;
                cobBaudrate.EditValue = modbusParam.Baudrate;
            }
        }

        #endregion  
    }
}
