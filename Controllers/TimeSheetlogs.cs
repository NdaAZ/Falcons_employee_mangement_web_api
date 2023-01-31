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
    public class TimeSheetlogsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TimeSheetlogsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @" SELECT 
                             lgs.timesheet_id,
                             lgs.Emp_id,
                             emp.EmpFist_Name,
                             lgs.Date,
                             lgs.Description,
                             lgs.Task_ID,
                             lgs.start_time,
                             lgs.end_time,
                             lgs.break_time,
                             lgs.total_hours_time,
                             lgs.net_hours_time
                             FROM dbo.Timesheetlogs lgs
                             join EmployeeDetails emp  on emp.Emp_id = lgs.Emp_id";

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
        public JsonResult Post(MyTasks mtsk)
        {
            string query = @" INSERT INTO dbo.Timesheetlogs(
                                          Emp_id,
                                          Date,
                                          Description,
                                          Task_ID)
                               VALUES (  
                                          @Emp_id,
                                          @Date,
                                          @Description,
                                          @Task_ID )";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                 myCon.Open();
                 using(SqlCommand myCommand = new SqlCommand(query, myCon))
                 {
                  
                    myCommand.Parameters.AddWithValue("Emp_Id", mtsk.Emp_Id);
                    myCommand.Parameters.AddWithValue("Date", mtsk.Date);
                    myCommand.Parameters.AddWithValue("Description", mtsk.Description);
                    myCommand.Parameters.AddWithValue("Task_ID", mtsk.Task_ID);
                   // myCommand.Parameters.AddWithValue("start_time", mtsk.start_time);
                    //myCommand.Parameters.AddWithValue("end_time", mtsk.end_time);
                   //myCommand.Parameters.AddWithValue("break_time", mtsk.break_time);
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
       
       












    }
}
