using GeoAPI.Geometries;
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
        public virtual List<ContactInformation> ContactInformation { get; set; }
        public virtual User Coordinator { get; set; }
        public virtual List<LaboratoryTeam> Team { get; set; }
        public virtual List<Equipment> Equipment { get; set; }
        public virtual List<ResearchService> ResearchServices { get; set; }
    }
}
