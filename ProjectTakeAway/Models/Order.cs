using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTakeAway.Models
{
    public class Order
    {
        [Key]
        public long OrderID { get; set; }
        public Nullable<decimal> OrderPrice { get; set; }
        public long CustomerID { get; set; }
        public long RestaurantID { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Customer Customer { get; set; }
    }
}