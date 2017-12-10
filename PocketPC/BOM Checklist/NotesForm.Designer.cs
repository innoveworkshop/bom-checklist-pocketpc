namespace Production_Assistant {
	partial class NotesForm {
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
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.mnuDelete = new System.Windows.Forms.MenuItem();
			this.mnuSave = new System.Windows.Forms.MenuItem();
			this.cmbNotes = new System.Windows.Forms.ComboBox();
			this.txtNote = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.Add(this.mnuNew);
			this.mnuMain.MenuItems.Add(this.mnuDelete);
			this.mnuMain.MenuItems.Add(this.mnuSave);
			// 
			// mnuNew
			// 
			this.mnuNew.Text = "New";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// mnuDelete
			// 
			this.mnuDelete.Text = "Delete";
			this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
			// 
			// mnuSave
			// 
			this.mnuSave.Text = "Save";
			this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
			// 
			// cmbNotes
			// 
			this.cmbNotes.Location = new System.Drawing.Point(3, 3);
			this.cmbNotes.Name = "cmbNotes";
			this.cmbNotes.Size = new System.Drawing.Size(234, 22);
			this.cmbNotes.TabIndex = 0;
			this.cmbNotes.SelectedIndexChanged += new System.EventHandler(this.cmbNotes_SelectedIndexChanged);
			// 
			// txtNote
			// 
			this.txtNote.AcceptsReturn = true;
			this.txtNote.AcceptsTab = true;
			this.txtNote.Location = new System.Drawing.Point(3, 31);
			this.txtNote.Multiline = true;
			this.txtNote.Name = "txtNote";
			this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNote.Size = new System.Drawing.Size(234, 234);
			this.txtNote.TabIndex = 2;
			// 
			// NotesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.txtNote);
			this.Controls.Add(this.cmbNotes);
			this.Menu = this.mnuMain;
			this.Name = "NotesForm";
			this.Text = "Notes";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem mnuDelete;
		private System.Windows.Forms.MenuItem mnuSave;
		private System.Windows.Forms.ComboBox cmbNotes;
		private System.Windows.Forms.TextBox txtNote;
	}
}