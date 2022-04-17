namespace AgencyMAnagmentSystem.Models
{
   
    public class ApprovalRequest
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        public DateTime Date { get; set; }
        public string Discription { get; set; }
    }
    public class VizaAuthonticity
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        public DateTime Date { get; set; }
        public string Discription { get; set; }
    }
    public class CocAuthonticity
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        public DateTime Date { get; set; }
        public string Discription { get; set; }
    }
    public class BioData
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        public DateTime Date { get; set; }
        public string Discription { get; set; }
    }
    public class Approved
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        public DateTime Date { get; set; }
        public string Discription { get; set; }
    }
    public class MolsaApprovalLattere
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        public DateTime Date { get; set; }
        public string Discription { get; set; }
    }
}
