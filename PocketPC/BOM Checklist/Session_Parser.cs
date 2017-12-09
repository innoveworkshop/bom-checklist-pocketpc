using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Production_Assistant {
	class Session_Parser {
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
		 * Populates the session categories array.
		 */
		private void PopulateCategories() {
			XmlNodeList items = project["categories"].SelectNodes("category");
			for (int i = 0; i < items.Count; i++) {
				session.Categories.Add(items[i].InnerText);
			}

			string str = "";
			for (int i = 0; i < session.Categories.Count; i++) {
				str += session.Categories[i] + "\r\n";
			}

			System.Windows.Forms.MessageBox.Show(str);
		}
	}
}
