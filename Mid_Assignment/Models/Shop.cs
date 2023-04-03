using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_Assignment.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        public string Name { get; set;}
        public string Address { get; set;}
        public string PhoneNo { get; set;}

        public virtual ICollection<FoodRequest> FoodRequests { get; set; }
    }
}