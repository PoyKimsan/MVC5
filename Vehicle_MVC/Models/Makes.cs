using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vehicle_MVC.Models
{
    public class Makes
    {
        [Required (ErrorMessage = "Please Select Make.")]
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Make")]
        public string  Name { get; set; }
    }
}