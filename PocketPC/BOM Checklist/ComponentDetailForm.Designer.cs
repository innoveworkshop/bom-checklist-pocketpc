namespace Production_Assistant {
	partial class ComponentDetailForm {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.numQuantity = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbCategory = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lstRefDes = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 15);
			this.label1.Text = "Quantity";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(82, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 15);
			this.label2.Text = "Value";
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(82, 21);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(155, 21);
			this.txtValue.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 15);
			this.label3.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(3, 64);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(234, 21);
			this.txtName.TabIndex = 8;
			// 
			// numQuantity
			// 
			this.numQuantity.Location = new System.Drawing.Point(3, 21);
			this.numQuantity.Name = "numQuantity";
			this.numQuantity.Size = new System.Drawing.Size(73, 22);
			this.numQuantity.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 15);
			this.label4.Text = "Category";
			// 
			// cmbCategory
			// 
			this.cmbCategory.Location = new System.Drawing.Point(3, 106);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new System.Drawing.Size(234, 22);
			this.cmbCategory.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 131);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(146, 15);
			this.label5.Text = "Reference Designators";
			// 
			// lstRefDes
			// 
			this.lstRefDes.Location = new System.Drawing.Point(3, 149);
			this.lstRefDes.Name = "lstRefDes";
			this.lstRefDes.Size = new System.Drawing.Size(234, 114);
			this.lstRefDes.TabIndex = 15;
			// 
			// ComponentDetailForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.lstRefDes);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cmbCategory);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numQuantity);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Menu = this.mnuMain;
			this.Name = "ComponentDetailForm";
			this.Text = "Component Detail";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.NumericUpDown numQuantity;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbCategory;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox lstRefDes;
	}
}