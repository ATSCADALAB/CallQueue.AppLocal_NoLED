namespace CallQueue.AppLocal
{
    partial class frmEditModbusMasterParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditModbusMasterParameter));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txbName = new DevExpress.XtraEditors.TextEdit();
            this.txbId = new DevExpress.XtraEditors.TextEdit();
            this.cobStopBits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cobParity = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cobDataBits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cobPort = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cobBaudrate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobStopBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobParity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobDataBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobBaudrate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
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
            this.ribbonControl1.Size = new System.Drawing.Size(800, 156);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 1;
            this.btnSave.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.save_16x161;
            this.btnSave.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.save_32x321;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
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
            this.btnRestore.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnRestore.Name = "btnRestore";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Thoát";
            this.btnClose.Id = 6;
            this.btnClose.ImageOptions.Image = global::CallQueue.AppLocal.Properties.Resources.close_16x16;
            this.btnClose.ImageOptions.LargeImage = global::CallQueue.AppLocal.Properties.Resources.close_32x32;
            this.btnClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4));
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
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txbName);
            this.layoutControl1.Controls.Add(this.txbId);
            this.layoutControl1.Controls.Add(this.cobStopBits);
            this.layoutControl1.Controls.Add(this.cobParity);
            this.layoutControl1.Controls.Add(this.cobDataBits);
            this.layoutControl1.Controls.Add(this.cobPort);
            this.layoutControl1.Controls.Add(this.cobBaudrate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 156);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 294);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(402, 28);
            this.txbName.MenuManager = this.ribbonControl1;
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(386, 20);
            this.txbName.StyleController = this.layoutControl1;
            this.txbName.TabIndex = 5;
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(12, 28);
            this.txbId.MenuManager = this.ribbonControl1;
            this.txbId.Name = "txbId";
            this.txbId.Properties.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(386, 20);
            this.txbId.StyleController = this.layoutControl1;
            this.txbId.TabIndex = 4;
            // 
            // cobStopBits
            // 
            this.cobStopBits.Location = new System.Drawing.Point(636, 69);
            this.cobStopBits.MenuManager = this.ribbonControl1;
            this.cobStopBits.Name = "cobStopBits";
            this.cobStopBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobStopBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cobStopBits.Size = new System.Drawing.Size(152, 20);
            this.cobStopBits.StyleController = this.layoutControl1;
            this.cobStopBits.TabIndex = 6;
            // 
            // cobParity
            // 
            this.cobParity.Location = new System.Drawing.Point(480, 69);
            this.cobParity.MenuManager = this.ribbonControl1;
            this.cobParity.Name = "cobParity";
            this.cobParity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobParity.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cobParity.Size = new System.Drawing.Size(152, 20);
            this.cobParity.StyleController = this.layoutControl1;
            this.cobParity.TabIndex = 8;
            // 
            // cobDataBits
            // 
            this.cobDataBits.Location = new System.Drawing.Point(324, 69);
            this.cobDataBits.MenuManager = this.ribbonControl1;
            this.cobDataBits.Name = "cobDataBits";
            this.cobDataBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobDataBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cobDataBits.Size = new System.Drawing.Size(152, 20);
            this.cobDataBits.StyleController = this.layoutControl1;
            this.cobDataBits.TabIndex = 9;
            // 
            // cobPort
            // 
            this.cobPort.Location = new System.Drawing.Point(12, 69);
            this.cobPort.MenuManager = this.ribbonControl1;
            this.cobPort.Name = "cobPort";
            this.cobPort.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cobPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobPort.Size = new System.Drawing.Size(152, 20);
            this.cobPort.StyleController = this.layoutControl1;
            this.cobPort.TabIndex = 10;
            // 
            // cobBaudrate
            // 
            this.cobBaudrate.Location = new System.Drawing.Point(168, 69);
            this.cobBaudrate.Name = "cobBaudrate";
            this.cobBaudrate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobBaudrate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cobBaudrate.Size = new System.Drawing.Size(152, 20);
            this.cobBaudrate.StyleController = this.layoutControl1;
            this.cobBaudrate.TabIndex = 10;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.simpleSeparator1,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 294);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txbId;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(390, 40);
            this.layoutControlItem1.Text = "Id";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(57, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 81);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(780, 193);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txbName;
            this.layoutControlItem2.Location = new System.Drawing.Point(390, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(390, 40);
            this.layoutControlItem2.Text = "Tên kết nối";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(57, 13);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 40);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(780, 1);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cobStopBits;
            this.layoutControlItem3.Location = new System.Drawing.Point(624, 41);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(156, 40);
            this.layoutControlItem3.Text = "StopBits";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cobParity;
            this.layoutControlItem5.Location = new System.Drawing.Point(468, 41);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(156, 40);
            this.layoutControlItem5.Text = "Parity";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cobDataBits;
            this.layoutControlItem6.Location = new System.Drawing.Point(312, 41);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(156, 40);
            this.layoutControlItem6.Text = "DataBits";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cobPort;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 41);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(156, 40);
            this.layoutControlItem7.Text = "Port";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cobBaudrate;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem4.Location = new System.Drawing.Point(156, 41);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(156, 40);
            this.layoutControlItem4.Text = "Baudrate";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(57, 13);
            // 
            // frmEditModbusMasterParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditModbusMasterParameter";
            this.Ribbon = this.ribbonControl1;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobStopBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobParity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobDataBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobBaudrate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnRestore;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txbName;
        private DevExpress.XtraEditors.TextEdit txbId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ComboBoxEdit cobStopBits;
        private DevExpress.XtraEditors.ComboBoxEdit cobParity;
        private DevExpress.XtraEditors.ComboBoxEdit cobDataBits;
        private DevExpress.XtraEditors.ComboBoxEdit cobPort;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.ComboBoxEdit cobBaudrate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}