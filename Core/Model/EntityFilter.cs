using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class Filter
    {
        public string propertyName { get; set; }
        public string value { get; set; }
    }

    public class EntityFilter
    {
        public string entity { get; set; }
        public List<Filter> filter { get; set; }
    }
}
