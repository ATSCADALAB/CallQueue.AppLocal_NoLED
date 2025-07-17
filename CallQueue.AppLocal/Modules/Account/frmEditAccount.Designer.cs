namespace CallQueue.AppLocal
{
    partial class frmEditAccount
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditAccount));
            this.panel1 = new System.Windows.Forms.Panel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txbId = new DevExpress.XtraEditors.TextEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.txbUsername = new DevExpress.XtraEditors.TextEdit();
            this.txbPassword = new DevExpress.XtraEditors.TextEdit();
            this.txbRePassword = new DevExpress.XtraEditors.TextEdit();
            this.cobRole = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbRePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.layoutControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 227);
            this.panel1.TabIndex = 3;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txbId);
            this.layoutControl1.Controls.Add(this.txbUsername);
            this.layoutControl1.Controls.Add(this.txbPassword);
            this.layoutControl1.Controls.Add(this.txbRePassword);
            this.layoutControl1.Controls.Add(this.cobRole);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1040, 286, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(778, 227);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(109, 12);
            this.txbId.MenuManager = this.ribbonControl1;
            this.txbId.Name = "txbId";
            this.txbId.Properties.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(657, 20);
            this.txbId.StyleController = this.layoutControl1;
            this.txbId.TabIndex = 4;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnSave,
            this.btnSaveAndClose,
            this.btnRestore,
            this.btnClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(778, 156);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 1;
            this.btnSave.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.save_16x161;
            this.btnSave.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.save_32x321;
            this.btnSave.Name = "btnSave";
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Caption = "Lưu Và Thoát";
            this.btnSaveAndClose.Id = 4;
            this.btnSaveAndClose.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.saveandclose_16x16;
            this.btnSaveAndClose.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.saveandclose_32x32;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            // 
            // btnRestore
            // 
            this.btnRestore.Caption = "Phục hồi";
            this.btnRestore.Id = 5;
            this.btnRestore.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.reset2_16x161;
            this.btnRestore.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.reset2_32x321;
            this.btnRestore.Name = "btnRestore";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Thoát";
            this.btnClose.Id = 6;
            this.btnClose.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.close_16x16;
            this.btnClose.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.close_32x32;
            this.btnClose.Name = "btnClose";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSaveAndClose);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRestore);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Action";
            // 
            // txbUsername
            // 
            this.txbUsername.Location = new System.Drawing.Point(109, 36);
            this.txbUsername.MenuManager = this.ribbonControl1;
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(278, 20);
            this.txbUsername.StyleController = this.layoutControl1;
            this.txbUsername.TabIndex = 5;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(109, 60);
            this.txbPassword.MenuManager = this.ribbonControl1;
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Properties.UseSystemPasswordChar = true;
            this.txbPassword.Size = new System.Drawing.Size(278, 20);
            this.txbPassword.StyleController = this.layoutControl1;
            this.txbPassword.TabIndex = 6;
            // 
            // txbRePassword
            // 
            this.txbRePassword.Location = new System.Drawing.Point(488, 60);
            this.txbRePassword.MenuManager = this.ribbonControl1;
            this.txbRePassword.Name = "txbRePassword";
            this.txbRePassword.Properties.UseSystemPasswordChar = true;
            this.txbRePassword.Size = new System.Drawing.Size(278, 20);
            this.txbRePassword.StyleController = this.layoutControl1;
            this.txbRePassword.TabIndex = 7;
            // 
            // cobRole
            // 
            this.cobRole.Location = new System.Drawing.Point(488, 36);
            this.cobRole.MenuManager = this.ribbonControl1;
            this.cobRole.Name = "cobRole";
            this.cobRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobRole.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Role")});
            this.cobRole.Properties.NullText = "";
            this.cobRole.Properties.PopupSizeable = false;
            this.cobRole.Properties.ShowFooter = false;
            this.cobRole.Properties.ShowHeader = false;
            this.cobRole.Properties.ShowLines = false;
            this.cobRole.Size = new System.Drawing.Size(278, 20);
            this.cobRole.StyleController = this.layoutControl1;
            this.cobRole.TabIndex = 8;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(778, 227);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txbId;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(758, 24);
            this.layoutControlItem1.Text = "Mã";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txbUsername;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(379, 24);
            this.layoutControlItem2.Text = "Tài khoản";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txbPassword;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(379, 159);
            this.layoutControlItem3.Text = "Mật khẩu";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txbRePassword;
            this.layoutControlItem4.Location = new System.Drawing.Point(379, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(379, 159);
            this.layoutControlItem4.Text = "Nhập lại mật khẩu";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cobRole;
            this.layoutControlItem5.Location = new System.Drawing.Point(379, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(379, 24);
            this.layoutControlItem5.Text = "Vai trò";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(94, 13);
            // 
            // frmEditAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 383);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditAccount";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txbId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbRePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnRestore;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txbId;
        private DevExpress.XtraEditors.TextEdit txbUsername;
        private DevExpress.XtraEditors.TextEdit txbPassword;
        private DevExpress.XtraEditors.TextEdit txbRePassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LookUpEdit cobRole;
    }
}