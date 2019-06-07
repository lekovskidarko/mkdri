namespace MKDRI.Models
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public ContactInformationType Type { get; set; }
        public string Content { get; set; }
        public int? OrganisationId { get; set; }
        public virtual Organisation Organisation { get; internal set; }
        public int? LaboratoryId { get; set; }
        public virtual Laboratory Laboratory { get; internal set; }
    }
}
