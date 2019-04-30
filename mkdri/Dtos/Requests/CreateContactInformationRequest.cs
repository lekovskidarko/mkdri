using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Dtos.Requests
{
    public class CreateContactInformationRequest
    {
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
