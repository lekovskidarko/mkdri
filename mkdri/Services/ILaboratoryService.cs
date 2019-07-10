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
        Task<IEnumerable<GeoPoint<LaboratoryDto>>> GetAllAsync(double startingLatitude, double endingLatitude, double startingLongitude, double endingLongitude);
        Task<LaboratoryDetailsDto> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> CreateLaboratoryAsync(CreateLaboratoryRequest request);
        Task<bool> CreateServiceAsync(int laboratoryId, CreateServiceRequest request);
        Task<bool> CreateEquipmentAsync(int laboratoryId, CreateEquipmentRequest request);
        Task<bool> DeleteEquipmentAsync(int labid, int equipmentid);
        Task<bool> DeleteServiceAsync(int labid, int serviceid);
        Task<bool> GiveUserPermission(int labid, int userId);
        Task<bool> RemoveUserPermission(int labid, int userId);
        Task<bool> CreateContactInformationAsync(int id, CreateContactInformationRequest request);
    }
}
