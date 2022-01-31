using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTakeAway.Models
{
    public class Category
    {
        [Key]
        public long CategoryID { get; set; }
        [Required(ErrorMessage = "Please, Enter Category Name")]
        public string CategoryName { get; set; }
    }
}