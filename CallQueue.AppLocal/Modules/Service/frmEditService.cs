using CallQueue.Core;
using DevExpress.Mvvm;
using MySql.Data.MySqlClient;
using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;

namespace CallQueue.AppLocal
{
    public partial class frmEditService : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Public members

        public bool IsBusy { get; set; }

        #endregion

        #region Private members

        Service service;
        bool isNew;
        UnitOfWork unitOfWork;
        PrinterManager printerSetting;

        DelegateCommand saveAndCloseCommand;
        DelegateCommand restoreCommand;
        DelegateCommand closeCommand;

        #endregion

        #region Constructors

        public frmEditService(Service service, UnitOfWork unitOfWork)
        {
            InitializeComponent();

            printerSetting = IoC.Instance.PrinterSetting;
            cobInputPin.Properties.DataSource = PrinterManager.GetConnectorPins();
            this.unitOfWork = unitOfWork;
            this.service = service;
            if (service == null)
            {
                isNew = true;
                Text = "Thêm dịch vụ";
            }
            else
            {
                Text = $"Chỉnh sửa dịch vụ - {service.Id}";
            }

            FillProperties(service);

            btnSave.ItemClick += BtnSave_ItemClick;
            saveAndCloseCommand = new DelegateCommand(SaveAndClose);
            restoreCommand = new DelegateCommand(Restore);
            closeCommand = new DelegateCommand(Exit);
            btnSaveAndClose.BindCommand(saveAndCloseCommand);
            btnRestore.BindCommand(restoreCommand);
            btnClose.BindCommand(closeCommand);
        }

        #endregion

        #region Private methods

        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(txbName.Text))
            {
                Utils.ShowExclamation("Tên dịch vụ không được để trống.");
                return false;
            }

            try
            {
                Service newService = new Service();
                newService.Name = txbName.Text?.Trim();
                newService.Mark = cobMark.SelectedItem?.ToString().Trim();
                newService.PiorityLevel = (int)txbPiorityLevel.Value;
                newService.Description = txbDescription.Text?.Trim();
                if (cobInputPin.GetSelectedDataRow() == null)
                    newService.InputPin = -1;
                else
                    newService.InputPin = (int)cobInputPin.GetSelectedDataRow();

                if (isNew)
                {
                    unitOfWork.ServiceRepository.Insert(newService);
                }
                else
                {
                    newService.Id = int.Parse(txbId.Text);
                    unitOfWork.ServiceRepository.Update(newService);
                }

                FillProperties(newService);
                service = newService;
                return true;
            }
            catch (MySqlException sqlEx)
            {
                if (sqlEx.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
                {
                    Utils.ShowErrorMessageBox("Tên dịch vụ đã tồn tại. Xin mời nhập tên dịch vụ khác.");
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
            FillProperties(service);
        }

        private void FillProperties(Service service)
        {
            if (service == null)
            {
                txbId.ResetText();
                txbName.ResetText();
                cobMark.SelectedIndex = 0;
                txbPiorityLevel.Value = 0;
                txbDescription.ResetText();
                cobInputPin.EditValue = null;
            }
            else
            {
                txbId.Text = service.Id.ToString();
                txbName.Text = service.Name;
                cobMark.EditValue = service.Mark?.Trim();
                txbPiorityLevel.Value = service.PiorityLevel;
                txbDescription.Text = service.Description;
                if (service.InputPin == -1)
                    cobInputPin.EditValue = "";
                else
                    cobInputPin.EditValue = (ConnectorPin)service.InputPin;
            }
        }

        #endregion
    }
}
