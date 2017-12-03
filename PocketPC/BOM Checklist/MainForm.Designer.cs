namespace BOM_Checklist
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mnuMain;

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
            this.mnuMain = new System.Windows.Forms.MainMenu();
            this.mnuMenu = new System.Windows.Forms.MenuItem();
            this.mnuDetail = new System.Windows.Forms.MenuItem();
            this.mnuCheck = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.Add(this.mnuMenu);
            this.mnuMain.MenuItems.Add(this.mnuDetail);
            this.mnuMain.MenuItems.Add(this.mnuCheck);
            // 
            // mnuMenu
            // 
            this.mnuMenu.MenuItems.Add(this.mnuAbout);
            this.mnuMenu.Text = "Menu";
            // 
            // mnuDetail
            // 
            this.mnuDetail.Text = "Detail";
            // 
            // mnuCheck
            // 
            this.mnuCheck.Text = "Check";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Text = "About";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(240, 268);
            this.treeView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.treeView1);
            this.KeyPreview = true;
            this.Menu = this.mnuMain;
            this.Name = "MainForm";
            this.Text = "BOM Checklist";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuMenu;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.MenuItem mnuDetail;
        private System.Windows.Forms.MenuItem mnuCheck;
        private System.Windows.Forms.TreeView treeView1;

    }
}

