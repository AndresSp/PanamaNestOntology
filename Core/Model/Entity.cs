using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class Entity
    {
        private List<string> childsName = new List<string>();
        private List<string> childsUri = new List<string>();

        public string Uri { get; set; }
        public string Name { get; set; }
        public string ParentUri { get; set; }
        public string ParentName { get; set; }
        public List<string> ChildsUri
        {
            get
            { return this.childsUri; }
            set
            { this.childsUri = value; }
        }
        public List<string> ChildsName
        {
            get
            { return this.childsName; }
            set
            { this.childsName = value; }

        }
    }
}
