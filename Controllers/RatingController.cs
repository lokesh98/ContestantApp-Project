using ContestantApplications.Repository;
using ContestantApplications.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContestantApplications.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingRepository _repo;
        private readonly IContestantRepository _contestant;
        public RatingController(IRatingRepository repo, IContestantRepository contestant)
        {
            _repo = repo;
            _contestant = contestant;
        }

        public ActionResult Index(RatingViewModel model)
        {
            //string fromdate = Request.Form["fromdate"];
            //string todate = Request.Form["todate"];
            //RatingViewModel model = new RatingViewModel();
            model.RatingList= _repo.getContestantWithRating(model.from_date, model.to_date);
            return View(model);
        }

        public JsonResult GetContestantById(int id)
        {
            var data = _contestant.getContestantById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveRatings(int rate_val, int Id)
        {
            int i = _repo.rateContestant(rate_val, Id);
            if (i > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("errror");
            }
           
        }
    }
}