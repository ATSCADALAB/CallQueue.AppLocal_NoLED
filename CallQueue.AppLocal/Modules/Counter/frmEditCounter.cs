using CallQueue.Core;
using DevExpress.Mvvm;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CallQueue.AppLocal
{
    public partial class frmEditCounter : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Public members

        public bool IsBusy { get; set; }

        #endregion

        #region Private members

        Counter counter;
        List<Service> services;
        List<Service> selectedServices;
        bool isNew;
        UnitOfWork unitOfWork;

        DelegateCommand saveAndCloseCommand;
        DelegateCommand restoreCommand;
        DelegateCommand closeCommand;

        #endregion

        #region Constructors

        public frmEditCounter(Counter counter, UnitOfWork unitOfWork)
        {
            InitializeComponent();

            this.unitOfWork = unitOfWork;
            this.counter = counter;
            if (counter == null)
            {
                isNew = true;
                Text = "Thêm quầy";
            }
            else
            {
                Text = $"Chỉnh sửa quầy - {counter.Id}";
            }

            FillProperties(counter);

            btnSave.ItemClick += BtnSave_ItemClick;
            saveAndCloseCommand = new DelegateCommand(SaveAndClose);
            restoreCommand = new DelegateCommand(Restore);
            closeCommand = new DelegateCommand(Exit);
            btnSaveAndClose.BindCommand(saveAndCloseCommand);
            btnRestore.BindCommand(restoreCommand);
            btnClose.BindCommand(closeCommand);
            btnClearAllServices.ItemClick += BtnClearAllServices_ItemClick;
            btnSelectAllService.ItemClick += BtnSelectAllService_ItemClick;

            services = unitOfWork.ServiceRepository.GetAll();
            clbServices.DataSource = services;
            clbServices.DisplayMember = "Name";
            clbServices.ValueMember = "Id";
            clbServices.MultiColumn = true;

            if (isNew)
                selectedServices = new List<Service>();
            else
            {
                selectedServices = unitOfWork.ServiceRepository.GetBySQLQuery($"select s.* from service s " +
                    $"inner join counterservice cs on cs.ServiceId = s.Id where cs.CounterId = {counter.Id} and cs.Enable = 'True'");
                foreach (Service item in selectedServices)
                {
                    for (int i = 0; i < clbServices.ItemCount; i++)
                    {
                        if (clbServices.GetItem(i) is Service service)
                        {
                            if (service.Id == item.Id)
                                clbServices.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        #endregion

        #region Private methods

        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(txbName.Text))
            {
                Utils.ShowExclamation("Tên quầy không được để trống.");
                return false;
            }

            if (cobVoice.SelectedIndex < 0)
            {
                Utils.ShowExclamation("Trường âm nhận dạng không được để trống.");
                return false;
            }

            try
            {
                Counter newCounter = new Counter();
                newCounter.Name = txbName.Text?.Trim();
                newCounter.Voice = cobVoice.SelectedItem.ToString();

                List<Service> checkedServices = new List<Service>();
                List<Service> uncheckedServices = new List<Service>();
                for (int i = 0; i < clbServices.ItemCount; i++)
                {
                    if (clbServices.GetItem(i) is Service service)
                    {
                        if (clbServices.GetItemChecked(i))
                            checkedServices.Add(service);
                        else
                            uncheckedServices.Add(service);
                    }
                }

                if (isNew)
                {
                    if (unitOfWork.CounterRepository.Insert(newCounter) != 1)
                        Utils.ShowErrorMessageBox("Không thể thêm quầy mới !");
                    else
                    {
                        //foreach (var checkedService in checkedServices)
                        //{
                        //    if (unitOfWork.SQLHelper.ExecuteNonQuery($"update counterservice set Enable = 'True' where CounterId = {newCounter.Id} and ServiceId = {checkedService.Id}") == 0)
                        //    {
                        //        unitOfWork.SQLHelper.ExecuteNonQuery($"insert into counterservice (CounterId, ServiceId) values ({newCounter.Id}, {checkedService.Id})");
                        //    }
                        //}
                        //foreach (var uncheckedService in uncheckedServices)
                        //{
                        //    if (unitOfWork.SQLHelper.ExecuteNonQuery($"update counterservice set Enable = 'False' where CounterId = {newCounter.Id} and ServiceId = {uncheckedService.Id}") == 0)
                        //    {
                        //        unitOfWork.SQLHelper.ExecuteNonQuery($"insert into counterservice (CounterId, ServiceId, Enable) values ({newCounter.Id}, {uncheckedService.Id}, 'False')");
                        //    }
                        //}
                    }
                }
                else
                {
                    newCounter.Id = int.Parse(txbId.Text);
                    if (unitOfWork.CounterRepository.Update(newCounter) == 0)
                        Utils.ShowErrorMessageBox($"Không sửa quầy với mã là '{newCounter.Id}' !");
                    else
                    {
                        foreach (var checkedService in checkedServices)
                        {
                            if (unitOfWork.SQLHelper.ExecuteNonQuery($"update counterservice set Enable = 'True' where CounterId = {newCounter.Id} and ServiceId = {checkedService.Id}") == 0)
                            {
                                unitOfWork.SQLHelper.ExecuteNonQuery($"insert into counterservice (CounterId, ServiceId) values ({newCounter.Id}, {checkedService.Id})");
                            }
                        }
                        foreach (var uncheckedService in uncheckedServices)
                        {
                            if (unitOfWork.SQLHelper.ExecuteNonQuery($"update counterservice set Enable = 'False' where CounterId = {newCounter.Id} and ServiceId = {uncheckedService.Id}") == 0)
                            {
                                unitOfWork.SQLHelper.ExecuteNonQuery($"insert into counterservice (CounterId, ServiceId, Enable) values ({newCounter.Id}, {uncheckedService.Id}, 'False')");
                            }
                        }
                    }                  
                }

                FillProperties(newCounter);
                counter = newCounter;
                return true;
            }
            catch (MySqlException sqlEx)
            {
                if (sqlEx.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
                {
                    Utils.ShowErrorMessageBox("Tên quầy đã tồn tại. Xin mời nhập tên dịch vụ khác.");
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
            FillProperties(counter);
        }

        private void FillProperties(Counter counter)
        {
            if (counter == null)
            {
                txbId.ResetText();
                txbName.ResetText();
                for (int i = 0; i < clbServices.ItemCount; i++)
                {
                    clbServices.SetItemChecked(i, false);
                }
                cobVoice.SelectedIndex = 0;
            }
            else
            {
                txbId.Text = counter.Id.ToString();
                txbName.Text = counter.Name;
                cobVoice.Text = counter.Voice;
                selectedServices = unitOfWork.ServiceRepository.GetBySQLQuery($"select s.* from service s " +
                    $"inner join counterservice cs on cs.ServiceId = s.Id where cs.CounterId = {counter.Id} and cs.Enable = 'True'");
                foreach (Service item in selectedServices)
                {
                    for (int i = 0; i < clbServices.ItemCount; i++)
                    {
                        if (clbServices.GetItem(i) is Service service)
                        {
                            if (service.Id == item.Id)
                                clbServices.SetItemChecked(i, true);
                        }
                    }
                }

            }
        }

        private void BtnSelectAllService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsBusy = true;
            for (int i = 0; i < clbServices.ItemCount; i++)
            {
                clbServices.SetItemChecked(i, true);
            }
            IsBusy = false;
        }

        private void BtnClearAllServices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsBusy = true;
            for (int i = 0; i < clbServices.ItemCount; i++)
            {
                clbServices.SetItemChecked(i, false);
            }
            IsBusy = false;
        }

        #endregion
    }
}
