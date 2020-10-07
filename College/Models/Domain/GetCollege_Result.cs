using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace College.Models.Domain
{
    public class GetCollege_Result
    {
        public int CollegeID { get; set; }
        public string CollegeName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }
    }


    public class GetStudent_Result
    {
        public string CollegeName
        {
            get
; set;
        }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? CollegeID { get; set; }
    }
}