namespace Vanilla.Navigator.WinForm
{
    partial class Configuration
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
            this.pnlMain = new System.Windows.Forms.SplitContainer();
            this.lsvConfiguration = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.Panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlMain.Panel2
            // 
            this.pnlMain.Panel2.Controls.Add(this.lsvConfiguration);
            this.pnlMain.Size = new System.Drawing.Size(404, 274);
            this.pnlMain.SplitterDistance = 215;
            this.pnlMain.TabIndex = 11;
            // 
            // lsvConfiguration
            // 
            this.lsvConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvConfiguration.Location = new System.Drawing.Point(0, 0);
            this.lsvConfiguration.Name = "lsvConfiguration";
            this.lsvConfiguration.Size = new System.Drawing.Size(185, 274);
            this.lsvConfiguration.TabIndex = 0;
            this.lsvConfiguration.UseCompatibleStateImageBehavior = false;
            this.lsvConfiguration.DoubleClick += new System.EventHandler(this.lsvConfiguration_DoubleClick);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "Configuration";
            this.Size = new System.Drawing.Size(404, 274);
            this.pnlMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer pnlMain;
        private System.Windows.Forms.ListView lsvConfiguration;
    }
}
