using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models
{
    public class Laboratory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Visits { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public User Coordinator { get; set; }
        public List<User> Team { get; set; }
        public List<Equipment> Equipment { get; set; }
        public List<ResearchService> ResearchServices { get; set; }
    }
}
