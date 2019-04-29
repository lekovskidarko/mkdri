using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MKDRI.Dtos;
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

        public async Task<IEnumerable<LaboratoryDto>> GetAllAsync()
        {
            //var kristijan = new User
            //{
            //    FirstName = "Kristijan",
            //    LastName = "Angelovski",
            //    Email = "angelovskik6@gmail.com",
            //    Password = "test"
            //};
            //unitOfWork.Users.Add(kristijan);
            //var test = new User
            //{
            //    FirstName = "test",
            //    LastName = "test",
            //    Email = "test@gmail.com",
            //    Password = "test"
            //};
            //unitOfWork.Users.Add(test);
            //var test2 = new User
            //{
            //    FirstName = "test2",
            //    LastName = "test2",
            //    Email = "test2@gmail.com",
            //    Password = "test"
            //};
            //unitOfWork.Users.Add(test2);
            //var laboratory = new Laboratory
            //{
            //    Name = "testlab",
            //    Description = "primerok",
            //    Longitude = 21.43141,
            //    Latitude = 41.99646,
            //    ResearchServices = { },
            //    Coordinator = kristijan,
            //    Equipment = { },
            //    Visits = 0
            //};
            //laboratory.Team = new List<LaboratoryTeam> { new LaboratoryTeam { Laboratory = laboratory, User = test },
            //                                        new LaboratoryTeam{ Laboratory = laboratory, User = test2 } };
            //unitOfWork.Laboratories.Add(laboratory);
            //await unitOfWork.SaveAsync();
            List<LaboratoryDto> x = await (from dbLab in unitOfWork.Laboratories
                                     select new LaboratoryDto
                                     {
                                             Id = dbLab.Id,
                                             Name = dbLab.Name,
                                             Description = dbLab.Description,
                                             Latitude = dbLab.Latitude,
                                             Longitude = dbLab.Longitude,
                                             Visits = dbLab.Visits,
                                             Coordinator = new UserDto {
                                                 Id = dbLab.Coordinator.Id,
                                                 FirstName = dbLab.Coordinator.FirstName,
                                                 LastName = dbLab.Coordinator.LastName,
                                                 CreatedOn = dbLab.Coordinator.CreatedOn,
                                                 DeletedOn = dbLab.Coordinator.DeletedOn
                                             },
                                             Team = dbLab.Team.Select(labTeam => new UserDto
                                             {
                                                 Id = labTeam.User.Id,
                                                 FirstName = labTeam.User.FirstName,
                                                 LastName = labTeam.User.LastName,
                                                 CreatedOn = labTeam.User.CreatedOn,
                                                 DeletedOn = labTeam.User.DeletedOn
                                             }).ToList(),

                                         }).ToListAsync();
            return x;
        }
    }
}
