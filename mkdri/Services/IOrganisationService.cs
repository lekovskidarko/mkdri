using System.Collections.Generic;
using System.Threading.Tasks;
using MKDRI.Dtos;
using MKDRI.Dtos.Requests;

namespace MKDRI.Services
{
    public interface IOrganisationService
    {
        Task<IEnumerable<OrganisationDto>> GetAllAsync();
        Task<bool> CreateOrganisation(CreateOrganisationRequest request);
    }
}
