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
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.mnuDetail = new System.Windows.Forms.MenuItem();
			this.treeComponents = new System.Windows.Forms.TreeView();
			this.mnuLoadBOM = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuSave = new System.Windows.Forms.MenuItem();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.Add(this.mnuMenu);
			this.mnuMain.MenuItems.Add(this.mnuDetail);
			// 
			// mnuMenu
			// 
			this.mnuMenu.MenuItems.Add(this.mnuLoadBOM);
			this.mnuMenu.MenuItems.Add(this.mnuSave);
			this.mnuMenu.MenuItems.Add(this.menuItem2);
			this.mnuMenu.MenuItems.Add(this.mnuAbout);
			this.mnuMenu.Text = "Menu";
			// 
			// mnuAbout
			// 
			this.mnuAbout.Text = "About";
			// 
			// mnuDetail
			// 
			this.mnuDetail.Text = "Detail";
			// 
			// treeComponents
			// 
			this.treeComponents.CheckBoxes = true;
			this.treeComponents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeComponents.Location = new System.Drawing.Point(0, 0);
			this.treeComponents.Name = "treeComponents";
			this.treeComponents.Size = new System.Drawing.Size(240, 268);
			this.treeComponents.TabIndex = 0;
			// 
			// mnuLoadBOM
			// 
			this.mnuLoadBOM.Text = "Load BOM File";
			this.mnuLoadBOM.Click += new System.EventHandler(this.mnuLoadBOM_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Text = "-";
			// 
			// mnuSave
			// 
			this.mnuSave.Text = "Save Session";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.treeComponents);
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
        private System.Windows.Forms.TreeView treeComponents;
        private System.Windows.Forms.MenuItem mnuLoadBOM;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuSave;
		private System.Windows.Forms.OpenFileDialog dlgOpen;

    }
}

