using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectTakeAway.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long CustomerID { get; set; }
        [Required(ErrorMessage = "Please, Enter First Name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please, Enter Last Name")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please, Enter Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please, Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}