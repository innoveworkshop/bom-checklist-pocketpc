using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Production_Assistant {
	public class Session {
		public Dictionary<string, string> ProjectInfo;
		public List<string> Categories;
		public Dictionary<string, List<Component>> Components;

		/**
		 * Session class constructor.
		 */
		public Session() {
			this.ProjectInfo = new Dictionary<string, string>();
			this.Categories = new List<string>();
			this.Components = new Dictionary<string, List<Component>>();
		}

		/**
		 * Adds a project information entry to the dictionary.
		 * 
		 * @param name Entry name.
		 * @param value Entry value.
		 */
		public void AddProjectInfo(string name, string value) {
			this.ProjectInfo.Add(name, value);
		}

		/**
		 * Sets the component checked variable by its ID.
		 * 
		 * @param id Component ID.
		 * @param check Component checked status.
		 */
		public void SetComponentCheckByID(int id, bool check) {
			foreach (KeyValuePair<string, List<Component>> group in Components) {
				for (int i = 0; i < group.Value.Count; i++) {
					if (group.Value[i].ID == id) {
						group.Value[i].Checked = check;
					}
				}
			}
		}

		/**
		 * Exports the current session to the XML format.
		 * 
		 * @return XML Document of the current session.
		 */
		public XmlDocument Export() {
			XmlDocument doc = new XmlDocument();
			XmlNode decNode = doc.CreateXmlDeclaration("1.0", "utf-8", null);
			doc.AppendChild(decNode);
			XmlNode root = doc.CreateElement("project");

			// Project information.
			XmlNode infoNode = doc.CreateElement("info");
			foreach (KeyValuePair<string, string> info in ProjectInfo) {
				XmlNode infoChild = doc.CreateElement(CleanStringForTag(info.Key));
				infoChild.InnerText = info.Value;
				XmlAttribute infoAttribute = doc.CreateAttribute("text");
				infoAttribute.Value = info.Key;
				infoChild.Attributes.Append(infoAttribute);
				infoNode.AppendChild(infoChild);
			}
			root.AppendChild(infoNode);

			// Categories.
			XmlNode categoriesNode = doc.CreateElement("categories");
			for (int i = 0; i < Categories.Count; i++) {
				XmlNode category = doc.CreateElement("category");
				category.InnerText = Categories[i];
				categoriesNode.AppendChild(category);
			}
			root.AppendChild(categoriesNode);

			doc.AppendChild(root);
			return doc;
		}

		/**
		 * Cleans a string to be used as a XML tag.
		 * 
		 * @param s String to be cleaned.
		 * @return Cleaned string.
		 */
		private string CleanStringForTag(string s) {
			string str = "";

			foreach (char c in s) {
				if (((c >= 65) && (c <= 90)) || ((c >= 97) && (c <= 122))) {
					str += c;
				}
			}

			return str.ToLower();
		}
	}
}
