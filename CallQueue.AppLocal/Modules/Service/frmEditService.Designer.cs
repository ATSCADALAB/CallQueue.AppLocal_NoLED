namespace CallQueue.AppLocal
{
    partial class frmEditService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditService));
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
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
            this.txbName = new DevExpress.XtraEditors.TextEdit();
            this.txbDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txbPiorityLevel = new DevExpress.XtraEditors.SpinEdit();
            this.cobMark = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cobInputPin = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPiorityLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobMark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobInputPin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.layoutControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 224);
            this.panel1.TabIndex = 5;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txbId);
            this.layoutControl1.Controls.Add(this.txbName);
            this.layoutControl1.Controls.Add(this.txbDescription);
            this.layoutControl1.Controls.Add(this.txbPiorityLevel);
            this.layoutControl1.Controls.Add(this.cobMark);
            this.layoutControl1.Controls.Add(this.cobInputPin);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2817, 289, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(693, 224);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(94, 12);
            this.txbId.MenuManager = this.ribbonControl1;
            this.txbId.Name = "txbId";
            this.txbId.Properties.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(250, 20);
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
            this.ribbonControl1.Size = new System.Drawing.Size(693, 156);
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
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(430, 12);
            this.txbName.MenuManager = this.ribbonControl1;
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(251, 20);
            this.txbName.StyleController = this.layoutControl1;
            this.txbName.TabIndex = 5;
            // 
            // txbDescription
            // 
            this.txbDescription.Location = new System.Drawing.Point(94, 84);
            this.txbDescription.MenuManager = this.ribbonControl1;
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Size = new System.Drawing.Size(587, 128);
            this.txbDescription.StyleController = this.layoutControl1;
            this.txbDescription.TabIndex = 8;
            // 
            // txbPiorityLevel
            // 
            this.txbPiorityLevel.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txbPiorityLevel.Location = new System.Drawing.Point(430, 36);
            this.txbPiorityLevel.MenuManager = this.ribbonControl1;
            this.txbPiorityLevel.Name = "txbPiorityLevel";
            this.txbPiorityLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txbPiorityLevel.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txbPiorityLevel.Properties.IsFloatValue = false;
            this.txbPiorityLevel.Properties.Mask.EditMask = "N00";
            this.txbPiorityLevel.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txbPiorityLevel.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txbPiorityLevel.Size = new System.Drawing.Size(251, 20);
            this.txbPiorityLevel.StyleController = this.layoutControl1;
            this.txbPiorityLevel.TabIndex = 7;
            // 
            // cobMark
            // 
            this.cobMark.EditValue = " ";
            this.cobMark.Location = new System.Drawing.Point(94, 36);
            this.cobMark.MenuManager = this.ribbonControl1;
            this.cobMark.Name = "cobMark";
            this.cobMark.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cobMark.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobMark.Properties.Items.AddRange(new object[] {
            " ",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cobMark.Size = new System.Drawing.Size(250, 20);
            this.cobMark.StyleController = this.layoutControl1;
            this.cobMark.TabIndex = 6;
            // 
            // cobInputPin
            // 
            this.cobInputPin.Location = new System.Drawing.Point(94, 60);
            this.cobInputPin.MenuManager = this.ribbonControl1;
            this.cobInputPin.Name = "cobInputPin";
            this.cobInputPin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cobInputPin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobInputPin.Properties.NullText = "";
            this.cobInputPin.Properties.NullValuePromptShowForEmptyValue = true;
            this.cobInputPin.Properties.PopupSizeable = false;
            this.cobInputPin.Properties.ShowFooter = false;
            this.cobInputPin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cobInputPin.Size = new System.Drawing.Size(587, 20);
            this.cobInputPin.StyleController = this.layoutControl1;
            this.cobInputPin.TabIndex = 9;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(693, 224);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txbId;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(336, 24);
            this.layoutControlItem1.Text = "Mã";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txbDescription;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(673, 132);
            this.layoutControlItem5.Text = "Mô tả";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txbName;
            this.layoutControlItem2.Location = new System.Drawing.Point(336, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(337, 24);
            this.layoutControlItem2.Text = "Tên dịch vụ";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cobMark;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(336, 24);
            this.layoutControlItem3.Text = "Kí hiệu";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txbPiorityLevel;
            this.layoutControlItem4.Location = new System.Drawing.Point(336, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(337, 24);
            this.layoutControlItem4.Text = "Mức độ ưu tiên";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cobInputPin;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(673, 24);
            this.layoutControlItem6.Text = "Ngõ vào in";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(79, 13);
            // 
            // frmEditService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 380);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditService";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txbId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPiorityLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobMark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobInputPin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnRestore;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.TextEdit txbName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txbId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.MemoEdit txbDescription;
        private DevExpress.XtraEditors.SpinEdit txbPiorityLevel;
        private DevExpress.XtraEditors.ComboBoxEdit cobMark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.LookUpEdit cobInputPin;
    }
}