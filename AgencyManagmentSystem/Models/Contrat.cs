using System.ComponentModel.DataAnnotations;

namespace AgencyMAnagmentSystem.Models
{
    public class Contrat
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "የሰራተኛ ስም ያስፈልጋል")]
        [Display(Name = "የሰራተኛ ስም")]
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "የወኪል ቢሮ  ስም ማስገባት ያስፈልጋል")]
        [Display(Name = "የወኪል ቢሮ  ስም")]
        public Guid AgentsId { get; set; }
        public virtual Agents Agents { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "viza No ማስገባት ያስፈልጋል")]
        [Display(Name = "viza No")]
        public string Employer_Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ቀጣሪ የሚገኝበት ከተማ ስም ማስገባት ያስፈልጋል")]
        [Display(Name = "ቀጣሪ የሚገኝበት ከተማ")]
        public string Employer_City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "የቀጣሪ Id ማስገባት ያስፈልጋል")]
        [Display(Name = "የቀጣሪ Id")]
        public string National_Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "የቀጣሪ ስልክ  ማስገባት ያስፈልጋል")]
        [Display(Name = "የቀጣሪ ስልክ")]
        public string Employer_Telephone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "የቀጣሪ ኢሜል ማስገባት ያስፈልጋል")]
        [Display(Name = "የቀጣሪ ኢሜል")]
        [EmailAddress]
        public string Employer_email { get; set; }
    }
}
