using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyMAnagmentSystem.Models
{
    public class Maid   




    {
        public Guid Id { get; set; }
        #region SurName
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sur Name ያስፈልጋል")]
        [Display(Name = "SurName")]
        public string SurName { get; set; }

        #endregion
        #region GIVEN_NAMES
        [Required(AllowEmptyStrings = false, ErrorMessage = "GIVEN_NAMES ያስፈልጋል")]
        [Display(Name = "GIVEN NAMES")]
        public string GIVEN_NAMES { get; set; }

        #endregion
        #region Birth Date
        [Required(AllowEmptyStrings = false, ErrorMessage = "Birth Date ያስፈልጋል")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date, ErrorMessage = "Birth Date ትክክል አይደለም")]
        public DateTime Birthday { get; set; }

        #endregion
        #region Gender
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender ያስፈልጋል")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        #endregion
        #region Marital Status
        [Required(AllowEmptyStrings = false, ErrorMessage = "Marital Status ያስፈልጋል")]
        [Display(Name = "Marital Status")]
        public string Marital_status { get; set; }
        #endregion
        #region Religion
        [Required(AllowEmptyStrings = false, ErrorMessage = "Religion ያስፈልጋል")]
        [Display(Name = "Religion")]
        public string Religion { get; set; }
        #endregion
        #region Job
        [Required(AllowEmptyStrings = false, ErrorMessage = "Job ያስፈልጋል")]
        [Display(Name = "Job")]
        public string Job { get; set; }

        #endregion
        #region Nationality
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nationality ያስፈልጋል")]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        #endregion
        #region Qualifications

        [Display(Name = "Qualifications")]

        public string Qualifications { get; set; }
        #endregion
        #region Experience
        [Required(AllowEmptyStrings = false, ErrorMessage = "Experience ያስፈልጋል")]
        [Display(Name = "Experience")]
        public string Experience { get; set; }
        #endregion
        #region Experience Country
        [Required(AllowEmptyStrings = false, ErrorMessage = "Experience Country ያስፈልጋል")]
        [Display(Name = "Experience Country")]
        public string Experience_Country { get; set; }

        #endregion
        #region Passport No
        [Required(AllowEmptyStrings = false, ErrorMessage = "Passport No ያስፈልጋል")]
        [Display(Name = "Passport No")]
        public string Passport_NO { get; set; }
        #endregion
        #region City
        [Required(AllowEmptyStrings = false, ErrorMessage = "City ያስፈልጋል")]
        [Display(Name = "City")]
        public string City { get; set; }

        #endregion
        #region Address
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address ያስፈልጋል")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        #endregion
        #region Mobile
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile ያስፈልጋል")]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Mobile ትክክል አይደለም")]
        public string Mobile { get; set; }

        #endregion
        #region Country
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country ያስፈልጋል")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        #endregion
        #region Passport Issue Place

        [Display(Name = "Passport Issue Place")]
        public string Passport_issue_place { get; set; }

        #endregion
        #region Passport Issue Ddate
        [Required(AllowEmptyStrings = false, ErrorMessage = "Passport Issue Ddate ያስፈልጋል")]
        [Display(Name = "Passport Issue Date")]
        [DataType(DataType.Date, ErrorMessage = "Passport Issue Ddate ትክክል አይደለም")]
        public DateTime Passport_issue_date { get; set; }

        #endregion
        #region Passport_expire
        [Required(AllowEmptyStrings = false, ErrorMessage = "Passport expire ያስፈልጋል")]
        [Display(Name = "Passport Expire")]
        [DataType(DataType.Date, ErrorMessage = "Passport Expire ትክክል አይደለም")]
        public DateTime Passport_expire { get; set; }

        #endregion 
        #region IsSelected
        [Display(Name = "Is Selected")]
        public bool IsSelected { get; set; }

        #endregion
         #region IsRejected
        [Display(Name = "Is Rejected")]
        public bool IsRejected { get; set; }

        #endregion
          #region TimeStamp

        [Display(Name = "TimeStamp")]

        public string TimeStamp { get; set; }

        #endregion
        #region Full Name
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return GIVEN_NAMES + " " + SurName+"  PN:- "+Passport_NO;
            }
        }
        #endregion


    }
}
