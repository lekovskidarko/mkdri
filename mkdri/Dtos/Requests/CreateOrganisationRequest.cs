using System.Collections.Generic;

namespace MKDRI.Dtos.Requests
{
    public class CreateOrganisationRequest
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int DirectorId { get; set; }
        public List<CreateContactInformationRequest> ContactInformation { get; set; }
    }
}
