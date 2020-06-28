using ContestantApplications.Repository;
using ContestantApplications.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContestantApplications.Controllers
{
    public class ContestantController : Controller
    {
        private readonly IContestantRepository _repo;
        private readonly ITestRepository _district;
        public ContestantController(ITestRepository district, IContestantRepository repo)
        {
            _repo = repo;
            _district = district;
        }

        public ActionResult Index(int page = 1)
        {
            var data = new ContestantPageViewModel
            {
                ContestantPerPage = 5,
                ContestantList = _repo.getAllContestant().OrderBy(x=>x.Id),
                CurrentPage = page
            };

            return View(data);
        }

        [HandleError(View = "Error")]
        public ActionResult Test()
        {
            int u = Convert.ToInt32(""); // Error line  
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ContestantViewModel model = new ContestantViewModel();
            model.DistrictList = new SelectList(_district.getAll(), "Id", "Name");
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(ContestantViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string extension = Path.GetExtension(model.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    model.PhotoUrl = "Content/img/" + fileName;
                    model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
                }

                _repo.addNewContestant(model);
                TempData["message"] = "Contestant Added Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ContestantViewModel model = new ContestantViewModel();
            model = _repo.getContestantById(id);
            model.DistrictList = new SelectList(_district.getAll(), "Id", "Name");
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            ContestantViewModel model = new ContestantViewModel();
            model = _repo.getContestantById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ContestantViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string extension = Path.GetExtension(model.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    model.PhotoUrl = "Content/img/" + fileName;
                    model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
                }

                _repo.UpdateContestant(model);
                TempData["message"] = "Contestant Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }

      
        public ActionResult Delete(int Id)
        {
            try
            {
                int i = _repo.DeleteContestant(Id);
                TempData["message"] = "Contestant Deeleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message.ToString();
                return RedirectToAction("Index");
            }

        }
    }
}