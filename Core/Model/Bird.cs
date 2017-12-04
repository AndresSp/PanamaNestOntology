using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class Bird
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public Entity Order { get; set; }
        public Entity Family { get; set; }
        public Entity Genus { get; set; }
        public Entity Specie { get; set; }
        public string CommonName { get; set; }
        public string BinomialName { get; set; }
        public List<string> Habitat { get; set; }
        public List<string> Region { get; set; }
        public string Size { get; set; }

        public Bird()
        {
            Habitat = new List<string>();
            Region = new List<string>();
        }
    }
}
