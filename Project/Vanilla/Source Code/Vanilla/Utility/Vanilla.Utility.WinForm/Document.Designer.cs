namespace Vanilla.Utility.WinForm
{
    partial class Document
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
            this.timerLoadHandler = new System.Windows.Forms.Timer(this.components);
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timerLoadHandler
            // 
            this.timerLoadHandler.Interval = 1;
            this.timerLoadHandler.Tick += new System.EventHandler(this.timerLoadHandler_Tick);
            // 
            // pnlLoading
            // 
            this.pnlLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoading.Location = new System.Drawing.Point(0, 0);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(792, 573);
            this.pnlLoading.TabIndex = 0;
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.pnlLoading);
            this.Name = "Document";
            this.Text = "Document";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Document_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Document_FormClosed);
            this.Load += new System.EventHandler(this.Document_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerLoadHandler;
        private System.Windows.Forms.Panel pnlLoading;
    }
}