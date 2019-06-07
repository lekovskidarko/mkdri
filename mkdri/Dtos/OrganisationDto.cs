using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Dtos
{
    public class OrganisationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public virtual UserDto Director { get; set; }
        public virtual List<ContactInformationDto> ContactInformation { get; set; }
        public virtual List<GeoPoint<LaboratoryDto>> Laboratories { get; set; }
    }
}
