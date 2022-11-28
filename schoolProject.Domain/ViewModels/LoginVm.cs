using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject.Domain.ViewModels
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Please Enter Your Student Id")]
        [Display(Name = "Student ID")]

        public string StudentId { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
