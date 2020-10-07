using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using College.Models;
using College.Repository;

namespace College.Controllers
{
    public class HomeController : Controller
    {
        public ICollegeRepository _repository;
        public HomeController()
        {
            _repository = new CollegeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Colleges()
        {
            AllModel model = new AllModel();
            model.CollegeModelList = _repository.GetCollegeList(1, 0);
            model.StudentModelList = _repository.GetStudentList(null);
            return View(model);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}