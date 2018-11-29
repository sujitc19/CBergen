using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarolineBergen.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name
        { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email.")]
        public string Email
        { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        { get; set; }
        [Required(ErrorMessage = "Please include a description.")]
        [Display(Name="Tell us about your project")]
        public string BodyMessage
        { get; set; }

    }
}
