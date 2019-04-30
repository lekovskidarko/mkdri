using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Dtos.Requests
{
    public class CreateLaboratoryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string Municipality { get; set; }
        public virtual List<CreateContactInformationRequest> ContactInformation { get; set; }
        public int CoordinatorId { get; set; }
        public virtual List<int> Team { get; set; }
        public int OrganisationId { get; set; }
    }

}
