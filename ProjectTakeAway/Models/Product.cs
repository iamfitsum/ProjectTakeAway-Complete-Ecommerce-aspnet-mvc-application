using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTakeAway.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        [Required(ErrorMessage = "Please, Enter Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Range(0, 4000, ErrorMessage = "Price value btwn 0-4000")]
        public Nullable<decimal> Price { get; set; }
        public string AvailabilityStatus { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> RestaurantID { get; set; }
        public Nullable<bool> Active { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual Category Category { get; set; }
    }
}