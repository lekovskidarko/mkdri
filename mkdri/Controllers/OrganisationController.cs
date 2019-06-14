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
        IOrganisationService organisationService;

        public OrganisationController(IOrganisationService laboratoryService)
        {
            this.organisationService = laboratoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<OrganisationDto>> GetAll()
        {
            return await organisationService.GetAllAsync();
        }

        [Authorize]
        [HttpPut]
        public async Task<bool> CreateOrganisation([FromBody] CreateOrganisationRequest request)
        {
            return await organisationService.CreateOrganisation(request);
        }

    }
}
