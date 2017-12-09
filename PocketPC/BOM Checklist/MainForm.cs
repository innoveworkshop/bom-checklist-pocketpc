using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Production_Assistant {
	public partial class MainForm : Form {
		private Session session;
		private Session_Parser SessionParser;

		/**
		 * Main form constructor.
		 */
		public MainForm() {
			InitializeComponent();
			treeComponents.Nodes.Add("Hello wolrd!");//////////////////////
			////////////////////////////////////////////

			session = new Session();
			SessionParser = new Session_Parser(session);
			SessionParser.LoadXML("\\Storage Card\\test.xml");
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
		private void mnuLoad_Click(object sender, EventArgs e) {
			dlgOpen.ShowDialog();
			SessionParser.LoadXML(dlgOpen.FileName);
		}

		private void mnuInfo_Click(object sender, EventArgs e) {
			string str = "";
			foreach (KeyValuePair<string, string> item in session.ProjectInfo) {
				str += item.Key + ": " + item.Value + "\r\n";
			}

			MessageBox.Show(str, "Project Information");
		}
	}
}