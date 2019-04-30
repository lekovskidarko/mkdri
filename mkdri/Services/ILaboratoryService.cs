using MKDRI.Dtos;
using MKDRI.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Services
{
    public interface ILaboratoryService
    {
        Task<IEnumerable<LaboratoryDto>> GetAllAsync(double startingLatitude, double endingLatitude, double startingLongitude, double endingLongitude);
        Task<LaboratoryDetailsDto> GetById(int Id);
        Task<bool> CreateLaboratory(CreateLaboratoryRequest request);
    }
}
