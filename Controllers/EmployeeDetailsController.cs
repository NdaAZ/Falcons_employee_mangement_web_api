using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TimesheetApi.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace TimesheetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeeDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @" 
                            SELECT 
                                  Emp_id, EmpFist_Name, EmpLast_Namec, Auth_role, comapny_role, Contract_type, Note, Joined_Date, SkypeId , Whatsapp, Company_Email, Personal_Email, UserName,Password
                           FROM dbo.EmployeeDetails";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(EmployeeDetails emp)
        {
            string query = @" INSERT INTO dbo.EmployeeDetails(
                                          EmpFist_Name,
                                          EmpLast_Namec,
                                          Auth_role,
                                          comapny_role,
                                          Contract_type,
                                          Note,
                                          Joined_Date,
                                          SkypeId ,
                                          Whatsapp,
                                          Company_Email,
                                          Personal_Email,
                                          UserName,
                                          Password)
                               VALUES (   @EmpFist_Name,
                                          @EmpLast_Namec,
                                          @Auth_role,
                                          @comapny_role,
                                          @Contract_type,
                                          @Note,
                                          @Joined_Date,
                                          @SkypeId,
                                          @Whatsapp,
                                          @Company_Email,
                                          @Personal_Email,
                                          @UserName,
                                          @Password)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                 myCon.Open();
                 using(SqlCommand myCommand = new SqlCommand(query, myCon))
                 {
                    myCommand.Parameters.AddWithValue("EmpFist_Name", emp.EmpFist_Name);
                    myCommand.Parameters.AddWithValue("EmpLast_Namec", emp.EmpLast_Namec);
                    myCommand.Parameters.AddWithValue("Auth_role", emp.Auth_role);
                    myCommand.Parameters.AddWithValue("comapny_role", emp.Comapny_role);
                    myCommand.Parameters.AddWithValue("Contract_type", emp.Contract_Type);
                    myCommand.Parameters.AddWithValue("Note", emp.Note);
                    myCommand.Parameters.AddWithValue("Joined_Date", emp.Joined_Date);
                    myCommand.Parameters.AddWithValue("Personal_Email", emp.Personal_Email);
                    myCommand.Parameters.AddWithValue("Company_Email", emp.Company_Email);
                    myCommand.Parameters.AddWithValue("SkypeId", emp.SkypeID);
                    myCommand.Parameters.AddWithValue("Whatsapp", emp.Whatsapp);
                    myCommand.Parameters.AddWithValue("Username", emp.Username);
                    myCommand.Parameters.AddWithValue("Password", emp.Password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        
        [HttpPut]
        public JsonResult Put(EmployeeDetails emp)
        {
            string query = @"
                            UPDATE dbo.EmployeeDetails
                            SET EmpFist_Name =@EmpFist_Name,
                                EmpLast_Namec= @EmpLast_Namec,
                                Auth_role = @Auth_role,
                                comapny_role = @comapny_role,
                                Contract_type = @Contract_type,
                                Joined_Date = @Joined_Date,
                                SkypeId = @SkypeId,
                                Note = @Note,
                                Whatsapp = @Whatsapp,
                                Company_Email = @Company_Email,
                                Personal_Email =@Personal_Email,
                                UserName = @UserName,
                                Password = @Password
                                where Emp_id = @Emp_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                 
                {
                    myCommand.Parameters.AddWithValue("@Emp_id", emp.Emp_id);
                    myCommand.Parameters.AddWithValue("EmpFist_Name", emp.EmpFist_Name);
                    myCommand.Parameters.AddWithValue("EmpLast_Namec", emp.EmpLast_Namec);
                    myCommand.Parameters.AddWithValue("Auth_role", emp.Auth_role);
                    myCommand.Parameters.AddWithValue("comapny_role", emp.Comapny_role);
                    myCommand.Parameters.AddWithValue("Contract_type", emp.Contract_Type);
                    myCommand.Parameters.AddWithValue("Note", emp.Note);
                    myCommand.Parameters.AddWithValue("Joined_Date", emp.Joined_Date);
                    myCommand.Parameters.AddWithValue("Personal_Email", emp.Personal_Email);
                    myCommand.Parameters.AddWithValue("Company_Email", emp.Company_Email);
                    myCommand.Parameters.AddWithValue("SkypeId", emp.SkypeID);
                    myCommand.Parameters.AddWithValue("Whatsapp", emp.Whatsapp);
                    myCommand.Parameters.AddWithValue("Username", emp.Username);
                    myCommand.Parameters.AddWithValue("Password", emp.Password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }

            }
            return new JsonResult("Updated Successfully");

        }

       
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @" 
                            DELETE FROM dbo.EmployeeDetails
                            WHERE Emp_id=@Emp_id";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Emp_id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }

            }

            return new JsonResult("Deleted Successfully");

        }












    }
}
