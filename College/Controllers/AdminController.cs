using College.Models;
using College.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ICollegeRepository _repository;
        public AdminController()
        {
            _repository = new CollegeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            var item = _repository.Login(model.Email, model.Password);
            if (item != null)
            {
                Session["CollegeID"] = item.CollegeID;
                Session["CollegeName"] = item.CollegeName;
                Session["Role"] = item.Role;

                TempData["SuccessMsg"] = "Logged in successfully";
                return RedirectToAction("Colleges");
            }
            else
            {
                TempData["ErrorMsg"] = "Email and password is incorect";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Colleges()
        {
            Session["ActiveMenu"] = 101;
            if (Session["CollegeID"] == null)
            {
                return RedirectToAction("Index");
            }
            CollegeModel model = new CollegeModel();
            if (Session["CollegeID"] != null)
            {
                model.collegeList = _repository.GetCollegeList(Convert.ToInt16(Session["Role"]), Convert.ToInt32(Session["Role"]));
            }
            return View(model);
        }

        public ActionResult AddEdit(string id)
        {
            if (Session["CollegeID"] == null)
            {
                return RedirectToAction("Index");
            }
            CollegeModel model = new CollegeModel();
            if (!string.IsNullOrEmpty(id))
            {
                model.CollegeID = Convert.ToInt32("0" + id);
                var college = _repository.GetCollegeList(2, model.CollegeID).FirstOrDefault();
                if (college != null)
                {
                    model.CollegeName = college.CollegeName;
                    model.Address = college.Address;
                    model.City = college.City;
                    model.State = college.State;
                    model.Country = college.Country;
                    model.Email = college.Email;
                    model.Password = college.Password;
                    model.ContactNumber = college.ContactNumber;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEdit(CollegeModel model)
        {
            try
            {
                if (Session["CollegeID"] == null)
                {
                    return RedirectToAction("Index");
                }
                var result = _repository.InsertUpdateColloge(model.CollegeID, model.CollegeName, model.Email, model.Password, model.Address, model.City, model.State, model.Country, model.ContactNumber);
                if (result > 0)
                {
                    TempData["SuccessMsg"] = "Record has been saved successfully";
                }
                else
                {
                    TempData["ErrorMsg"] = "Error occured! Please try again.";
                }
                return RedirectToAction("Colleges");
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message;
            }
            return RedirectToAction("AddEdit");
        }



        public ActionResult DeleteCollege(int id)
        {
            if (id != null)
            {

                bool status = _repository.DeleteCollege(id);
            }
            return RedirectToAction("Colleges");
        }


        public ActionResult Student(string id)
        {
            Session["ActiveMenu"] = 102;
            if (Session["CollegeID"] == null)
            {
                return RedirectToAction("Index");
            }
            StudentModel model = new StudentModel();
            if (Session["Role"] != null)
            {
                int Role = Convert.ToInt32(Session["Role"]);
                if (Role == 1)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        Session["PageType"] = 1;
                        model.CollegeID = Convert.ToInt32("0" + id);
                        model.studentList = _repository.GetStudentList(model.CollegeID);
                    }
                    else
                    {
                        Session["PageType"] = 2;
                        model.studentList = _repository.GetStudentList(null);
                    }
                }
                else
                {
                    Session["PageType"] = 1;
                    model.studentList = _repository.GetStudentList(Convert.ToInt32(Session["CollegeID"]));
                }
            }

            return View(model);
        }

        public ActionResult AddEditStudent(string id, string CollegeID)
        {
            if (Session["CollegeID"] == null)
            {
                return RedirectToAction("Index");
            }
            StudentModel model = new StudentModel();
            model.genderList.Add(new SelectListItem { Text = "Male", Value = "Male" });
            model.genderList.Add(new SelectListItem { Text = "Female", Value = "Female" });
            if (!string.IsNullOrEmpty(id))
            {
                model.StudentID = Convert.ToInt32("0" + id);
                model.CollegeID = Convert.ToInt32("0" + CollegeID);
                var college = _repository.GetStudentByID(model.StudentID);
                if (college != null)
                {
                    model.StudentName = college.StudentName;
                    model.Address = college.Address;
                    model.DateOfBirth = college.DateOfBirth;
                    model.Gender = college.Gender;
                    model.Email = college.Email;
                    model.ContactNumber = college.ContactNumber;
                }
            }
            int Role = Convert.ToInt32(Session["Role"]);
            model.Role = Role;
            if (Role == 1)
            {
                model.collegeList = _repository.GetCollegeList(Role, Convert.ToInt32("0"+ CollegeID)).Select(d => new SelectListItem
                {
                    Text = d.CollegeName,
                    Value = d.CollegeID.ToString(),
                }).ToList();
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult AddEditStudent(StudentModel model)
        {
            try
            {
                if (Session["CollegeID"] == null)
                {
                    return RedirectToAction("Index");
                }
                DateTime dob = DateTime.Now;
                if (model.DateOfBirth != null)
                {
                    dob = Convert.ToDateTime(model.DateOfBirth);
                }
                var result = _repository.InsertUpdateStudent(model.StudentID, model.CollegeID, model.StudentName, model.Email, model.Address, model.ContactNumber, model.Gender, dob);
                if (result > 0)
                {
                    TempData["SuccessMsg"] = "Record has been saved successfully";
                }
                else
                {
                    TempData["ErrorMsg"] = "Error occured! Please try again.";
                }
                int pageType = Convert.ToInt32(Session["PageType"]);
                if (pageType == 1)
                {
                    return RedirectToAction("Student", new { id = model.CollegeID });
                }
                else
                {
                    return RedirectToAction("Student");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message;
            }
            return RedirectToAction("AddEditStudent", new { id = model.StudentID, CollegeID = model.CollegeID });
        }
        public ActionResult DeleteStudent(int id,int CollegeID)
        {
            if (id != null)
            {

                bool status = _repository.DeleteStudent(id);
            }
            return RedirectToAction("Colleges");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session["CollegeID"] = null;
            return RedirectToAction("Index","Home");
        }



    }
}