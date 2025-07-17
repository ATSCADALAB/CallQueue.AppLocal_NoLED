namespace CallQueue.AppLocal
{
    partial class AccountPage
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnCreate = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grcUser = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
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
            this.ribbonControl1.Size = new System.Drawing.Size(1058, 148);
            // 
            // btnCreate
            // 
            this.btnCreate.Caption = "Tạo tài khoản";
            this.btnCreate.Id = 1;
            this.btnCreate.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.add_16x162;
            this.btnCreate.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.add_32x322;
            this.btnCreate.Name = "btnCreate";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Chỉnh sửa";
            this.btnEdit.Id = 2;
            this.btnEdit.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.edit_16x163;
            this.btnEdit.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.edit_32x323;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 3;
            this.btnDelete.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.delete_16x162;
            this.btnDelete.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.delete_32x322;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Id = 4;
            this.btnRefresh.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.refresh2_16x162;
            this.btnRefresh.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.refresh2_32x322;
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
            this.panel1.Controls.Add(this.grcUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(1058, 554);
            this.panel1.TabIndex = 1;
            // 
            // grcUser
            // 
            this.grcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcUser.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.grcUser.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcUser.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grcUser.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcUser.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grcUser.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcUser.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grcUser.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcUser.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grcUser.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcUser.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcUser.Location = new System.Drawing.Point(8, 8);
            this.grcUser.MainView = this.gridView1;
            this.grcUser.MenuManager = this.ribbonControl1;
            this.grcUser.Name = "grcUser";
            this.grcUser.Padding = new System.Windows.Forms.Padding(8);
            this.grcUser.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.grcUser.Size = new System.Drawing.Size(1042, 538);
            this.grcUser.TabIndex = 2;
            this.grcUser.UseEmbeddedNavigator = true;
            this.grcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colUsername,
            this.colRole});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.grcUser;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
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
            // 
            // colUsername
            // 
            this.colUsername.Caption = "Tài khoản";
            this.colUsername.FieldName = "Username";
            this.colUsername.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colUsername.Name = "colUsername";
            this.colUsername.OptionsColumn.AllowEdit = false;
            this.colUsername.Visible = true;
            this.colUsername.VisibleIndex = 1;
            // 
            // colRole
            // 
            this.colRole.Caption = "Vai trò";
            this.colRole.FieldName = "RoleName";
            this.colRole.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colRole.Name = "colRole";
            this.colRole.OptionsColumn.AllowEdit = false;
            this.colRole.Visible = true;
            this.colRole.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // AccountPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "AccountPage";
            this.Size = new System.Drawing.Size(1058, 702);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnCreate;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.Utils.Animation.TransitionManager transitionManager1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}
