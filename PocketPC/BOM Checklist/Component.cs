using System;
using System.Collections.Generic;
using System.Text;

namespace Production_Assistant {
	public class Component {
		public int ID;
		public bool Checked;
		public int Quantity;
		public string Value;
		public string Name;
		public List<string> RefDes;

		/**
		 * Component class constructor.
		 * 
		 * @param id Component ID.
		 * @param check Component checked?
		 * @param quantity Component quantity.
		 * @param value Component value.
		 * @param name Component name.
		 * @param refdes Reference designator string.
		 */
		public Component(int id, bool check, int quantity, string value, string name, string refdes) {
			this.ID = id;
			this.Checked = check;
			this.Quantity = quantity;
			this.Value = value;
			this.Name = name;
			this.RefDes = SplitRefDes(refdes);
		}

		/**
		 * Component class constructor.
		 * 
		 * @param id Component ID.
		 * @param check Component checked?
		 * @param quantity Component quantity.
		 * @param value Component value.
		 * @param name Component name.
		 * @param refdes Reference designator list.
		 */
		public Component(int id, bool check, int quantity, string value, string name, List<string> refdes) {
			this.ID = id;
			this.Checked = check;
			this.Quantity = quantity;
			this.Value = value;
			this.Name = name;
			this.RefDes = refdes;
		}

		/**
		 * Builds back the original style of reference designator string.
		 * 
		 * @return Reference designators list as a string.
		 */
		public string RefDesString() {
			string str = "";

			for (int i = 0; i < RefDes.Count; i++) {
				str += RefDes[i];

				if (i < RefDes.Count - 1) {
					str += ", ";
				}
			}

			return str;
		}

		/**
		 * Split the reference designator string into a list.
		 * 
		 * @param str Reference designator string.
		 * @return Reference designators list.
		 */
		private List<string> SplitRefDes(string str) {
			List<string> list = new List<string>();
			string[] arr = str.Split(new char[] { ',', ' ' });

			for (int i = 0; i < arr.Length; i++) {
				string tr = arr[i].Trim();

				if (tr != "") {
					list.Add(tr);
				}
			}

			return list;
		}
	}
}
