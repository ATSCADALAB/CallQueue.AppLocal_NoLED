namespace CallQueue.AppLocal
{
    partial class ServiceDashboard
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
            this.groupService = new DevExpress.XtraEditors.GroupControl();
            this.lbRemainService = new System.Windows.Forms.Label();
            this.lbSoDangXuLy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSoDaIn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupService)).BeginInit();
            this.groupService.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupService
            // 
            this.groupService.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupService.AppearanceCaption.Options.UseFont = true;
            this.groupService.AppearanceCaption.Options.UseTextOptions = true;
            this.groupService.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupService.Controls.Add(this.lbRemainService);
            this.groupService.Controls.Add(this.lbSoDangXuLy);
            this.groupService.Controls.Add(this.label6);
            this.groupService.Controls.Add(this.label3);
            this.groupService.Controls.Add(this.lbSoDaIn);
            this.groupService.Controls.Add(this.label1);
            this.groupService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupService.Location = new System.Drawing.Point(0, 0);
            this.groupService.Name = "groupService";
            this.groupService.Size = new System.Drawing.Size(233, 167);
            this.groupService.TabIndex = 0;
            this.groupService.Text = "DỊCH VỤ";
            // 
            // lbRemainService
            // 
            this.lbRemainService.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemainService.Location = new System.Drawing.Point(112, 125);
            this.lbRemainService.Name = "lbRemainService";
            this.lbRemainService.Size = new System.Drawing.Size(100, 27);
            this.lbRemainService.TabIndex = 6;
            this.lbRemainService.Text = "0000";
            this.lbRemainService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSoDangXuLy
            // 
            this.lbSoDangXuLy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDangXuLy.Location = new System.Drawing.Point(112, 98);
            this.lbSoDangXuLy.Name = "lbSoDangXuLy";
            this.lbSoDangXuLy.Size = new System.Drawing.Size(100, 27);
            this.lbSoDangXuLy.TabIndex = 5;
            this.lbSoDangXuLy.Text = "0000";
            this.lbSoDangXuLy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 27);
            this.label6.TabIndex = 4;
            this.label6.Text = "Còn lại: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số đang xử lý: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSoDaIn
            // 
            this.lbSoDaIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSoDaIn.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDaIn.Location = new System.Drawing.Point(2, 50);
            this.lbSoDaIn.Name = "lbSoDaIn";
            this.lbSoDaIn.Size = new System.Drawing.Size(229, 48);
            this.lbSoDaIn.TabIndex = 1;
            this.lbSoDaIn.Text = "0000";
            this.lbSoDaIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "SỐ ĐÃ IN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServiceDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupService);
            this.Name = "ServiceDashboard";
            this.Size = new System.Drawing.Size(233, 167);
            ((System.ComponentModel.ISupportInitialize)(this.groupService)).EndInit();
            this.groupService.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupService;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSoDaIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRemainService;
        private System.Windows.Forms.Label lbSoDangXuLy;
    }
}
