using CallQueue.Core;
using DevExpress.Mvvm;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CallQueue.AppLocal
{
    public partial class frmEditAccount : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Public members

        public bool IsBusy { get; set; }
        public List<Role> Roles { get; set; }

        #endregion

        #region Private members

        Account account;
        bool isNew;
        UnitOfWork unitOfWork;

        DelegateCommand saveAndCloseCommand;
        DelegateCommand restoreCommand;
        DelegateCommand closeCommand;

        #endregion

        #region Constructors

        public frmEditAccount(Account account, UnitOfWork unitOfWork)
        {
            InitializeComponent();

            this.unitOfWork = unitOfWork;
            Roles = unitOfWork.RoleRepository.GetAll();
            cobRole.Properties.DataSource = Roles;
            cobRole.Properties.DisplayMember = "Name";
            cobRole.Properties.ValueMember = "Id";
            cobRole.Properties.ShowFooter = false;
            this.account = account;
            if (account == null)
            {
                isNew = true;
                Text = "Thêm tài khoản";
            }
            else
            {
                Text = $"Chỉnh sửa tải khoản - {account.Id}"; 
            }

            FillProperties(account);

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
            if (string.IsNullOrWhiteSpace(txbUsername.Text))
            {
                Utils.ShowExclamation("Tên người dùng không được để trống.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbPassword.Text))
            {
                Utils.ShowExclamation("Mật khẩu không được để trống.");
                return false;
            }

            if (txbPassword.Text != txbRePassword.Text)
            {
                Utils.ShowExclamation("Mật khẩu xác nhận không đúng.");
                return false;
            }

            if (cobRole.GetSelectedDataRow() == null)
            {
                Utils.ShowExclamation("Vai trò của tài khoản không được để trống.");
                return false;
            }

            try
            {
                Account newAccount = new Account();
                newAccount.Username = txbUsername.Text?.Trim();
                newAccount.Password = txbPassword.Text?.Trim();
                newAccount.RoleId = Convert.ToInt32(cobRole.EditValue);

                if (isNew)
                {
                    unitOfWork.AccountRepository.Insert(newAccount);
                }
                else
                {
                    newAccount.Id = int.Parse(txbId.Text);
                    unitOfWork.AccountRepository.Update(newAccount);
                }

                FillProperties(newAccount);
                account = newAccount;
                return true;
            }
            catch (MySqlException sqlEx)
            {
                if (sqlEx.Number == (int)MySqlErrorCode.DuplicateKeyEntry)
                {
                    Utils.ShowErrorMessageBox("Tên tài khoản đã tồn tại. Xin mời nhập tên tài khoản khác.");
                    txbUsername.Focus();                    
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
            FillProperties(account);
        }

        private void FillProperties(Account account)
        {
            if (account == null)
            {
                txbId.ResetText();
                txbPassword.ResetText();
                txbRePassword.ResetText();
                txbUsername.ResetText();
            }
            else
            {
                txbId.Text = account.Id.ToString();
                txbUsername.Text = account.Username;
                txbPassword.Text = account.Password;
                txbRePassword.Text = account.Password;
                cobRole.EditValue = account.RoleId;
            }
        }

        #endregion
    }
}
