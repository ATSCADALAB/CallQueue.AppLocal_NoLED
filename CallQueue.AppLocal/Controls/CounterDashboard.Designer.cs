namespace CallQueue.AppLocal
{
    partial class CounterDashboard
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
            this.groupCounter = new DevExpress.XtraEditors.GroupControl();
            this.lbCurrentNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // groupCounter
            // 
            this.groupCounter.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCounter.AppearanceCaption.Options.UseFont = true;
            this.groupCounter.AppearanceCaption.Options.UseTextOptions = true;
            this.groupCounter.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupCounter.Controls.Add(this.lbCurrentNumber);
            this.groupCounter.Controls.Add(this.label1);
            this.groupCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCounter.Location = new System.Drawing.Point(0, 0);
            this.groupCounter.Name = "groupCounter";
            this.groupCounter.Size = new System.Drawing.Size(233, 167);
            this.groupCounter.TabIndex = 0;
            this.groupCounter.Text = "QUẦY";
            // 
            // lbCurrentNumber
            // 
            this.lbCurrentNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCurrentNumber.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentNumber.Location = new System.Drawing.Point(2, 50);
            this.lbCurrentNumber.Name = "lbCurrentNumber";
            this.lbCurrentNumber.Size = new System.Drawing.Size(229, 80);
            this.lbCurrentNumber.TabIndex = 1;
            this.lbCurrentNumber.Text = "0000";
            this.lbCurrentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "SỐ ĐANG GỌI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CounterDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupCounter);
            this.Name = "CounterDashboard";
            this.Size = new System.Drawing.Size(233, 167);
            ((System.ComponentModel.ISupportInitialize)(this.groupCounter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupCounter;
        private System.Windows.Forms.Label lbCurrentNumber;
        private System.Windows.Forms.Label label1;
    }
}
