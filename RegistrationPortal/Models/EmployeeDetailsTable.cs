using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RegistrationPortal.Models
{
    public class EmployeeDetailsTable
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        [Display(Name = "Date of joining")]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [Display(Name = "Mobile number")]
        public int MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Required]
        [Display(Name = "IFSC Code")]
        public string IFSCCode { get; set; }

        [Required]
        [Display(Name = "Account number")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "PF number")]
        public string PFNumber { get; set; }

        [Required]
        [Display(Name = "UAN number")]
        public string UANNumber { get; set; }

        [Required]
        [Display(Name = "User photo (.png/.jpeg only)")]
        public string UserPhotoPath { get; set; }

        [Required]
        [Display(Name = "File upload (.pdf/.exel/.vad/.ppt)")]
        public string DocumentUploadPath { get; set; }
    }
}