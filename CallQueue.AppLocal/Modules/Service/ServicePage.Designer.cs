namespace CallQueue.AppLocal
{
    partial class ServicePage
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
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcService = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPiorityLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrintedNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalUseCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCreate = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.unboundSource1 = new DevExpress.Data.UnboundSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unboundSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId2,
            this.colName2,
            this.colTotalCount,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView2.GridControl = this.grcService;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView2.OptionsView.ShowFooter = true;
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
            this.colId2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "Tổng: {0}")});
            this.colId2.Visible = true;
            this.colId2.VisibleIndex = 0;
            this.colId2.Width = 65;
            // 
            // colName2
            // 
            this.colName2.Caption = "Tên quầy";
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.OptionsColumn.AllowEdit = false;
            this.colName2.OptionsFilter.AllowAutoFilter = false;
            this.colName2.OptionsFilter.AllowFilter = false;
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 1;
            this.colName2.Width = 121;
            // 
            // colTotalCount
            // 
            this.colTotalCount.Caption = "Tổng số lần xử lý dịch vụ";
            this.colTotalCount.FieldName = "TotalCount";
            this.colTotalCount.Name = "colTotalCount";
            this.colTotalCount.OptionsColumn.AllowEdit = false;
            this.colTotalCount.OptionsFilter.AllowAutoFilter = false;
            this.colTotalCount.OptionsFilter.AllowFilter = false;
            this.colTotalCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCount", "Tổng= {0}")});
            this.colTotalCount.Visible = true;
            this.colTotalCount.VisibleIndex = 2;
            this.colTotalCount.Width = 178;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tổng số lần xử lý trong ngày";
            this.gridColumn1.FieldName = "CountOfMonth";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CountOfMonth", "Tổng= {0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 178;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tổng số lần xử lý trong tuần";
            this.gridColumn2.FieldName = "CountOfWeek";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CountOfWeek", "Tổng= {0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 178;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tồng số lần xử lý trong tháng";
            this.gridColumn3.FieldName = "CountOfMonth";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CountOfMonth", "Tổng= {0}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 178;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tổng số lần xử lý trong năm";
            this.gridColumn4.FieldName = "CountOfYear";
            this.gridColumn4.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CountOfYear", "Tổng= {0}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 191;
            // 
            // grcService
            // 
            this.grcService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcService.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.grcService.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcService.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grcService.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcService.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grcService.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcService.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grcService.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcService.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grcService.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcService.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "Level1";
            this.grcService.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcService.Location = new System.Drawing.Point(8, 8);
            this.grcService.MainView = this.gridView1;
            this.grcService.Name = "grcService";
            this.grcService.Padding = new System.Windows.Forms.Padding(8);
            this.grcService.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.grcService.Size = new System.Drawing.Size(1114, 550);
            this.grcService.TabIndex = 9;
            this.grcService.UseEmbeddedNavigator = true;
            this.grcService.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colMark,
            this.colPiorityLevel,
            this.colPrintedNumber,
            this.colCurrentNumber,
            this.colTotalUseCount,
            this.colDescription});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.grcService;
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
            this.colId.Width = 40;
            // 
            // colName
            // 
            this.colName.Caption = "Tên dịch vụ";
            this.colName.FieldName = "Name";
            this.colName.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 150;
            // 
            // colMark
            // 
            this.colMark.Caption = "Kí hiệu";
            this.colMark.FieldName = "Mark";
            this.colMark.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colMark.Name = "colMark";
            this.colMark.OptionsColumn.AllowEdit = false;
            this.colMark.Visible = true;
            this.colMark.VisibleIndex = 2;
            this.colMark.Width = 56;
            // 
            // colPiorityLevel
            // 
            this.colPiorityLevel.Caption = "Mức độ ưu tiên";
            this.colPiorityLevel.FieldName = "PiorityLevel";
            this.colPiorityLevel.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPiorityLevel.Name = "colPiorityLevel";
            this.colPiorityLevel.OptionsColumn.AllowEdit = false;
            this.colPiorityLevel.Visible = true;
            this.colPiorityLevel.VisibleIndex = 3;
            this.colPiorityLevel.Width = 115;
            // 
            // colPrintedNumber
            // 
            this.colPrintedNumber.Caption = "Số đã in hôm nay";
            this.colPrintedNumber.FieldName = "PrintedNumber";
            this.colPrintedNumber.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPrintedNumber.Name = "colPrintedNumber";
            this.colPrintedNumber.OptionsColumn.AllowEdit = false;
            this.colPrintedNumber.Visible = true;
            this.colPrintedNumber.VisibleIndex = 4;
            this.colPrintedNumber.Width = 115;
            // 
            // colCurrentNumber
            // 
            this.colCurrentNumber.Caption = "Số hiện tại";
            this.colCurrentNumber.FieldName = "CurrentNumber";
            this.colCurrentNumber.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCurrentNumber.Name = "colCurrentNumber";
            this.colCurrentNumber.OptionsColumn.AllowEdit = false;
            this.colCurrentNumber.Visible = true;
            this.colCurrentNumber.VisibleIndex = 5;
            this.colCurrentNumber.Width = 115;
            // 
            // colTotalUseCount
            // 
            this.colTotalUseCount.Caption = "Tổng số lần in";
            this.colTotalUseCount.FieldName = "TotalUseCount";
            this.colTotalUseCount.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTotalUseCount.Name = "colTotalUseCount";
            this.colTotalUseCount.OptionsColumn.AllowEdit = false;
            this.colTotalUseCount.Visible = true;
            this.colTotalUseCount.VisibleIndex = 6;
            this.colTotalUseCount.Width = 115;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Mô tả";
            this.colDescription.FieldName = "Description";
            this.colDescription.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 7;
            this.colDescription.Width = 130;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
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
            this.btnRefresh});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1130, 148);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Below;
            // 
            // btnCreate
            // 
            this.btnCreate.Caption = "Tạo dịch vụ";
            this.btnCreate.Id = 1;
            this.btnCreate.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.add_16x163;
            this.btnCreate.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.add_32x323;
            this.btnCreate.Name = "btnCreate";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Chỉnh sửa";
            this.btnEdit.Id = 2;
            this.btnEdit.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.edit_16x164;
            this.btnEdit.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.edit_32x324;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 3;
            this.btnDelete.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.delete_16x163;
            this.btnDelete.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.delete_32x323;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Id = 4;
            this.btnRefresh.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.refresh2_16x163;
            this.btnRefresh.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.refresh2_32x323;
            this.btnRefresh.Name = "btnRefresh";
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
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Action";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grcService);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(1130, 566);
            this.panel1.TabIndex = 6;
            // 
            // ServicePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ServicePage";
            this.Size = new System.Drawing.Size(1130, 714);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unboundSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.Utils.Animation.TransitionManager transitionManager1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnCreate;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grcService;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colMark;
        private DevExpress.XtraGrid.Columns.GridColumn colPiorityLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colPrintedNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalUseCount;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colId2;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.Data.UnboundSource unboundSource1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
