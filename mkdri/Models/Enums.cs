﻿using System;
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
        Address,
        Email,
        Website
    }
    public enum ResearchServiceType
    {
        ResearchService,
        TechnologicalService
    }
    public enum UserRole
    {
        Normal = 0,
        Company, 
        Moderator,
        Administrator
    }
    public enum Cities
    {
        Skopje_Centar = 0,
        Skopje_Aerodrom = 1,
        Skopje_Karpos = 2,
        Bitola = 3
    }
}
