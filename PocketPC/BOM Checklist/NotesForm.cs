using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Production_Assistant {
	public partial class NotesForm : Form {
		private Session session;

		/**
		 * Notes form constructor.
		 * 
		 * @param session Current session.
		 */
		public NotesForm(Session session) {
			InitializeComponent();

			this.session = session;
			PopulateNotes();

			if (cmbNotes.Items.Count > 0) {
				cmbNotes.SelectedIndex = cmbNotes.Items.Count - 1;
			}
		}
		
		/**
		 * Populate the notes combo box.
		 */
		private void PopulateNotes() {
			cmbNotes.Items.Clear();
			foreach (KeyValuePair<string, string> note in session.Notes) {
				cmbNotes.Items.Add(note.Key);
			}
		}

		/**
		 * Adds a note to the session.
		 * 
		 * @param note Note text.
		 */
		private void AddNote(string note) {
			session.Notes.Add(DateTime.Now.ToString("F"), note);
		}

		/**
		 * Event fired when the selected note changes.
		 */
		private void cmbNotes_SelectedIndexChanged(object sender, EventArgs e) {
			foreach (KeyValuePair<string, string> note in session.Notes) {
				if ((string)cmbNotes.SelectedItem == note.Key) {
					txtNote.Text = note.Value;
				}
			}
		}

		/**
		 * Event fired when the save menu item is clicked.
		 */
		private void mnuSave_Click(object sender, EventArgs e) {
			Dictionary<string, string> tmp = new Dictionary<string, string>(session.Notes);
			foreach (KeyValuePair<string, string> note in tmp) {
				if ((string)cmbNotes.SelectedItem == note.Key) {
					session.Notes.Remove(note.Key);
					session.Notes.Add((string)cmbNotes.SelectedItem, txtNote.Text);
				}
			}
		}

		/**
		 * Event fired when the delete menu item is clicked.
		 */
		private void mnuDelete_Click(object sender, EventArgs e) {
			if (cmbNotes.Items.Count > 0) {
				Dictionary<string, string> tmp = new Dictionary<string, string>(session.Notes);
				foreach (KeyValuePair<string, string> note in tmp) {
					if ((string)cmbNotes.SelectedItem == note.Key) {
						session.Notes.Remove(note.Key);
					}
				}

				txtNote.Text = "";
				PopulateNotes();
				if (cmbNotes.Items.Count > 0) {
					cmbNotes.SelectedIndex = cmbNotes.Items.Count - 1;
				}
			} else {
				MessageBox.Show("Not enough notes available to delete something.", "User Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}
		}

		/**
		 * Event fired when the new menu item is clicked.
		 */
		private void mnuNew_Click(object sender, EventArgs e) {
			AddNote("");
			PopulateNotes();
			cmbNotes.SelectedIndex = cmbNotes.Items.Count - 1;
		}
	}
}