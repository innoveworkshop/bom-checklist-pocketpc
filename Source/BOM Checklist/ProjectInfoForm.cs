using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Production_Assistant {
	public partial class ProjectInfoForm : Form {
		private Session session;

		/**
		 * Project information form initializer.
		 * 
		 * @param session Session class.
		 */
		public ProjectInfoForm(Session session) {
			InitializeComponent();
			this.session = session;

			PopulateNamesList();
		}

		/**
		 * Populates the names list.
		 */
		private void PopulateNamesList() {
			lstNames.Items.Clear();

			foreach (KeyValuePair<string, string> info in session.ProjectInfo) {
				lstNames.Items.Add(info.Key);
			}
		}

		/**
		 * Event fired when the selected index of the names list changes.
		 */
		private void lstNames_SelectedIndexChanged(object sender, EventArgs e) {
			foreach (KeyValuePair<string, string> info in session.ProjectInfo) {
				if ((string)lstNames.Items[lstNames.SelectedIndex] == info.Key) {
					txtName.Text = info.Key;
					txtValue.Text = info.Value;
				}
			}
		}

		/**
		 * Event fired when the save menu item gets clicked.
		 */
		private void mnuSave_Click(object sender, EventArgs e) {
			if (txtName.Text == (string)lstNames.Items[lstNames.SelectedIndex]) {
				// Name did not change.
				session.ProjectInfo[(string)lstNames.Items[lstNames.SelectedIndex]] = txtValue.Text;
			} else {
				// Name did change.
				session.ProjectInfo.Remove((string)lstNames.Items[lstNames.SelectedIndex]);
				session.ProjectInfo.Add(txtName.Text, txtValue.Text);
				PopulateNamesList();
			}
		}

		/**
		 * Event used to detect if the enter key was pressed to save the value.
		 */
		private void txtValue_KeyDown(object sender, KeyEventArgs e) {
			if ((e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Enter)) {
				mnuSave_Click(this, new EventArgs());
			}
		}

		/**
		 * Event fired when the delete menu item is clicked.
		 */
		private void mnuDelete_Click(object sender, EventArgs e) {
			session.ProjectInfo.Remove((string)lstNames.Items[lstNames.SelectedIndex]);
			PopulateNamesList();
		}

		/**
		 * Event fired to add a new item to the project information.
		 */
		private void mnuAdd_Click(object sender, EventArgs e) {
			session.ProjectInfo.Add(txtName.Text, txtValue.Text);
			PopulateNamesList();
		}
	}
}