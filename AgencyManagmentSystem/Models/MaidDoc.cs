using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgencyMAnagmentSystem.Models
{
    public class MaidDoc
    {
    }
   
    public class ScannedPassport
    { 
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required]
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Discription { get; set; }
    }
    public class ScannedPoliceClearance
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required]
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Discription { get; set; }
    }
    public class ScannedSigniture
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required]
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Discription { get; set; }
    }
    public class ScannedMedical
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required]
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Discription { get; set; }
    }
    public class ScannedMiniPhoto
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required]
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Discription { get; set; }
    }
    public class ScannedwholePhoto
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required]
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Discription { get; set; }
    }
    public class ScannedNational_Id
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required]
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Discription { get; set; }
    }
    public class ScannedCoc
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required]
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Discription { get; set; }
    }
    public class ScannedContactPersonID
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required]
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public string FileType { get; set; }
        public string Discription { get; set; }
    }
    

}
