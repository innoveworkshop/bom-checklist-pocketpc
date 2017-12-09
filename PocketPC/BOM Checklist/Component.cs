using System;
using System.Collections.Generic;
using System.Text;

namespace Production_Assistant {
	class Component {
		public int ID;
		public bool Checked;
		public int Quantity;
		public string Value;
		public string Name;
		public string RefDes;  // TODO: Change this to a list.

		/**
		 * Component class constructor.
		 */
		public Component(int id, bool check, int quantity, string value, string name, string refdes) {
			this.ID = id;
			this.Checked = check;
			this.Quantity = quantity;
			this.Value = value;
			this.Name = name;
			this.RefDes = refdes;
		}
	}
}
