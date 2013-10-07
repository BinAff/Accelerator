namespace Vanilla.Guardian.WinForm
{
    partial class Register
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lsvUser = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lsvUser
            // 
            this.lsvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvUser.Location = new System.Drawing.Point(0, 0);
            this.lsvUser.Name = "lsvUser";
            this.lsvUser.Size = new System.Drawing.Size(525, 308);
            this.lsvUser.TabIndex = 133;
            this.lsvUser.UseCompatibleStateImageBehavior = false;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsvUser);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(525, 308);
            this.Load += new System.EventHandler(this.UserRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ListView lsvUser;

    }
}