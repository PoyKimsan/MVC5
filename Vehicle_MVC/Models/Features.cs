using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vehicle_MVC.Models
{
    public class Features
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [NotMapped]
        public virtual bool isChecked { get; set; }
    }
}