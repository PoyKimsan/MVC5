using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vehicle_MVC.Models
{
    public class Photos
    {
        [Required]
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicles Vehicle { get; set; }
    }
}