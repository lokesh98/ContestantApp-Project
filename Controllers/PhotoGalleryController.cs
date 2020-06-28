using ContestantApplications.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContestantApplications.Controllers
{
    public class PhotoGalleryController : Controller
    {
        private readonly IContestantRepository _repo;
        public PhotoGalleryController(IContestantRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            var contestant = _repo.getAllContestant().Where(x=>x.IsActive==true);
            return View(contestant);
        }
    }
}