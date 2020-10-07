using College.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Repository
{
    public interface ICollegeRepository
    {
        GetCollege_Result Login(string Email, string Password);
        List<GetCollege_Result> GetCollegeList(int? Role, int? CollegeID);
        int? InsertUpdateColloge(int? CollegeID, string CollegeName, string Email, string Password, string Address, string City, string State, string Country, string Contact);
        bool DeleteCollege(int? CollegeID);
        bool DeleteStudent(int? CollegeID);
        List<GetStudent_Result> GetStudentList(int? CollegeID);
        GetStudent_Result GetStudentByID(int? StudentID);
        int? InsertUpdateStudent(int? StudentID, int? CollegeID, string StudentName, string Email, string Address, string Contact, string Gender, DateTime? dob);
    }
}
