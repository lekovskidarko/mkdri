using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models
{
    public class OrganisationPermission
    {
        public int OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
