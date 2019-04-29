using Microsoft.AspNetCore.Mvc;
using MKDRI.Dtos;
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

        // GET api/user
        [HttpGet]
        public async Task<IEnumerable<LaboratoryDto>> GetAll()
        {
            return await laboratoryService.GetAllAsync();
        }
    }
}
