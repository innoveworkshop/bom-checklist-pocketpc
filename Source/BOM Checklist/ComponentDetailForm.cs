using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Production_Assistant {
	public partial class ComponentDetailForm : Form {
		private Session session;
		private Component component;
		private string category;

		/**
		 * Component detail form constructor.
		 * 
		 * @param session Session class.
		 * @param category Component category.
		 * @param component Current component.
		 */
		public ComponentDetailForm(Session session, string category, Component component) {
			InitializeComponent();

			this.session = session;
			this.category = category;
			this.component = component;

			PopulateCategories();
			PopulateDetails();
		}

		/**
		 * Populates the category combo box.
		 */
		private void PopulateCategories() {
			cmbCategory.Items.Clear();

			for (int i = 0; i < session.Categories.Count; i++) {
				cmbCategory.Items.Add(session.Categories[i]);
			}
		}

		/**
		 * Populates all the fields.
		 */
		private void PopulateDetails() {
			numQuantity.Value = component.Quantity;
			txtValue.Text = component.Value;
			txtName.Text = component.Name;

			for (int i = 0; i < cmbCategory.Items.Count; i++) {
				if ((string)cmbCategory.Items[i] == category) {
					cmbCategory.SelectedIndex = i;
				}
			}

			lstRefDes.Items.Clear();
			for (int i = 0; i < component.RefDes.Count; i++) {
				lstRefDes.Items.Add(component.RefDes[i]);
			}
		}
	}
}