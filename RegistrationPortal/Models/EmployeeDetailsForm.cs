using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace RegistrationPortal.Models
{
    public class EmployeeDetailsForm
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
                
        [Display(Name ="Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Company Name")]
        public string Company { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        [Display(Name ="Date of joining")]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [Range(1000000000,9999999999,ErrorMessage ="Enter a valid mobile number")]
        [Display(Name ="Mobile number")]
        public int MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Bank Name")]
        public string Bank { get; set; }

        [Required]
        [Display(Name ="IFSC Code")]
        public string IFSCCode { get; set; }

        [Required]
        [Display(Name ="Account number")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name ="PF number")]
        public string PFNumber { get; set; }

        [Required]
        [Display(Name ="UAN number")]
        public string UANNumber { get; set; }

        [Required]
        [Display(Name ="User photo (.png/.jpeg only)")]
        
        public HttpPostedFileBase UserPhotoFile { get; set; }

        [Required]
        [Display(Name = "File upload (.pdf/.exel/.vad/.ppt)")]
        public HttpPostedFileBase[] DocumentUploadFile { get; set; }
    }
}