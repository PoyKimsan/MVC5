using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicle_MVC.Models;

namespace Vehicle_MVC.ViewModels
{
    public class VehicleViewModel
    {
        public Vehicles Vehicles { get ; set; }
        public VehicleModels VehicleModels { get; set; }
        public List<Features> Features { get; set; }
        public List<Photos> photos { get; set; }
        private List<int> _selectFeature;
        public List<int> SelectFeature
        {
            get
            {
                if (_selectFeature == null)
                {
                    _selectFeature = Features.Where(f => f.isChecked).Select(x => x.Id).ToList();
                }
                return _selectFeature;
            }
            set { _selectFeature = value; }
        }
    }
}