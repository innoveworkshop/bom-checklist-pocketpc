using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Production_Assistant {
	public class Session {
		public Dictionary<string, string> ProjectInfo;
		public List<string> Categories;
		public Dictionary<string, List<Component>> Components;
		public Dictionary<string, string> Notes;

		/**
		 * Session class constructor.
		 */
		public Session() {
			this.ProjectInfo = new Dictionary<string, string>();
			this.Categories = new List<string>();
			this.Components = new Dictionary<string, List<Component>>();
			this.Notes = new Dictionary<string, string>();
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

			// Component groups.
			foreach (KeyValuePair<string, List<Component>> group in Components) {
				XmlNode groupNode = doc.CreateElement("group");
				XmlAttribute groupAttribute = doc.CreateAttribute("category");
				groupAttribute.Value = group.Key;
				groupNode.Attributes.Append(groupAttribute);

				for (int i = 0; i < group.Value.Count; i++) {
					Component component = group.Value[i];

					XmlNode componentNode = doc.CreateElement("component");
					XmlAttribute componentAttribute = doc.CreateAttribute("id");
					componentAttribute.Value = component.ID.ToString();
					componentNode.Attributes.Append(componentAttribute);
					componentAttribute = doc.CreateAttribute("checked");
					componentAttribute.Value = XmlConvert.ToString(component.Checked);
					componentNode.Attributes.Append(componentAttribute);

					XmlNode componentChild = doc.CreateElement("quantity");
					componentChild.InnerText = component.Quantity.ToString();
					componentNode.AppendChild(componentChild);
					componentChild = doc.CreateElement("value");
					componentChild.InnerText = component.Value;
					componentNode.AppendChild(componentChild);
					componentChild = doc.CreateElement("name");
					componentChild.InnerText = component.Name;
					componentNode.AppendChild(componentChild);

					componentChild = doc.CreateElement("references");
					componentAttribute = doc.CreateAttribute("text");
					componentAttribute.Value = component.RefDesString();
					componentChild.Attributes.Append(componentAttribute);
					for (int j = 0; j < component.RefDes.Count; j++) {
						XmlNode refdesNode = doc.CreateElement("refdes");
						refdesNode.InnerText = component.RefDes[j];
						componentChild.AppendChild(refdesNode);
					}
					componentNode.AppendChild(componentChild);

					groupNode.AppendChild(componentNode);
				}

				root.AppendChild(groupNode);
			}

			XmlNode notesNode = doc.CreateElement("notes");
			foreach (KeyValuePair<string, string> note in Notes) {
				XmlNode notesChild = doc.CreateElement("note");
				XmlAttribute childAttribute = doc.CreateAttribute("timestamp");
				childAttribute.Value = note.Key;
				notesChild.Attributes.Append(childAttribute);
				notesChild.InnerText = note.Value;
				notesNode.AppendChild(notesChild);
			}
			root.AppendChild(notesNode);

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
