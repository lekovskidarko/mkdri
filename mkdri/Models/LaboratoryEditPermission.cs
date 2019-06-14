namespace MKDRI.Models
{
    public class LaboratoryPermission
    {
        public int LaboratoryId { get; set; }
        public virtual Laboratory Laboratory { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
