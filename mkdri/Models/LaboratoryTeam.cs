using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models
{
    public class LaboratoryTeam
    {
        public int LaboratoryId { get; set; }
        public virtual Laboratory Laboratory { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
