using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class Entity
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public string ParentUri { get; set; }
        public string ParentName { get; set; }
        public List<Entity> Children { get; set; }
        public int ChildsCount { get; set; }

        public Entity()
        {
            Children = new List<Entity>();
        }
    }
}
