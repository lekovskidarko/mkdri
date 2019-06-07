using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Dtos.Requests
{
    public class CreateServiceRequest
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Persons { get; set; }
    }
}
