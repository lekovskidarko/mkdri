﻿using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Dtos
{
    public class LaboratoryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Visits { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string Municipality { get; set; }
        public UserDto Coordinator { get; set; }
        public List<UserDto> Team { get; set; }
        public List<EquipmentDto> Equipment { get; set; }
        public List<ResearchServiceDto> ResearchServices { get; set; }
        public List<ContactInformationDto> ContactInformation { get; set; }
    }
}
