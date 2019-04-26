using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models
{
    public class ResearchService
    {
        public ResearchServiceType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Laboratory Laboratory { get; set; }
        public List<User> Persons { get; set; }
    }
}
