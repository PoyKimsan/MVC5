using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vehicle_MVC.Models
{
    public class Vehicles
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name.")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Please Enter Email.")]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(255)]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number.")]
        [StringLength(255)]
        [Display(Name = "Phone")]
        public string ContactPhone { get; set; }

        [Required]
        [Display(Name = "Is registered")]
        public bool IsRegistered { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [Required(ErrorMessage = "Please Select Model.")]
        public int ModelId { get; set; }
        [Display(Name = "Model")]

        public virtual VehicleModels Model { get; set; }
    }
}