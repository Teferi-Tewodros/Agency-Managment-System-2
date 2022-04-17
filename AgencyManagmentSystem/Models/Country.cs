using System.ComponentModel.DataAnnotations;

namespace AgencyMAnagmentSystem.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        #region SurName
        [Required(AllowEmptyStrings = false, ErrorMessage = "ሀገር ስም ማስገባት ያስፈልጋል")]
        [Display(Name = "ሀገር")]
        public string CountryName { get; set; }
        #endregion 
        #region SurName
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country Name")]
        [Display(Name = "Country Name")]
        public string CountryNameEnglish { get; set; }
        #endregion
    }
}
