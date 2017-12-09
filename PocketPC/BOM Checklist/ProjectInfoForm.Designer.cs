namespace Production_Assistant {
	partial class ProjectInfoForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mnuMain;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.mnuAdd = new System.Windows.Forms.MenuItem();
			this.mnuSave = new System.Windows.Forms.MenuItem();
			this.lstNames = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.mnuDelete = new System.Windows.Forms.MenuItem();
			this.txtName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.Add(this.mnuAdd);
			this.mnuMain.MenuItems.Add(this.mnuDelete);
			this.mnuMain.MenuItems.Add(this.mnuSave);
			// 
			// mnuAdd
			// 
			this.mnuAdd.Text = "Add";
			this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
			// 
			// mnuSave
			// 
			this.mnuSave.Text = "Save";
			this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
			// 
			// lstNames
			// 
			this.lstNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstNames.Location = new System.Drawing.Point(3, 3);
			this.lstNames.Name = "lstNames";
			this.lstNames.Size = new System.Drawing.Size(234, 170);
			this.lstNames.TabIndex = 0;
			this.lstNames.SelectedIndexChanged += new System.EventHandler(this.lstNames_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 177);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 15);
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(3, 219);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 15);
			this.label2.Text = "Value";
			// 
			// txtValue
			// 
			this.txtValue.AcceptsReturn = true;
			this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtValue.Location = new System.Drawing.Point(3, 237);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(234, 21);
			this.txtValue.TabIndex = 4;
			this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyDown);
			// 
			// mnuDelete
			// 
			this.mnuDelete.Text = "Delete";
			this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
			// 
			// txtName
			// 
			this.txtName.AcceptsReturn = true;
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(3, 195);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(234, 21);
			this.txtName.TabIndex = 7;
			// 
			// ProjectInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstNames);
			this.Menu = this.mnuMain;
			this.Name = "ProjectInfoForm";
			this.Text = "Project Information";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lstNames;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuItem mnuAdd;
		private System.Windows.Forms.MenuItem mnuSave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.MenuItem mnuDelete;
		private System.Windows.Forms.TextBox txtName;

	}
}