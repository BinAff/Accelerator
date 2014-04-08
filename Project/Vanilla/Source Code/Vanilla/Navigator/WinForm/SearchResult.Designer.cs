namespace Vanilla.Navigator.WinForm
{
    partial class SearchResult
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchResult));
            this.lsvSearchResult = new System.Windows.Forms.ListView();
            this.imgLargeIcon = new System.Windows.Forms.ImageList(this.components);
            this.imgSmallIcon = new System.Windows.Forms.ImageList(this.components);
            this.imglIcons = new System.Windows.Forms.ImageList(this.components);
            this.imgMisc = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lsvSearchResult
            // 
            this.lsvSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvSearchResult.LargeImageList = this.imgLargeIcon;
            this.lsvSearchResult.Location = new System.Drawing.Point(0, 0);
            this.lsvSearchResult.Name = "lsvSearchResult";
            this.lsvSearchResult.Size = new System.Drawing.Size(613, 491);
            this.lsvSearchResult.SmallImageList = this.imgSmallIcon;
            this.lsvSearchResult.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvSearchResult.TabIndex = 0;
            this.lsvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lsvSearchResult.View = System.Windows.Forms.View.Details;
            this.lsvSearchResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvSearchResult_MouseDoubleClick);
            // 
            // imgLargeIcon
            // 
            this.imgLargeIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLargeIcon.ImageStream")));
            this.imgLargeIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLargeIcon.Images.SetKeyName(0, "Folder 64 X 64.png");
            this.imgLargeIcon.Images.SetKeyName(1, "Open Folder 64 X 64.png");
            this.imgLargeIcon.Images.SetKeyName(2, "Document 64 X 64.png");
            // 
            // imgSmallIcon
            // 
            this.imgSmallIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSmallIcon.ImageStream")));
            this.imgSmallIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSmallIcon.Images.SetKeyName(0, "Folder");
            this.imgSmallIcon.Images.SetKeyName(1, "Open Folder");
            this.imgSmallIcon.Images.SetKeyName(2, "Document");
            // 
            // imglIcons
            // 
            this.imglIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglIcons.ImageStream")));
            this.imglIcons.TransparentColor = System.Drawing.Color.White;
            this.imglIcons.Images.SetKeyName(0, "Directory.gif");
            this.imglIcons.Images.SetKeyName(1, "DirectoryOpen.gif");
            this.imglIcons.Images.SetKeyName(2, "Document.gif");
            this.imglIcons.Images.SetKeyName(3, "Directory.png");
            this.imglIcons.Images.SetKeyName(4, "DirectoryOpen.png");
            this.imglIcons.Images.SetKeyName(5, "Document.png");
            this.imglIcons.Images.SetKeyName(6, "Down.gif");
            this.imglIcons.Images.SetKeyName(7, "Up.gif");
            // 
            // imgMisc
            // 
            this.imgMisc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMisc.ImageStream")));
            this.imgMisc.TransparentColor = System.Drawing.Color.White;
            this.imgMisc.Images.SetKeyName(0, "Dot.gif");
            // 
            // SearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsvSearchResult);
            this.Name = "SearchResult";
            this.Size = new System.Drawing.Size(613, 491);
            this.Load += new System.EventHandler(this.SearchResult_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvSearchResult;
        private System.Windows.Forms.ImageList imglIcons;
        private System.Windows.Forms.ImageList imgSmallIcon;
        private System.Windows.Forms.ImageList imgLargeIcon;
        private System.Windows.Forms.ImageList imgMisc;
    }
}
