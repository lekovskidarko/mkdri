﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public ContactInformationType Type { get; set; }
        public string Content { get; set; }
    }
}
