using System;
using System.Windows.Forms;
using CallQueue.Core;
using SQLHelper;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Mvvm;

namespace CallQueue.AppLocal
{
    public partial class AccountPage : UserControl
    {
        #region Public members

        int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    RaiseCommandsCanExecuteChanged();
                }
            }
        }
        public bool IsBusy { get; set; } 

        #endregion

        #region Inject members

        readonly UnitOfWork unitOfWork;

        #endregion

        #region Private members

        DelegateCommand createCommand;
        DelegateCommand editCommand;
        DelegateCommand deleteCommand;
        DelegateCommand reloadCommand;

        #endregion

        #region Constructors

        public AccountPage(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            this.unitOfWork = unitOfWork;
            Load += AccountPage_Load;
            gridView1.DoubleClick += GridView1_DoubleClick;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;

            #region Bind commands
            createCommand = new DelegateCommand(Create, CanCreate);
            editCommand = new DelegateCommand(Edit, CanEdit);
            deleteCommand = new DelegateCommand(Delete, CanDelete);
            reloadCommand = new DelegateCommand(Reload, CanReload);
            btnCreate.BindCommand(createCommand);
            btnEdit.BindCommand(editCommand);
            btnDelete.BindCommand(deleteCommand);
            btnRefresh.BindCommand(reloadCommand);
            #endregion
        }

        #endregion

        #region CRUD methods

        private void Create()
        {
            try
            {
                IsBusy = true;
                transitionManager1.OpenFormAsync(this, this, () => new frmEditAccount(null, unitOfWork),() =>
                {
                    IsBusy = false;
                    Reload();
                    RaiseCommandsCanExecuteChanged();
                });

            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
            finally { IsBusy = false; }
        }

        private bool CanCreate()
        {
            return !IsBusy;
        }

        private void Edit()
        {
            try
            {
                IsBusy = true;
                Account account = gridView1.GetRow(SelectedIndex) as Account;
                transitionManager1.OpenFormAsync(this, this, () => new frmEditAccount(account, unitOfWork), () =>
                {
                    IsBusy = false;
                    Reload();
                    RaiseCommandsCanExecuteChanged();
                });
                Reload();
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
            finally { IsBusy = false; }
        }

        public bool CanEdit()
        {
            return !IsBusy && SelectedIndex >= 0;
        }

        private void Delete()
        {
            try
            {
                IsBusy = true;
                if (Utils.ShowDeleteQuestion())
                {
                    unitOfWork.AccountRepository.Delete(gridView1.GetRow(SelectedIndex) as Account);
                    Reload();
                    RaiseCommandsCanExecuteChanged();
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
            finally { IsBusy = false; }
        }

        private bool CanDelete()
        {
            return !IsBusy && SelectedIndex >= 0;
        }

        private void Reload()
        {
            try
            {
                IsBusy = true;
                grcUser.DataSource = unitOfWork.AccountRepository.GetAll();
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
            finally { IsBusy = false; }
        }

        private bool CanReload()
        {
            return !IsBusy;
        }

        private void RaiseCommandsCanExecuteChanged()
        {
            btnCreate.Enabled = CanCreate();
            btnEdit.Enabled = CanEdit();
            btnDelete.Enabled = CanDelete();
            btnRefresh.Enabled = CanReload();
        }

        #endregion

        #region Event handlers

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SelectedIndex = e.FocusedRowHandle;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                SelectedIndex = info.RowHandle;
                if (CanEdit())
                    Edit();
            }
        }

        private void AccountPage_Load(object sender, EventArgs e)
        {
            if (CanReload())
                Reload();
        }

        #endregion

    }
}
