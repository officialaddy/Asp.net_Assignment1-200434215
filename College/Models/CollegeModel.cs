using College.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College.Models
{
    public class CollegeModel
    {
        public int? CollegeID { get; set; }
        [Required]
        public string CollegeName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<GetCollege_Result> collegeList { get; set; }
        public CollegeModel()
        {
            collegeList = new List<GetCollege_Result>();
        }
    }
    public class StudentModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? CollegeID { get; set; }
        public int? Role { get; set; }
        public List<GetStudent_Result> studentList { get; set; }
        public List<SelectListItem> genderList { get; set; }

        public List<SelectListItem> collegeList { get; set; }
        public StudentModel()
        {
            studentList = new List<GetStudent_Result>();
            genderList = new List<SelectListItem>();
            collegeList = new List<SelectListItem>();
        }
    }

    public class AllModel
    {
        public List<GetStudent_Result> StudentModelList { get; set; }
        public List<GetCollege_Result> CollegeModelList { get; set; }
    }
}