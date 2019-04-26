using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models
{ 
    public enum ContactInformationType
    {
        Phone,
        Fax,
        Zip,
        Adress,
        Email,
        Website
    }
    public enum ResearchServiceType
    {
        ResearchService
    }
    public enum UserRole
    {
        Normal = 0,
        Company, 
        Moderator,
        Administrator
    }
}
