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
    public partial class CounterPage : UserControl
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
        readonly ModbusManager modbusManager;

        #endregion

        #region Private members

        DelegateCommand createCommand;
        DelegateCommand editCommand;
        DelegateCommand deleteCommand;
        DelegateCommand reloadCommand;
        DelegateCommand configCommand;

        #endregion

        #region Constructors

        public CounterPage(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            this.unitOfWork = unitOfWork;
            modbusManager = IoC.Instance.Get<ModbusManager>();
            Load += AccountPage_Load;
            gridView1.DoubleClick += GridView1_DoubleClick;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;

            #region Bind commands
            createCommand = new DelegateCommand(Create, CanCreate);
            editCommand = new DelegateCommand(Edit, CanEdit);
            deleteCommand = new DelegateCommand(Delete, CanDelete);
            reloadCommand = new DelegateCommand(Reload, CanReload);
            configCommand = new DelegateCommand(Config, CanConfig);
            btnCreate.BindCommand(createCommand);
            btnEdit.BindCommand(editCommand);
            btnDelete.BindCommand(deleteCommand);
            btnRefresh.BindCommand(reloadCommand);
            btnConfigModbus.BindCommand(configCommand);
            #endregion
        }

        #endregion

        #region CRUD methods

        private void Config()
        {
            try
            {
                IsBusy = true;
                DataRowView dtRow = gridView1.GetRow(SelectedIndex) as DataRowView;
                transitionManager1.OpenFormAsync(this, this, () => new frmCounterModbusConfig(int.Parse(dtRow["Id"].ToString()), modbusManager, unitOfWork), () =>
                {
                    IsBusy = false;
                    RaiseCommandsCanExecuteChanged();
                });
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
            finally { IsBusy = false; }
        }

        private bool CanConfig()
        {
            return !IsBusy;
        }

        private void Create()
        {
            try
            {
                IsBusy = true;
                transitionManager1.OpenFormAsync(this, this, () => new frmEditCounter(null, unitOfWork), () =>
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
                Counter service = new Counter()
                {
                    Id = int.Parse(dtRow["Id"].ToString()),
                    Name = dtRow["Name"].ToString(),
                    Voice = dtRow["Voice"].ToString()
                };
                transitionManager1.OpenFormAsync(this, this, () => new frmEditCounter(service, unitOfWork), () =>
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
                            unitOfWork.CounterRepository.Delete(id);
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

                DataSet dataSet = new DataSet();
                DataTable dtCounter = unitOfWork.CounterRepository.GetAllData();
                DataTable dtService = unitOfWork.SQLHelper.ExecuteQuery("select s.*, cs.* from counterservice cs inner join service s on s.Id = cs.ServiceId where cs.Enable = 'True'");

                dtService.TableName = "Services";
                dtCounter.TableName = "Counter";
                dataSet.Tables.Add(dtService);
                dataSet.Tables.Add(dtCounter);

                DataColumn keyColumn = dataSet.Tables["Counter"].Columns["Id"];
                DataColumn foreignKeyColumn = dataSet.Tables["Services"].Columns["CounterId"];
                dataSet.Relations.Add("dichvu", keyColumn, foreignKeyColumn);
                grcCounter.LevelTree.Nodes.Clear();
                grcCounter.LevelTree.Nodes.Add("dichvu", gridView2);
                grcCounter.DataSource = dataSet.Tables["Counter"];
                grcCounter.ForceInitialize();


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
            btnConfigModbus.Enabled = CanConfig();
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
