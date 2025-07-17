namespace CallQueue.AppLocal
{
    partial class CounterPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCounter = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalServeCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCreate = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnConfigModbus = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId2,
            this.colName2,
            this.colTotalCount,
            this.colTotalDay,
            this.colTotalWeek,
            this.colTotalMonth,
            this.colTotalYear});
            this.gridView2.GridControl = this.grcCounter;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colId2
            // 
            this.colId2.Caption = "Mã";
            this.colId2.FieldName = "Id";
            this.colId2.Name = "colId2";
            this.colId2.OptionsColumn.AllowEdit = false;
            this.colId2.OptionsFilter.AllowAutoFilter = false;
            this.colId2.OptionsFilter.AllowFilter = false;
            this.colId2.Visible = true;
            this.colId2.VisibleIndex = 0;
            this.colId2.Width = 73;
            // 
            // colName2
            // 
            this.colName2.Caption = "Tên dịch vụ";
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.OptionsColumn.AllowEdit = false;
            this.colName2.OptionsFilter.AllowAutoFilter = false;
            this.colName2.OptionsFilter.AllowFilter = false;
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 1;
            this.colName2.Width = 156;
            // 
            // colTotalCount
            // 
            this.colTotalCount.Caption = "Tổng số lần xử lý";
            this.colTotalCount.FieldName = "TotalCount";
            this.colTotalCount.Name = "colTotalCount";
            this.colTotalCount.OptionsColumn.AllowEdit = false;
            this.colTotalCount.OptionsFilter.AllowAutoFilter = false;
            this.colTotalCount.OptionsFilter.AllowFilter = false;
            this.colTotalCount.Visible = true;
            this.colTotalCount.VisibleIndex = 2;
            this.colTotalCount.Width = 102;
            // 
            // colTotalDay
            // 
            this.colTotalDay.Caption = "Trong số lần xử lý trong ngày";
            this.colTotalDay.FieldName = "CountOfDay";
            this.colTotalDay.Name = "colTotalDay";
            this.colTotalDay.OptionsColumn.AllowEdit = false;
            this.colTotalDay.Visible = true;
            this.colTotalDay.VisibleIndex = 3;
            this.colTotalDay.Width = 169;
            // 
            // colTotalWeek
            // 
            this.colTotalWeek.Caption = "Trong số lần xử lý trong tuần";
            this.colTotalWeek.FieldName = "CountOfWeek";
            this.colTotalWeek.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTotalWeek.Name = "colTotalWeek";
            this.colTotalWeek.OptionsColumn.AllowEdit = false;
            this.colTotalWeek.Visible = true;
            this.colTotalWeek.VisibleIndex = 4;
            this.colTotalWeek.Width = 169;
            // 
            // colTotalMonth
            // 
            this.colTotalMonth.Caption = "Trong số lần xử lý trong tháng";
            this.colTotalMonth.FieldName = "CountOfMonth";
            this.colTotalMonth.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTotalMonth.Name = "colTotalMonth";
            this.colTotalMonth.OptionsColumn.AllowEdit = false;
            this.colTotalMonth.Visible = true;
            this.colTotalMonth.VisibleIndex = 5;
            this.colTotalMonth.Width = 169;
            // 
            // colTotalYear
            // 
            this.colTotalYear.Caption = "Trong số lần xử lý trong năm";
            this.colTotalYear.FieldName = "CountOfYear";
            this.colTotalYear.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTotalYear.Name = "colTotalYear";
            this.colTotalYear.OptionsColumn.AllowEdit = false;
            this.colTotalYear.Visible = true;
            this.colTotalYear.VisibleIndex = 6;
            this.colTotalYear.Width = 179;
            // 
            // grcCounter
            // 
            this.grcCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcCounter.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.grcCounter.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcCounter.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grcCounter.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcCounter.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grcCounter.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcCounter.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grcCounter.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcCounter.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grcCounter.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcCounter.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "Level1";
            this.grcCounter.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcCounter.Location = new System.Drawing.Point(8, 8);
            this.grcCounter.MainView = this.gridView1;
            this.grcCounter.Name = "grcCounter";
            this.grcCounter.Padding = new System.Windows.Forms.Padding(8);
            this.grcCounter.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.grcCounter.Size = new System.Drawing.Size(1042, 405);
            this.grcCounter.TabIndex = 9;
            this.grcCounter.UseEmbeddedNavigator = true;
            this.grcCounter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colTotalServeCount,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.grcCounter;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsPrint.PrintFooter = false;
            this.gridView1.OptionsPrint.PrintGroupFooter = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colId
            // 
            this.colId.Caption = "Mã";
            this.colId.FieldName = "Id";
            this.colId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 67;
            // 
            // colName
            // 
            this.colName.Caption = "Tên quầy";
            this.colName.FieldName = "Name";
            this.colName.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 161;
            // 
            // colTotalServeCount
            // 
            this.colTotalServeCount.Caption = "Tổng số lần phục vụ";
            this.colTotalServeCount.FieldName = "TotalServeCount";
            this.colTotalServeCount.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTotalServeCount.Name = "colTotalServeCount";
            this.colTotalServeCount.OptionsColumn.AllowEdit = false;
            this.colTotalServeCount.Visible = true;
            this.colTotalServeCount.VisibleIndex = 2;
            this.colTotalServeCount.Width = 120;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tổng số lần xử lý trong ngày";
            this.gridColumn1.FieldName = "ServeCountOfDay";
            this.gridColumn1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 166;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tổng số lần xử lý trong tuần";
            this.gridColumn2.FieldName = "ServeCountOfWeek";
            this.gridColumn2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 166;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tổng số lần xử lý trong tháng";
            this.gridColumn3.FieldName = "ServeCountOfMonth";
            this.gridColumn3.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 166;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tổng số lần xử lý trong năm";
            this.gridColumn4.FieldName = "ServeCountOfYear";
            this.gridColumn4.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 171;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grcCounter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(1058, 421);
            this.panel1.TabIndex = 8;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnCreate,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.btnConfigModbus});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1058, 148);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Below;
            // 
            // btnCreate
            // 
            this.btnCreate.Caption = "Tạo quầy";
            this.btnCreate.Id = 1;
            this.btnCreate.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.add_16x161;
            this.btnCreate.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.add_32x321;
            this.btnCreate.Name = "btnCreate";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Chỉnh sửa";
            this.btnEdit.Id = 2;
            this.btnEdit.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.edit_16x162;
            this.btnEdit.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.edit_32x322;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 3;
            this.btnDelete.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.delete_16x161;
            this.btnDelete.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.delete_32x321;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Id = 4;
            this.btnRefresh.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.refresh2_16x161;
            this.btnRefresh.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.refresh2_32x321;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnConfigModbus
            // 
            this.btnConfigModbus.Caption = "Cấu hình kết nối";
            this.btnConfigModbus.Id = 5;
            this.btnConfigModbus.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.technology_16x16;
            this.btnConfigModbus.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.technology_32x32;
            this.btnConfigModbus.Name = "btnConfigModbus";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCreate);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnConfigModbus);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Action";
            // 
            // transitionManager1
            // 
            this.transitionManager1.FrameCount = 0;
            this.transitionManager1.FrameInterval = 0;
            // 
            // CounterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "CounterPage";
            this.Size = new System.Drawing.Size(1058, 569);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grcCounter;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colId2;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalServeCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnCreate;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalDay;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalWeek;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalYear;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.Utils.Animation.TransitionManager transitionManager1;
        private DevExpress.XtraBars.BarButtonItem btnConfigModbus;
    }
}
