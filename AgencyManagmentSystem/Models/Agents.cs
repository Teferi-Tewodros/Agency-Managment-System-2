using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyMAnagmentSystem.Models
{
    public class Agents
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ወኪል ቢሮ የሚገኝበት ሀገር ስም ማስገባት ያስፈልጋል")]
        [Display(Name = "ወኪል ቢሮ የሚገኝበት ሀገር")]
        public Guid CountryId { get; set; }        
        public virtual Country Country { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "የወኪል ቢሮ  ስም ማስገባት ያስፈልጋል")]
        [Display(Name = "የወኪል ቢሮ  ስም")]
        public string Agency_Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ቢሮው የሚገኝበት ከተማ ስም ማስገባት ያስፈልጋል")]
        [Display(Name = "ቢሮው የሚገኝበት ከተማ")]
        public string City { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "የኤጀንሲው ባለቤት  ስም ማስገባት ያስፈልጋል")]
        [Display(Name = "የኤጀንሲው ባለቤት")]
        public string Owner { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ስልክ  ማስገባት ያስፈልጋል")]
        [Display(Name = "ስልክ")]
        public string Telephone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ኢሜል  ማስገባት ያስፈልጋል")]
        [Display(Name = "ኢሜል")]
        public string Agentemail { get; set; }

    }
}
