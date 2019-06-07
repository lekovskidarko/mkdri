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

        public int City { get; private set; }

        public async Task<bool> CreateEquipmentAsync(int laboratoryId, CreateEquipmentRequest request)
        {
            if (request.Name.Length == 0)
            {
                throw new RequestError("Name can not be empty");
            }
            if (request.Name.Length > 200)
            {
                throw new RequestError("Name can not be longer than 200");
            }
            if (request.CatalogName != null && request.CatalogName.Length > 200)
            {
                throw new RequestError("Catalog name can not be longer than 200");
            }
            if (request.Manufacturer != null && request.Manufacturer.Length > 200)
            {
                throw new RequestError("Manufacturer name can not be longer than 200");
            }
            if (request.Datasheet != null && request.Datasheet.Length > 300)
            {
                throw new RequestError("Datasheet can not be longer than 300");
            }
            if(request.Year > DateTime.Now.Year)
            {
                throw new RequestError("Invalid year of produciton");
            }
            Laboratory laboratory = await unitOfWork.Laboratories.Where(l => l.Id == laboratoryId).SingleOrDefaultAsync();
            if (laboratory == default(Laboratory))
            {
                throw new RequestError("Non existing laboratory");
            }
            Equipment equipment = new Equipment
            {
                Laboratory = laboratory,
                Name = request.Name,
                Year = request.Year,
                CatalogName = request.CatalogName,
                Datasheet = request.Datasheet,
                ImageLink = request.ImageLink,
                Manufacturer = request.Manufacturer,
                Description = request.Description,
            };
            laboratory.Equipment.Add(equipment);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> CreateLaboratoryAsync(CreateLaboratoryRequest request)
        {
            if(request.Name.Length == 0)
            {
                throw new RequestError("Name can not be empty");
            }
            if(request.Name.Length > 50)
            {
                throw new RequestError("Name can not be longer than 50");
            }
            if(request.Latitude > 42.37 || request.Latitude < 40.85 || request.Longitude < 20.45 || request.Longitude > 23.02)
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
            List<ContactInformation> ci = new List<ContactInformation>();
            foreach (CreateContactInformationRequest req in request.ContactInformation)
            {
                string res = req.Validate();
                if(res != "")
                {
                    throw new RequestError(res);
                }
                var temp = new ContactInformation
                {
                    Content = req.Content,
                    Type = Enum.Parse<ContactInformationType>(req.Type, true)
                };
                unitOfWork.ContactInformation.Add(temp);
                ci.Add(temp);
            }
            User coordinator = await unitOfWork.Users.Where(u => u.Id == request.CoordinatorId).SingleOrDefaultAsync();
            if(coordinator == default(User))
            {
                throw new RequestError("Non-existing coordinator");
            }
            List<User> team = new List<User>();
            foreach (int teamMember in request.Team)
            {
                var user = await unitOfWork.Users.Where(u => u.Id == teamMember).SingleOrDefaultAsync();
                if (user == default(User))
                {
                    throw new RequestError("Team member does not exist!");
                }
                team.Add(user);
            }
            Organisation organisation = await unitOfWork.Organisation.Where(o => o.Id == request.OrganisationId).SingleOrDefaultAsync();
            if(organisation == default(Organisation))
            {
                throw new RequestError("Non existing organisation");
            }
            Laboratory lab = new Laboratory
            {
                Name = request.Name,
                Description = request.Description,
                Organisation = organisation,
                Coordinator = coordinator,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                City = city,
                Visits = 0,
                ContactInformation = ci,
            };
            List<LaboratoryTeam> teamMembers = team.Select(t => new LaboratoryTeam { Laboratory = lab, User = t }).ToList();
            lab.Team = teamMembers;
            unitOfWork.Laboratories.Add(lab);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> CreateServiceAsync(int laboratoryId, CreateServiceRequest request)
        {
            ResearchServiceType type;
            if(!Enum.TryParse(request.Type, true, out type))
            {
                throw new RequestError("Service type is invalid!");
            }
            if (request.Name.Length == 0)
            {
                throw new RequestError("Name can not be empty");
            }
            if (request.Name.Length > 200)
            {
                throw new RequestError("Name can not be longer than 200");
            }
            Laboratory laboratory = await unitOfWork.Laboratories.Where(l => l.Id == laboratoryId).SingleOrDefaultAsync();
            if (laboratory == default(Laboratory))
            {
                throw new RequestError("Non existing laboratory");
            }
            List<User> team = new List<User>();
            foreach (int teamMember in request.Persons)
            {
                var user = await unitOfWork.Users.Where(u => u.Id == teamMember).SingleOrDefaultAsync();
                if (user == default(User))
                {
                    throw new RequestError("Team member does not exist!");
                }
                team.Add(user);
            }
            ResearchService researchService = new ResearchService
            {
                Laboratory = laboratory,
                Description = request.Description,
                Name = request.Name,
                Type = type
            };
            researchService.Persons = team.Select(t => new ResearchServicePerson { User = t, ResearchService = researchService}).ToList();
            laboratory.ResearchServices.Add(researchService);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<GeoPoint<LaboratoryDto>>> GetAllAsync(double startingLatitude, double endingLatitude, double startingLongitude, double endingLongitude)
        {
            List<GeoPoint<LaboratoryDto>> labs = await (from dbLab in unitOfWork.Laboratories
                                                  where dbLab.Latitude >= startingLatitude && dbLab.Latitude <= endingLatitude
                                                  && dbLab.Longitude >= startingLongitude && dbLab.Longitude <= endingLongitude
                                                  select new GeoPoint<LaboratoryDto>(dbLab.Latitude, dbLab.Longitude, new LaboratoryDto
                                                  {
                                                      Id = dbLab.Id,
                                                      Name = dbLab.Name,
                                                      OrganisationID = dbLab.Organisation.Id,
                                                      OrganisationName = dbLab.Organisation.Name,
                                                      EquipmentNo = dbLab.Equipment.Count,
                                                      ResearchServices = dbLab.ResearchServices.Where(X => X.Type == ResearchServiceType.ResearchService).Count(),
                                                      TechnologicalServices = dbLab.ResearchServices.Where(X => X.Type == ResearchServiceType.TechnologicalService).Count(),
                                                  })).ToListAsync();
                                     
            return labs;
        }

        public async Task<LaboratoryDetailsDto> GetByIdAsync(int id)
        {
            var lab = await (from dbLab in unitOfWork.Laboratories
                             where dbLab.Id == id
                             select new LaboratoryDetailsDto
                             {
                                 Id = dbLab.Id,
                                 Name = dbLab.Name,
                                 Description = dbLab.Description,
                                 Latitude = dbLab.Latitude,
                                 Longitude = dbLab.Longitude,
                                 City = nameof(dbLab.City),
                                 Visits = dbLab.Visits,
                                 ContactInformation = dbLab.ContactInformation.Select(contactInfo => new ContactInformationDto
                                 {
                                     Id = contactInfo.Id,
                                     Content = contactInfo.Content,
                                     Type = nameof(contactInfo.Type)
                                 }).ToList(),
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

        public async Task<bool> DeleteByIdAsync(int id)
        {
            Laboratory laboratory = await unitOfWork.Laboratories.Where(lab => lab.Id == id).SingleOrDefaultAsync();
            if (laboratory == default(Laboratory))
                throw new RequestError(404, "Laboratory does not exist!");
            unitOfWork.Laboratories.Remove(laboratory);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteEquipmentAsync(int labid, int equipmentid)
        {
            Laboratory laboratory = await unitOfWork.Laboratories.Where(l => l.Id == labid).SingleOrDefaultAsync();
            Equipment equipment = laboratory.Equipment.Where(eq => eq.Id == equipmentid).SingleOrDefault();
            if (equipment == default(Equipment))
                throw new RequestError(404, "Equipment does not exist!");
            laboratory.Equipment.Remove(equipment);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteServiceAsync(int labid, int serviceid)
        {
            Laboratory laboratory = await unitOfWork.Laboratories.Where(l => l.Id == labid).SingleOrDefaultAsync();
            ResearchService researchService = laboratory.ResearchServices.Where(rs => rs.Id == serviceid).SingleOrDefault();
            if (researchService == default(ResearchService))
                throw new RequestError(404, "Equipment does not exist!");
            laboratory.ResearchServices.Remove(researchService);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> CreateContactInformationAsync(int id, CreateContactInformationRequest request)
        {
            Laboratory laboratory = await unitOfWork.Laboratories.Where(l => l.Id == id).SingleOrDefaultAsync();
            if (laboratory == default(Laboratory))
            {
                throw new RequestError("Laboratory doesn't exist!");
            }
            string res = request.Validate();
            if (res != "")
            {
                throw new RequestError(res);
            }
            var temp = new ContactInformation
            {
                Content = request.Content,
                Type = Enum.Parse<ContactInformationType>(request.Type, true)
            };
            laboratory.ContactInformation.Add(temp);
            await unitOfWork.SaveAsync();
            return true;
        }
    }
}
