namespace AutoTourism
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblVersion = new System.Windows.Forms.Label();
            this.lvlCopyright = new System.Windows.Forms.Label();
            this.lnkWebsite = new System.Windows.Forms.LinkLabel();
            this.lblCrystal = new System.Windows.Forms.Label();
            this.lstModule = new System.Windows.Forms.ListBox();
            this.picSplash = new System.Windows.Forms.PictureBox();
            this.picBinAff = new System.Windows.Forms.PictureBox();
            this.picProgress = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSplash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBinAff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            this.lblVersion.Location = new System.Drawing.Point(319, 427);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(91, 17);
            this.lblVersion.TabIndex = 99;
            this.lblVersion.Text = "Version 1.0";
            this.lblVersion.Visible = false;
            // 
            // lvlCopyright
            // 
            this.lvlCopyright.AutoSize = true;
            this.lvlCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lvlCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            this.lvlCopyright.Location = new System.Drawing.Point(473, 403);
            this.lvlCopyright.Name = "lvlCopyright";
            this.lvlCopyright.Size = new System.Drawing.Size(205, 15);
            this.lvlCopyright.TabIndex = 99;
            this.lvlCopyright.Text = "Copyright © Binary Affairs 2012";
            this.lvlCopyright.Visible = false;
            // 
            // lnkWebsite
            // 
            this.lnkWebsite.AutoSize = true;
            this.lnkWebsite.BackColor = System.Drawing.Color.Transparent;
            this.lnkWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkWebsite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.lnkWebsite.Location = new System.Drawing.Point(527, 386);
            this.lnkWebsite.Name = "lnkWebsite";
            this.lnkWebsite.Size = new System.Drawing.Size(151, 15);
            this.lnkWebsite.TabIndex = 0;
            this.lnkWebsite.TabStop = true;
            this.lnkWebsite.Text = "www.binaryaffairs.com";
            this.lnkWebsite.Visible = false;
            this.lnkWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebsite_LinkClicked);
            // 
            // lblCrystal
            // 
            this.lblCrystal.AutoSize = true;
            this.lblCrystal.BackColor = System.Drawing.Color.Transparent;
            this.lblCrystal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrystal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            this.lblCrystal.Location = new System.Drawing.Point(475, 436);
            this.lblCrystal.Name = "lblCrystal";
            this.lblCrystal.Size = new System.Drawing.Size(203, 15);
            this.lblCrystal.TabIndex = 99;
            this.lblCrystal.Text = "Powered by Crystal Framework";
            this.lblCrystal.Visible = false;
            // 
            // lstModule
            // 
            this.lstModule.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lstModule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.lstModule.FormattingEnabled = true;
            this.lstModule.ItemHeight = 15;
            this.lstModule.Items.AddRange(new object[] {
            " Customer Management",
            " Lodge Management",
            " Housekeeping Management",
            " Restaurant Management",
            " Transport Management"});
            this.lstModule.Location = new System.Drawing.Point(457, 16);
            this.lstModule.Margin = new System.Windows.Forms.Padding(5);
            this.lstModule.Name = "lstModule";
            this.lstModule.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstModule.Size = new System.Drawing.Size(214, 75);
            this.lstModule.TabIndex = 99;
            this.lstModule.TabStop = false;
            this.lstModule.UseTabStops = false;
            this.lstModule.Visible = false;
            // 
            // picSplash
            // 
            this.picSplash.BackColor = System.Drawing.Color.Transparent;
            this.picSplash.Image = ((System.Drawing.Image)(resources.GetObject("picSplash.Image")));
            this.picSplash.Location = new System.Drawing.Point(286, 419);
            this.picSplash.Name = "picSplash";
            this.picSplash.Size = new System.Drawing.Size(32, 32);
            this.picSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSplash.TabIndex = 3;
            this.picSplash.TabStop = false;
            this.picSplash.Visible = false;
            // 
            // picBinAff
            // 
            this.picBinAff.BackColor = System.Drawing.Color.Transparent;
            this.picBinAff.Image = ((System.Drawing.Image)(resources.GetObject("picBinAff.Image")));
            this.picBinAff.Location = new System.Drawing.Point(436, 386);
            this.picBinAff.Name = "picBinAff";
            this.picBinAff.Size = new System.Drawing.Size(32, 32);
            this.picBinAff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBinAff.TabIndex = 2;
            this.picBinAff.TabStop = false;
            this.picBinAff.Visible = false;
            // 
            // picProgress
            // 
            this.picProgress.BackColor = System.Drawing.Color.Transparent;
            this.picProgress.Image = global::AutoTourism.Properties.Resources.Progress;
            this.picProgress.Location = new System.Drawing.Point(323, 206);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(60, 58);
            this.picProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProgress.TabIndex = 100;
            this.picProgress.TabStop = false;
            this.picProgress.Visible = false;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(707, 470);
            this.Controls.Add(this.picProgress);
            this.Controls.Add(this.lstModule);
            this.Controls.Add(this.lblCrystal);
            this.Controls.Add(this.lnkWebsite);
            this.Controls.Add(this.lvlCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.picSplash);
            this.Controls.Add(this.picBinAff);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Click += new System.EventHandler(this.Splash_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picSplash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBinAff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox picBinAff;
        private System.Windows.Forms.PictureBox picSplash;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lvlCopyright;
        private System.Windows.Forms.LinkLabel lnkWebsite;
        private System.Windows.Forms.Label lblCrystal;
        private System.Windows.Forms.ListBox lstModule;
        private System.Windows.Forms.PictureBox picProgress;

    }
}