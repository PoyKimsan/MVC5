using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehicle_MVC.Models;
using Vehicle_MVC.ViewModels;

namespace Vehicle_MVC.Controllers
{
    public class VehiclesController : Controller
    {
        private ApplicationDbContext _context;
        public VehiclesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //public string index() {
        //    return typeof(Controller).Assembly.GetName().Version.ToString();
        //}
        public List<Makes> getMakes() {
            var makesList = _context.Makes.ToList();
            return makesList;
        }
        public JsonResult GetVehicleModels(string id) {
            List<VehicleModels> vModels = new List<VehicleModels>();
            List<SelectListItem> modelNames = new List<SelectListItem>();
            modelNames.Add(new SelectListItem { Text = "Please Select Model", Value = "" });
            if (!string.IsNullOrEmpty(id))
            {
                int makeId = Int32.Parse(id);
                vModels = _context.VehicleModels.Where(v => v.MakeId == makeId).ToList();

                if (vModels != null)
                {
                    foreach (var item in vModels)
                    {
                        modelNames.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                    }
                }
            }
            return Json(new SelectList(modelNames, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        public JsonResult getVehiclePhotos(int id)
        {
            var vphotos = _context.Photos.Where(p => p.VehicleId == id).OrderByDescending(p => p.Id).FirstOrDefault();
            return Json(vphotos, JsonRequestBehavior.AllowGet);
        }
        // GET: Vehicles
        public ActionResult Index(string sortOrder, string currentFilter, string makeSearch, int? page)
        {
            ViewBag.SortingName = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            var vehicles = from vh in _context.Vehicles select vh;
            if (makeSearch != null)
            {
                page = 1;
            }
            else
            {
                makeSearch = currentFilter;
            }
            ViewBag.CurrentFilter = makeSearch;

            if (!String.IsNullOrEmpty(makeSearch))
            {
                vehicles = vehicles.Where(s => s.Model.Make.Name.Contains(makeSearch));
            }
            if (vehicles == null)
            {
                return HttpNotFound();
            }
            switch (sortOrder)
            {
                case "name":
                    vehicles = vehicles.OrderByDescending(s => s.ContactName);
                    break;
                default:
                    vehicles = vehicles.OrderBy(s => s.ContactName);
                    break;
            }
            ViewBag.Makes = getMakes();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(vehicles.ToPagedList(pageNumber, pageSize));
        }

        // GET: Vehicles/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var seleted = _context.VehicleFeatures.Where(vf => vf.VehicleId == id).Select(vf => vf.FeatureId).ToList();
            var viewModel = new VehicleViewModel
            {
                Vehicles = _context.Vehicles.Include(c => c.Model).SingleOrDefault(c => c.Id == id),
                Features = _context.Features.Where(f => seleted.Contains(f.Id)).ToList(),
                photos = _context.Photos.Where(p => p.VehicleId == id).ToList()
            };

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
        [HttpPost]
        public JsonResult SaveFile(int id)
        {
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/FileUpload/"), fileName);
                    file.SaveAs(path);
                var photo = new Photos
                {
                    VehicleId = id,
                    FileName = fileName
                };
                _context.Photos.Add(photo);
                _context.SaveChanges();
                    }
                return getVehiclePhotos(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult AddNew()
        {
            var features = _context.Features.ToList();
            var vehicleModels = _context.VehicleModels.ToList();
            var viewModel = new VehicleViewModel()
            {
                Vehicles = new Vehicles(),
                Features = features
            };
            ViewBag.Makes = getMakes();
            ViewBag.Models = string.Empty;
            ViewBag.Title = "Add New";
            return View("VehicleForm", viewModel);
        }
        public ActionResult Save([Bind(Include = "Vehicles,VehicleModels,SelectFeature,Features")] VehicleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Makes = getMakes();
                viewModel.Features = _context.Features.ToList();
                if (viewModel.VehicleModels.MakeId != 0)
                {
                    ViewBag.Models = _context.VehicleModels.Where(vm => vm.MakeId == viewModel.VehicleModels.MakeId).ToList();
                }
                return View("VehicleForm", viewModel);
            }
            try
            {
                if (viewModel.Vehicles.Id != 0)
                {
                    var vehicle = _context.Vehicles.SingleOrDefault(c => c.Id == viewModel.Vehicles.Id);
                    vehicle.ContactName = viewModel.Vehicles.ContactName;
                    vehicle.ContactEmail = viewModel.Vehicles.ContactEmail;
                    vehicle.ContactPhone = viewModel.Vehicles.ContactPhone;
                    vehicle.IsRegistered = viewModel.Vehicles.IsRegistered;
                    vehicle.LastUpdate = DateTime.Now;
                    vehicle.ModelId = viewModel.VehicleModels.Id;
                }
                else
                {
                    int vid = _context.Vehicles.DefaultIfEmpty().Max(r => r == null ? 0 : r.Id);
                    viewModel.Vehicles.Id = vid + 1;
                    viewModel.Vehicles.ModelId = viewModel.VehicleModels.Id;
                    viewModel.Vehicles.LastUpdate = DateTime.Now;
                    _context.Vehicles.Add(viewModel.Vehicles);
                }
                _context.SaveChanges();
                var vFeature = _context.VehicleFeatures.Where(vf => vf.Vehicle.Id == viewModel.Vehicles.Id).ToList();
                if (viewModel.SelectFeature.Count > 0)
                {
                    foreach (var item in vFeature)
                    {
                        if (!viewModel.SelectFeature.Contains(item.Id))
                        {
                            _context.VehicleFeatures.Remove(item);
                            _context.SaveChanges();
                        }
                    }
                    foreach (var item in viewModel.SelectFeature)
                    {
                        var feature = new VehicleFeatures
                        {
                            VehicleId = viewModel.Vehicles.Id,
                            FeatureId = item
                        };
                        _context.VehicleFeatures.Add(feature);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (vFeature != null && vFeature.Count > 0) { 
                        foreach (var item in vFeature)
                        {
                            _context.VehicleFeatures.Remove(item);
                            _context.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("","",errorMessages);
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var seleted = _context.VehicleFeatures.Where(vf => vf.VehicleId == id).Select(vf => vf.FeatureId).ToList();
            int mid = _context.Vehicles.Where(m => m.Id == id).Select(m => m.ModelId).FirstOrDefault();
            var viewModel = new VehicleViewModel
            {
                Vehicles = _context.Vehicles.Find(id),
                SelectFeature = seleted,
                Features = _context.Features.ToList(),
                VehicleModels = _context.VehicleModels.FirstOrDefault(vm => vm.Id == mid)
            };

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Makes = getMakes();
            ViewBag.Models = _context.VehicleModels.Where(vm => vm.MakeId == viewModel.VehicleModels.Make.Id).ToList();
            ViewBag.Title = "Edit";
            return View("VehicleForm",viewModel);
        }
        //[HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Vehicles vehicles = _context.Vehicles.Find(id);
                if (vehicles != null)
                {
                    string path = Server.MapPath("~/FileUpload/");
                    var fileName = _context.Photos.Where(p => p.VehicleId == id).Select(p => p.FileName).ToList();
                    foreach (var item in fileName)
                    {
                        var fullPath = path + item;
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }
                }
                _context.Vehicles.Remove(vehicles);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
