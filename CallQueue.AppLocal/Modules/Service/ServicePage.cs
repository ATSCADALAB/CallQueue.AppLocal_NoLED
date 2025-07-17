using System;
using System.Windows.Forms;
using CallQueue.Core;
using SQLHelper;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Mvvm;
using System.Data;

namespace CallQueue.AppLocal
{
    public partial class ServicePage : UserControl
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

        public ServicePage(UnitOfWork unitOfWork)
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
                transitionManager1.OpenFormAsync(this, this, () => new frmEditService(null, unitOfWork), () =>
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
                DataRowView dtRow = gridView1.GetRow(SelectedIndex) as DataRowView;
                Service service = new Service()
                {
                    Id = int.Parse(dtRow["Id"].ToString()),
                    Name = dtRow["Name"].ToString(),
                    PiorityLevel = int.Parse(dtRow["PiorityLevel"].ToString()),
                    Description = dtRow["Description"].ToString(),
                    Mark = dtRow["Mark"].ToString(),
                    InputPin = int.Parse(dtRow["InputPin"].ToString())
                };
                transitionManager1.OpenFormAsync(this, this, () => new frmEditService(service, unitOfWork), () =>
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
                    if (gridView1.GetRow(SelectedIndex) is DataRowView dtRow)
                    {
                        if (int.TryParse(dtRow["Id"].ToString(), out int id))
                        {
                            unitOfWork.ServiceRepository.Delete(id);
                            Reload();
                            RaiseCommandsCanExecuteChanged();
                        }
                    }
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
                gridView2.ViewCaption = "Quầy xử lý dịch vụ";

                DataSet dataSet = new DataSet();
                DataTable dtService = unitOfWork.ServiceRepository.GetAllData();
                DataTable dtCounter = unitOfWork.SQLHelper.ExecuteQuery("select c.*, cs.* from counterservice cs inner join counter c on c.Id = cs.CounterId and cs.Enable = 'True'");

                dtService.TableName = "Services";
                dtCounter.TableName = "Counter";
                dataSet.Tables.Add(dtService);
                dataSet.Tables.Add(dtCounter);

                DataColumn keyColumn = dataSet.Tables["Services"].Columns["Id"];
                DataColumn foreignKeyColumn = dataSet.Tables["Counter"].Columns["ServiceId"];
                dataSet.Relations.Add("dichvu", keyColumn, foreignKeyColumn);
                grcService.LevelTree.Nodes.Clear();
                grcService.LevelTree.Nodes.Add("dichvu", gridView2);
                grcService.DataSource = dataSet.Tables["Services"];
                grcService.ForceInitialize();


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
            if (sender is GridView grid)
            {
                if (grid.Name == gridView1.Name)
                    SelectedIndex = e.FocusedRowHandle;
                else
                    SelectedIndex = -1;
            }
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
