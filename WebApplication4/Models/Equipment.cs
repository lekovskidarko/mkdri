using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatalogName { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Datasheet { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public Laboratory Laboratory { get; set; }
    }
}
