using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class Entity
    {
        public string uri { get; set; }
        public string resourceName { get; set; }
        public int childNumber { get; set; }
        //public list<Properties> properties { get; set; }
    }
}
