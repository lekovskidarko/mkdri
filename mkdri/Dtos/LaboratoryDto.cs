using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Dtos
{
    public class LaboratoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrganisationName { get; set; }
        public int OrganisationID { get; set; }
        public int EquipmentNo { get; set; }
        public int ResearchServices { get; set; }
        public int TechnologicalServices { get; set; }
    }
}
