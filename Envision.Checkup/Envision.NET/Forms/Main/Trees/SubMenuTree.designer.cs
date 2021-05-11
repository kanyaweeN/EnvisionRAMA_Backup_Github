namespace RIS.Forms.Main.Trees
{
    partial class SubMenuTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubMenuTree));
            this.treeSubMenu = new System.Windows.Forms.TreeView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeSubMenu
            // 
            this.treeSubMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSubMenu.ImageIndex = 0;
            this.treeSubMenu.ImageList = this.ImageList;
            this.treeSubMenu.Location = new System.Drawing.Point(0, 0);
            this.treeSubMenu.Name = "treeSubMenu";
            this.treeSubMenu.SelectedImageIndex = 0;
            this.treeSubMenu.ShowRootLines = false;
            this.treeSubMenu.Size = new System.Drawing.Size(227, 234);
            this.treeSubMenu.TabIndex = 0;
            this.treeSubMenu.DoubleClick += new System.EventHandler(this.treeMailBox_DoubleClick);
            this.treeSubMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMailBox_AfterSelect);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "icon03.png");
            this.ImageList.Images.SetKeyName(1, "Drafts.bmp");
            this.ImageList.Images.SetKeyName(2, "Outbox.bmp");
            this.ImageList.Images.SetKeyName(3, "Recycle.bmp");
            this.ImageList.Images.SetKeyName(4, "Send.bmp");
            // 
            // SubMenuTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeSubMenu);
            this.Name = "SubMenuTree";
            this.Size = new System.Drawing.Size(227, 234);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeSubMenu;
        private System.Windows.Forms.ImageList ImageList;
    }
}
