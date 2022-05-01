using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProject.Core.ViewModels
{
    public class CustomerViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        [MinLength(2, ErrorMessage = "{0} must not be less than {1}")]
        [MaxLength(20, ErrorMessage = "{0} must not be more thant {1}")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MinLength(2, ErrorMessage = "{0} must not be less than {1}")]
        [MaxLength(20, ErrorMessage = "{0} must not be more thant {1}")]
        public string LastName { get; set; }


        [Display(Name = "Birthday")]
        [Required]
        public string DateOfBirth { get; set; }



        [Display(Name = "Phone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11)]
        [MinLength(11)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Bank Account Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [MaxLength(16)]
        [MinLength(16)]
        public string BankAccountNumber { get; set; }
    }
}
