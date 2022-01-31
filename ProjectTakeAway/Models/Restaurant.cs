using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTakeAway.Models
{
    public class Restaurant
    {
        [Key]
        public long RestaurantID { get; set; }
        [Required(ErrorMessage = "Please, Enter Restaurant Name")]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Please, Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please, Enter Email")]
        public string Email { get; set; }
    }
}