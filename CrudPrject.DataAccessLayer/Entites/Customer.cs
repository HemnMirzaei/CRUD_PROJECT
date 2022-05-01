using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CrudProject.DataAccessLayer.Entites
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

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
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Bank Account Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string BankAccountNumber { get; set; }
    }


}
