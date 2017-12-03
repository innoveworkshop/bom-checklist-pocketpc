using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BOM_Checklist {
	public partial class MainForm : Form {
		private BOM_Parser BOM;

		/**
		 * Main form constructor.
		 */
		public MainForm() {
			InitializeComponent();
			treeComponents.Nodes.Add("Hello wolrd!");

			BOM = new BOM_Parser();
			BOM.LoadXML("\\Storage Card\\test.csv");
		}

		/**
		 * Handles hardware key presses.
		 */
		private void MainForm_KeyDown(object sender, KeyEventArgs e) {
			if ((e.KeyCode == System.Windows.Forms.Keys.Up)) {
				// Up
			}
			if ((e.KeyCode == System.Windows.Forms.Keys.Down)) {
				// Down
			}
			if ((e.KeyCode == System.Windows.Forms.Keys.Left)) {
				// Left
			}
			if ((e.KeyCode == System.Windows.Forms.Keys.Right)) {
				// Right
			}
			if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) {
				// Enter
			}

		}

		/**
		 * Opens the open dialog and loads the BOM file.
		 */
		private void mnuLoadBOM_Click(object sender, EventArgs e) {
			dlgOpen.ShowDialog();
			BOM.LoadXML(dlgOpen.FileName);
		}
	}
}