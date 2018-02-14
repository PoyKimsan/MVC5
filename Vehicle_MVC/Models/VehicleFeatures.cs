using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle_MVC.Models
{
    public class VehicleFeatures
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }
        public virtual Vehicles Vehicle { get; set; }
        public virtual Features feature { get; set; }
    }
}