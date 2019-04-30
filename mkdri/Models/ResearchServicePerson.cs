using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models
{
    public class ResearchServicePerson
    {
        public int ResearchServiceId { get; set; }
        public virtual ResearchService  ResearchService { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
