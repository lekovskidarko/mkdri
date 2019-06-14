using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MKDRI.Dtos;
using MKDRI.Dtos.Requests;
using MKDRI.Models;
using MKDRI.Repositories.UnitOfWork;
using MKDRI.Services.Auth;

namespace MKDRI.Services
{
    public class OrganisationService : IOrganisationService
    {
        UnitOfWork unitOfWork;
        IAuthService authService;

        public OrganisationService(UnitOfWork unitOfWork, IAuthService authService)
        {
            this.authService = authService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateOrganisation(CreateOrganisationRequest request)
        {
            if (request.Name.Length == 0)
            {
                throw new RequestError("Name can not be empty");
            }
            if (request.Name.Length > 50)
            {
                throw new RequestError("Name can not be longer than 50");
            }
            if(request.Image.Length == 0)
            {
                throw new RequestError("Image can not be empty");
            }
            List<ContactInformation> ci = new List<ContactInformation>();
            foreach (CreateContactInformationRequest req in request.ContactInformation)
            {
                string res = req.Validate();
                if (res != "")
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
            User director = await unitOfWork.Users.Where(u => u.Id == request.DirectorId).SingleOrDefaultAsync();
            if (director == default(User))
            {
                throw new RequestError("Non-existing director");
            }
            var organisation = new Organisation
            {
                Name = request.Name,
                Image = request.Image,
                ContactInformation = ci,
                Director = director,
                Laboratories = new List<Laboratory>(),
                Text = request.Text
            };
            unitOfWork.Organisation.Add(organisation);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<OrganisationDto>> GetAllAsync()
        {
            var organisations = await (from dbOrganisation in unitOfWork.Organisation
                                      select new OrganisationDto
                                      {
                                      }).ToListAsync();
            return organisations;
        }

        public async Task<bool> DeleteOrganisation(int organisationId)
        {
            Organisation organisation = await unitOfWork.Organisation.Where(o => o.Id == organisationId).SingleOrDefaultAsync();
            if (organisation == default(Organisation))
                throw new RequestError(404, "Organisation not found!");
            // AUTHORISATION CHECK
            int myId = authService.CurrentUser.Id;
            if (myId != organisation.Director.Id)
            {
                throw new RequestError(403, "Permission denied!");
            }
            unitOfWork.Organisation.Remove(organisation);
            await unitOfWork.SaveAsync();
            return true;
        }
    }
}
