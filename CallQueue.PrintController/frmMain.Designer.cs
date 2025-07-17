namespace CallQueue.PrintController
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ioSettings = new CallQueue.PrintController.RaspBerryIOSetting(this.components);
            this.serialPrinter1 = new CallQueue.PrintController.SerialPrinter(this.components);
            this.SuspendLayout();
            // 
            // ioSettings
            // 
            this.ioSettings.UpdateInterval = 100;
            // 
            // serialPrinter1
            // 
            this.serialPrinter1.BaudRate = 19200;
            this.serialPrinter1.DataBits = 8;
            this.serialPrinter1.Parity = System.IO.Ports.Parity.None;
            this.serialPrinter1.Port = "/dev/ttyUSB0";
            this.serialPrinter1.StopBits = System.IO.Ports.StopBits.One;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 223);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion
        private RaspBerryIOSetting ioSettings;
        private SerialPrinter serialPrinter1;
        private System.Windows.Forms.Timer timer1;
    }
}