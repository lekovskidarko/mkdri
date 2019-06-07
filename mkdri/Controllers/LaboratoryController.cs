using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKDRI.Dtos;
using MKDRI.Dtos.Requests;
using MKDRI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKDRI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryController : ControllerBase
    {
        ILaboratoryService laboratoryService;

        public LaboratoryController(ILaboratoryService laboratoryService)
        {
            this.laboratoryService = laboratoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<GeoPoint<LaboratoryDto>>> GetAll([FromQuery(Name = "slon")] double startingLongitude = 20.45,
            [FromQuery(Name = "elon")] double endingLongitude = 23.02, [FromQuery(Name = "slat")] double startingLatitude = 40.85,
            [FromQuery(Name = "elat")] double endingLatitude = 42.37)
        {
            return await laboratoryService.GetAllAsync(startingLatitude, endingLatitude, startingLongitude, endingLongitude);
        }

        [HttpGet("{id}")]
        public async Task<LaboratoryDetailsDto> GetLaboratoryByIdAsync([FromRoute] int Id)
        {
            return await laboratoryService.GetByIdAsync(Id);
        }

        [Authorize]
        [HttpPut]
        public async Task<bool> CreateLaboratoryAsync([FromBody] CreateLaboratoryRequest request)
        {
            return await laboratoryService.CreateLaboratoryAsync(request);
        }

        [Authorize]
        [HttpPut("{id}/equipment")]
        public async Task<bool> CreateEquipmentAsync([FromRoute]int id, [FromBody] CreateEquipmentRequest request)
        {
            return await laboratoryService.CreateEquipmentAsync(id, request);
        }

        [Authorize]
        [HttpDelete("{labid}/equipment/{equipmentid}")]
        public async Task<bool> DeleteEquipmentAsync([FromRoute]int labid, [FromRoute] int equipmentid)
        {
            return await laboratoryService.DeleteEquipmentAsync(labid, equipmentid);
        }


        [Authorize]
        [HttpPut("{id}/services")]
        public async Task<bool> CreateServiceAsync([FromRoute]int id, [FromBody] CreateServiceRequest request)
        {
            return await laboratoryService.CreateServiceAsync(id, request);
        }

        [Authorize]
        [HttpDelete("{labid}/services/{serviceid}")]
        public async Task<bool> DeleteServiceAsync([FromRoute]int labid, [FromRoute] int serviceid)
        {
            return await laboratoryService.DeleteServiceAsync(labid, serviceid);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<bool> DeleteLaboratoryByIdAsync([FromRoute] int Id)
        {
            return await laboratoryService.DeleteByIdAsync(Id);
        }

        [Authorize]
        [HttpPut("{id}/contactinformation")]
        public async Task<bool> CreateContactInformationAsync([FromRoute]int id, [FromBody] CreateContactInformationRequest request)
        {
            return await laboratoryService.CreateContactInformationAsync(id, request);
        }
    }
}
