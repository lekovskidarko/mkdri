using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MKDRI.Dtos;
using MKDRI.Dtos.Requests;
using MKDRI.Models;
using MKDRI.Repositories.UnitOfWork;

namespace MKDRI.Services
{
    public class LaboratoryService : ILaboratoryService
    {
        UnitOfWork unitOfWork;

        public LaboratoryService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<bool> CreateLaboratory(CreateLaboratoryRequest request)
        {
            if(request.Name.Length == 0)
            {
                throw new RequestError("Name can not be empty");
            }
            if(request.Name.Length > 50)
            {
                throw new RequestError("Name can not be longer than 50");
            }
            if(request.Latitude < 42.37 || request.Latitude > 40.85 || request.Longitude < 20.45 || request.Longitude > 23.02)
            {
                throw new RequestError("Coordinate is not in Macedonia");
            }
            if(request.City.Length == 0)
            {
                throw new RequestError("City name can not be empty");
            }
            Cities city;
            if (!Enum.TryParse(request.City, out city))
            {
                throw new RequestError("City name not valid");
            }
            
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LaboratoryDto>> GetAllAsync(double startingLatitude, double endingLatitude, double startingLongitude, double endingLongitude)
        {
            List<LaboratoryDto> x = await (from dbLab in unitOfWork.Laboratories
                                                  where dbLab.Latitude >= startingLatitude && dbLab.Latitude <= endingLatitude
                                                  && dbLab.Longitude >= startingLongitude && dbLab.Longitude <= endingLongitude
                                                  select new LaboratoryDto
                                                  {
                                                      Id = dbLab.Id,
                                                      Name = dbLab.Name,
                                                      OrganisationID = dbLab.Organisation.Id,
                                                      OrganisationName = dbLab.Organisation.Name,
                                                      EquipmentNo = dbLab.Equipment.Count,
                                                      ResearchServices = dbLab.ResearchServices.Where(X => X.Type == ResearchServiceType.ResearchService).Count(),
                                                      TechnologicalServices = dbLab.ResearchServices.Where(X => X.Type == ResearchServiceType.TechnologicalService).Count(),
                                                  }).ToListAsync();
                                     
            return x;
        }

        public async Task<LaboratoryDetailsDto> GetById(int Id)
        {
            var lab = await (from dbLab in unitOfWork.Laboratories
                             select new LaboratoryDetailsDto
                             {
                                 Id = dbLab.Id,
                                 Name = dbLab.Name,
                                 Description = dbLab.Description,
                                 Latitude = dbLab.Latitude,
                                 Longitude = dbLab.Longitude,
                                 City = nameof(dbLab.City),
                                 Visits = dbLab.Visits,
                                 Coordinator = new UserDto
                                 {
                                     Id = dbLab.Coordinator.Id,
                                     FirstName = dbLab.Coordinator.FirstName,
                                     LastName = dbLab.Coordinator.LastName
                                 },
                                 Team = dbLab.Team.Select(labTeam => new UserDto
                                 {
                                     Id = labTeam.User.Id,
                                     FirstName = labTeam.User.FirstName,
                                     LastName = labTeam.User.LastName
                                 }).ToList(),
                                 Equipment = dbLab.Equipment.Select(eq => new EquipmentDto
                                 {
                                     Id = eq.Id,
                                     Name = eq.Name,
                                     Description = eq.Description,
                                     CatalogName = eq.CatalogName,
                                     Year = eq.Year,
                                     ImageLink = eq.ImageLink,
                                     Datasheet = eq.Datasheet,
                                     Manufacturer = eq.Manufacturer,
                                     Laboratory = eq.Laboratory.Name
                                    
                                 }).ToList(),
                                 ResearchServices = dbLab.ResearchServices.Select(rs => new ResearchServiceDto
                                 {
                                     Description =rs.Description,
                                     Id = rs.Id,
                                     Name = rs.Name,
                                     Persons = rs.Persons.Select(rsPerson => new UserDto
                                     {
                                         Id = rsPerson.User.Id,
                                         FirstName = rsPerson.User.FirstName,
                                         LastName = rsPerson.User.LastName
                                     }).ToList(),
                                 }).ToList(),
                             }).SingleOrDefaultAsync();
            return lab;
        }
    }
}
