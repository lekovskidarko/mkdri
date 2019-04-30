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
        public async Task<IEnumerable<LaboratoryDto>> GetAll([FromQuery(Name = "slon")] double startingLongitude,
            [FromQuery(Name = "elon")] double endingLongitude, [FromQuery(Name ="slat")] double startingLatitude,
            [FromQuery(Name ="elat")] double endingLatitude)
        { 
            return await laboratoryService.GetAllAsync(startingLatitude, endingLatitude, startingLongitude, endingLongitude);
        }

        
        [HttpPut]
        public async Task<bool> CreateLaboratory([FromBody] CreateLaboratoryRequest request)
        {
            return await laboratoryService.CreateLaboratory(request);
        } 

        [HttpGet("{id}")]
        public async Task<LaboratoryDetailsDto> GetLaboratoryById([FromRoute] int Id)
        {
            return await laboratoryService.GetById(Id);
        }

    }
}
