using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_Assignment.Models
{
    public class FoodRequest
    {
        [Key]
        public int Id { get; set; }
        public DateTime PerservationTime { get; set; }
        public bool Collected { get; set; }

        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        public virtual ICollection<CollectionAssign> CollectionAssigns { get; set; }
    }
}