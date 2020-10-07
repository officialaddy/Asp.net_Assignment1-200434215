using College.Models.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace College.Repository
{
    public class CollegeRepository : ICollegeRepository
    {
        private string _conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public GetCollege_Result Login(string Email, string Password)
        {
            using (IDbConnection con = new SqlConnection(_conn))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Email", Email);
                parameter.Add("@Password", Password);
                return con.Query<GetCollege_Result>("Select * from College where Email=@Email and Password=@Password", parameter, commandType: CommandType.Text).FirstOrDefault();
            }
        }


        public List<GetCollege_Result> GetCollegeList(int? Role, int? CollegeID)
        {
            using (IDbConnection con = new SqlConnection(_conn))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = "";
                if (Role == 1)
                {
                    query = "Select * from College where Role <> 1";
                }
                else
                {
                    query = "Select * from College where CollegeID = " + CollegeID;
                }
                DynamicParameters parameter = new DynamicParameters();
                return con.Query<GetCollege_Result>(query, parameter, commandType: CommandType.Text).ToList();
            }
        }

        public int? InsertUpdateColloge(int? CollegeID, string CollegeName, string Email, string Password, string Address, string City, string State, string Country, string Contact)
        {
            using (IDbConnection con = new SqlConnection(_conn))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = "";
                if (CollegeID > 1)
                {
                    query = "Update College set CollegeName='" + CollegeName + "', Address='" + Address + "', City='" + City + "', State='" + State + "'," +
                        " Country='" + Country + "', ContactNumber='" + Contact + "', Email='" + Email + "', Password='" + Password + "' where CollegeID = " + CollegeID;

                }
                else
                {
                    query = "Insert into College (CollegeName, Address, City, State, Country, ContactNumber, Email, Password, Role) " +
                       "values ('" + CollegeName + "','" + Address + "','" + City + "','" + State + "','" + Country + "','" + Contact + "','" + Email + "','" + Password + "',2)";

                }
                DynamicParameters parameter = new DynamicParameters();
                var result = con.Query(query, parameter, commandType: CommandType.Text);
                return 1;
            }
        }

        public bool DeleteCollege(int? CollegeID)
        {
            bool Status = false;
            using (IDbConnection con = new SqlConnection(_conn))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = "";
                if (CollegeID > 0)
                {
                    query = "Delete from College where CollegeID= " + CollegeID;
                    Status = true;
                }

                DynamicParameters parameter = new DynamicParameters();
                con.Query<GetCollege_Result>(query, parameter, commandType: CommandType.Text).ToList();
                return Status;
            }
        }

        public bool DeleteStudent(int? CollegeID)
        {
            bool Status = false;
            using (IDbConnection con = new SqlConnection(_conn))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = "";
                if (CollegeID > 0)
                {
                    query = "Delete from Student where StudentID= " + CollegeID;
                    Status = true;
                }

                DynamicParameters parameter = new DynamicParameters();
                con.Query<GetCollege_Result>(query, parameter, commandType: CommandType.Text).ToList();
                return Status;
            }
        }
        public List<GetStudent_Result> GetStudentList(int? CollegeID)
        {
            using (IDbConnection con = new SqlConnection(_conn))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = "";
                if (CollegeID > 0)
                {
                    query = "Select st.*, c.CollegeName from Student  st inner join College c on c.CollegeID = st.CollegeID" +
                        " where st.CollegeID =" + CollegeID;
                }
                else
                {
                    query = "Select st.*, c.CollegeName from Student  st inner join College c on c.CollegeID = st.CollegeID";
                }
                DynamicParameters parameter = new DynamicParameters();
                return con.Query<GetStudent_Result>(query, parameter, commandType: CommandType.Text).ToList();
            }
        }

        public GetStudent_Result GetStudentByID(int? StudentID)
        {
            using (IDbConnection con = new SqlConnection(_conn))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = "";

                query = "Select st.*, c.CollegeName from Student  st inner join College c on c.CollegeID = st.CollegeID where st.StudentID=" + StudentID;

                DynamicParameters parameter = new DynamicParameters();
                return con.Query<GetStudent_Result>(query, parameter, commandType: CommandType.Text).FirstOrDefault();
            }
        }


        public int? InsertUpdateStudent(int? StudentID, int? CollegeID,string StudentName,  string Email,string Address, string Contact, string Gender, DateTime?  dob)
        {
            using (IDbConnection con = new SqlConnection(_conn))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = "";
                if (StudentID > 0)
                {
                    query = "Update Student set StudentName='" + StudentName + "', Address='" + Address + "', Gender='" + Gender + "', DateOfBirth='" + dob + "'," +
                        "  ContactNumber='" + Contact + "', Email='" + Email + "', CollegeID=" + CollegeID + " where StudentID = " + StudentID;

                }
                else
                {
                    query = "Insert into Student (StudentName, Gender, DateOfBirth, ContactNumber, Address, Email, CollegeID) " +
                       "values ('" + StudentName + "','" + Gender + "','" + dob + "','" + Contact + "','" + Address + "','" + Email + "'," + CollegeID + ")";

                }
                DynamicParameters parameter = new DynamicParameters();
                var result = con.Query(query, parameter, commandType: CommandType.Text);
                return 1;
            }
        }


    }
}