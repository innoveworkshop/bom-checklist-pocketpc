using System;
using System.Collections.Generic;
using System.Text;

namespace Production_Assistant {
	class Session {
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

		public void AddProjectInfo(string name, string value) {
			this.ProjectInfo.Add(name, value);
		}
	}
}
