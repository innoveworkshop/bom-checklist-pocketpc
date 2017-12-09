using System;
using System.Collections.Generic;
using System.Text;

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
	}
}
