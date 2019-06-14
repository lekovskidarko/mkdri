using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public virtual User Director { get; set; }
        public virtual List<ContactInformation> ContactInformation { get; set; }
        public virtual List<Laboratory> Laboratories { get; set; }
        public virtual List<OrganisationPermission> Permissions { get; set;  }
    }
}
