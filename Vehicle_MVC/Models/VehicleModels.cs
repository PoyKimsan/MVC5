using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vehicle_MVC.Models
{
    public class VehicleModels
    {
        [Required(ErrorMessage = "Please Select Model.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Make.")]
        public int MakeId { get; set; }
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public virtual Makes Make { get; set; }
    }
}