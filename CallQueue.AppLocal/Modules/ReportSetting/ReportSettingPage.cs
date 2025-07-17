using System;
using System.Windows.Forms;
using CallQueue.Core;
using SQLHelper;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Mvvm;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CallQueue.AppLocal
{
    public partial class ReportSettingPage : UserControl
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
        public bool IsChanged { get; set; }

        public List<Line> OriginalLines { get; set; }
        public BindingList<Line> Lines { get; set; }

        #endregion

        #region Inject members

        readonly UnitOfWork unitOfWork;
        readonly PrinterManager printerManager;

        #endregion

        #region Private members

        DelegateCommand createCommand;
        DelegateCommand editCommand;
        DelegateCommand deleteCommand;
        DelegateCommand reloadCommand;

        #endregion

        #region Constructors

        public ReportSettingPage(UnitOfWork unitOfWork, PrinterManager printerManager)
        {
            InitializeComponent();
            this.printerManager = printerManager;
            this.unitOfWork = unitOfWork;
            Load += AccountPage_Load;
            gridView1.DoubleClick += GridView1_DoubleClick;
            gridView1.InitNewRow += GridView1_InitNewRow;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
            gridView1.EditFormShowing += GridView1_EditFormShowing;

            #region Bind commands
            createCommand = new DelegateCommand(Save, CanSavve);
            editCommand = new DelegateCommand(Edit, CanEdit);
            deleteCommand = new DelegateCommand(Delete, CanDelete);
            reloadCommand = new DelegateCommand(Reload, CanReload);
            btnSave.BindCommand(createCommand);
            btnEdit.BindCommand(editCommand);
            btnDelete.BindCommand(deleteCommand);
            btnRefresh.BindCommand(reloadCommand);
            #endregion
        }

        private void GridView1_EditFormShowing(object sender, EditFormShowingEventArgs e)
        {
            IsChanged = true;
        }

        private void GridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            IsChanged = true;
        }

        #endregion

        #region CRUD methods

        private void Save()
        {
            try
            {
                IsBusy = true;
                if (printerManager.UpdateLines(Lines.ToList()) == 0)
                {
                    Utils.ShowErrorMessageBox("Không thể cập nhật !");
                }
                else
                {
                    Utils.ShowInformation("Đã cập nhật thành công !");
                    IsChanged = false;
                    Reload();
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
            finally { IsBusy = false; }
        }

        private bool CanSavve()
        {
            return !IsBusy;
        }

        private void Edit()
        {
            try
            {
                IsBusy = true;
                var editModbusParam = (gridView1.GetRow(SelectedIndex) as Line);
                gridView1.ShowEditor();
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
                    IsChanged = true;
                    gridView1.DeleteSelectedRows();
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
            finally { IsBusy = false; RaiseCommandsCanExecuteChanged();
            }
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

                if (IsChanged)
                {
                    if (Utils.ShowQuestion("Nội dung đã thay đổi bạn có muốn lưu lại hay không ?"))
                    {
                        Save();
                    }
                }

                IsChanged = false;
                OriginalLines = printerManager.GetAllLines();
                Lines = new BindingList<Line>(printerManager.GetAllLines());
                gridControl1.DataSource = Lines;

            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
            finally { IsBusy = false; RaiseCommandsCanExecuteChanged(); }
        }

        private bool CanReload()
        {
            return !IsBusy;
        }

        private void RaiseCommandsCanExecuteChanged()
        {
            btnSave.Enabled = CanSavve();
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
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //if (info.InRow || info.InRowCell)
            //{
            //    SelectedIndex = info.RowHandle;
            //    if (CanEdit())
            //        Edit();
            //}
        }

        private void AccountPage_Load(object sender, EventArgs e)
        {
            if (CanReload())
                Reload();
        }

        #endregion

        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsChanged = true;
            gridView1.AddNewRow();
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedIndex >= 0)
            {
                Lines.Insert(SelectedIndex, new Line());
            }
        }
    }
}
