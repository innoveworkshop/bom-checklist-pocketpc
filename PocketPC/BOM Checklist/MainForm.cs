using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Production_Assistant {
	public partial class MainForm : Form {
		private Session session;
		private Session_Parser SessionParser;

		/**
		 * Main form constructor.
		 */
		public MainForm() {
			InitializeComponent();
			statusBar.Text = "Welcome!";

			// Initialize the session and parser.
			session = new Session();
			SessionParser = new Session_Parser(session);

			SessionParser.LoadXML("\\Storage Card\\test_ppc.xml");
			statusBar.Text = "Loaded session: \\Storage Card\\test.xml";

			session.Export().Save("\\Storage Card\\test_ppc.xml");
			statusBar.Text = "Exported";

			UpdateComponentTree();
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
			UpdateComponentTree();
			statusBar.Text = "Loaded session: " + dlgOpen.FileName;
		}

		/**
		 * Shows the project information screen.
		 */
		private void mnuInfo_Click(object sender, EventArgs e) {
			ProjectInfoForm form = new ProjectInfoForm(session);
			form.ShowDialog();
		}

		/**
		 * Populates the components tree view.
		 */
		private void UpdateComponentTree() {
			treeComponents.Nodes.Clear();
			int current_group = 0;

			foreach (KeyValuePair<string, List<Component>> group in session.Components) {
				TreeNode node = new TreeNode(group.Key);
				bool all_checked = true;

				for (int i = 0; i < group.Value.Count; i++) {
					Component component = group.Value[i];
					TreeNode child = new TreeNode();
					string str = component.Quantity.ToString() + "x ";

					if (component.Value != "") {
						str += component.Value + " (" + component.Name + ")";
					} else {
						str += component.Name;
					}

					child.Text = str;
					child.Checked = component.Checked;
					child.Tag = component;

					if (!component.Checked) {
						all_checked = false;
					}

					node.Nodes.Add(child);
				}

				node.Checked = all_checked;
				node.Tag = current_group;
				treeComponents.Nodes.Add(node);
				current_group++;
			}
		}

		/**
		 * Component tree on select event.
		 */
		private void treeComponents_AfterSelect(object sender, TreeViewEventArgs e) {
			if (treeComponents.SelectedNode.Nodes.Count == 0) {
				statusBar.Text = ((Component)treeComponents.SelectedNode.Tag).RefDesString();
			}
		}

		/**
		 * Component tree on check event.
		 */
		private void treeComponents_AfterCheck(object sender, TreeViewEventArgs e) {
			if (e.Node.Nodes.Count == 0) {
				// Component was checked.
				((Component)e.Node.Tag).Checked = e.Node.Checked;
			} else {
				// Group was checked.
				for (int i = 0; i < e.Node.Nodes.Count; i++) {
					e.Node.Nodes[i].Checked = e.Node.Checked;
				}
			}
		}

		/**
		 * Detail button click event.
		 */
		private void mnuDetail_Click(object sender, EventArgs e) {
			if (treeComponents.SelectedNode.Nodes.Count == 0) {
				ComponentDetailForm form = new ComponentDetailForm(session, treeComponents.SelectedNode.Parent.Text, (Component)treeComponents.SelectedNode.Tag);
				form.ShowDialog();
				UpdateComponentTree();
			} else {
				MessageBox.Show("Select a component, not a category", "User Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}
		}

		/**
		 * Show notes menu item click event.
		 */
		private void mnuNotes_Click(object sender, EventArgs e) {
			NotesForm form = new NotesForm(session);
			form.ShowDialog();
		}

		/**
		 * Save session menu item click event.
		 */
		private void mnuSave_Click(object sender, EventArgs e) {
			SaveSession(session.filename);
		}

		/**
		 * Save session as menu item click event.
		 */
		private void mnuSaveAs_Click(object sender, EventArgs e) {
			dlgSave.ShowDialog();
			SaveSession(dlgSave.FileName);
		}

		private void SaveSession(string filename) {
			try {
				session.Export().Save(filename);
				statusBar.Text = "Saved session: " + filename;
			} catch (XmlException ex) {
				if (MessageBox.Show(ex.ToString(), "Error saving session", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.Retry) {
					mnuSave_Click(this, new EventArgs());
				}
			}
		}
	}
}