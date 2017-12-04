using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class Bird
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        Entity Order { get; set; }
        Entity Family { get; set; }
        Entity Genus { get; set; }
        Entity Specie { get; set; }
        string CommonName { get; set; }
        string BinomialName { get; set; }
        List<string> Habitat { get; set; }
        List<string> Region { get; set; }
    }
}
