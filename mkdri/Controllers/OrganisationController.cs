using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKDRI.Dtos;
using MKDRI.Dtos.Requests;
using MKDRI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController
    {
        IOrganisationService organisationLaboratory;

        public OrganisationController(IOrganisationService laboratoryService)
        {
            this.organisationLaboratory = laboratoryService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<OrganisationDto>> GetAll()
        {
            return await organisationLaboratory.GetAllAsync();
        }

        [Authorize]
        [HttpPut]
        public async Task<bool> CreateOrganisation([FromBody] CreateOrganisationRequest request)
        {
            return await organisationLaboratory.CreateOrganisation(request);
        }

    }
}
