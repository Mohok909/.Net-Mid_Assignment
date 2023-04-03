using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mid_Assignment.Models
{
    public class CollectionAssign
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Assigned Time")]
        public DateTime AssignedTime { get; set; }

        [ForeignKey("FoodRequest")]
        public int FoodRequestId;
        public virtual FoodRequest FoodRequest { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeId;
        public virtual Employee Employee { get; set; }
    }
}