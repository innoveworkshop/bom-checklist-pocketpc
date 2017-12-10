using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Production_Assistant {
	public class Session_Parser {
		private XmlDocument doc;
		private XmlNode project;
		private Session session;

		/**
		 * BOM parser constructor.
		 * 
		 * @param session Session class.
		 */
		public Session_Parser(Session session) {
			this.doc = new XmlDocument();
			this.session = session;
		}

		/**
		 * Loads the XML BOM file into the internal data structure.
		 * 
		 * @param filename XML file location.
		 */
		public void LoadXML(string filename) {
			doc.Load(filename);
			project = doc["project"];

			PopulateProjectInfo();
			PopulateCategories();
			PopulateComponents();
			PopulateNotes();
		}

		/**
		 * Populates the session project information dictionary.
		 */
		private void PopulateProjectInfo() {
			XmlNodeList items = project["info"].SelectNodes("*");
			for (int i = 0; i < items.Count; i++) {
				session.AddProjectInfo(items[i].Attributes["text"].Value, items[i].InnerText);
			}
		}

		/**
		 * Populates the session categories list.
		 */
		private void PopulateCategories() {
			XmlNodeList items = project["categories"].SelectNodes("category");
			for (int i = 0; i < items.Count; i++) {
				session.Categories.Add(items[i].InnerText);
			}
		}

		/**
		 * Populate the session components dictionary.
		 */
		private void PopulateComponents() {
			XmlNodeList groups = project.SelectNodes("group");
			for (int i = 0; i < groups.Count; i++) {
				List<Component> components = new List<Component>();
				XmlNodeList items = groups[i].SelectNodes("component");

				for (int j = 0; j < items.Count; j++) {
					int id = int.Parse(items[j].Attributes["id"].Value);
					bool check = XmlConvert.ToBoolean(items[j].Attributes["checked"].Value);
					int quantity = int.Parse(items[j]["quantity"].InnerText);
					string value = items[j]["value"].InnerText;
					string name = items[j]["name"].InnerText;
					string refdes = items[j]["references"].Attributes["text"].Value;

					components.Add(new Component(id, check, quantity, value, name, refdes));
				}

				session.Components.Add(groups[i].Attributes["category"].Value, components);
			}

		}

		/**
		 * Populate the session notes directory.
		 */
		private void PopulateNotes() {
			XmlNodeList items = project["notes"].SelectNodes("note");
			for (int i = 0; i < items.Count; i++) {
				session.Notes.Add(items[i].Attributes["timestamp"].Value, items[i].InnerText);
			}
		}
	}
}
