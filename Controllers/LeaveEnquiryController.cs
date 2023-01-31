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
    public class LeaveEnquiryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LeaveEnquiryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select leaveAvailable_ID,EmpFist_Name,Emp_id, Anual_leaves, Sick_leaves, Study_leaves,leaveTaken_dates , Available_dates from LeaveManagementAvailability";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDatasource))
            {
                mycon.Open();
                using(SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }

            }
            return new JsonResult(table);
        }


    [HttpPost]
        public JsonResult Post(LeaveEnquiry lve)
        {

         
            string query = @" INSERT INTO dbo.LeaveManagementAvailability(
                                          EmpFist_Name,
                                          Emp_id,
                                          Anual_leaves,
                                          Sick_leaves,
                                          leaveTaken_dates,
                                          Study_leaves)                                     
                                 VALUES (@EmpFist_Name,
                                          @Emp_id,
                                          @Anual_leaves,
                                          @Sick_leaves,
                                          @leaveTaken_dates,
                                          @Study_leaves )";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDatasource))
            {
                mycon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@EmpFist_Name", lve.EmpFist_Name);
                    myCommand.Parameters.AddWithValue("@Emp_id", lve.Emp_id);
                    myCommand.Parameters.AddWithValue("@Anual_leaves", lve.Anual_leaves);
                    myCommand.Parameters.AddWithValue("@Sick_leaves", lve.Sick_leaves);
                    myCommand.Parameters.AddWithValue("@leaveTaken_dates", lve.LeaveTaken_dates);
                    myCommand.Parameters.AddWithValue("@Study_leaves", lve.Study_leaves);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }

            }
            return new JsonResult("udated successfully");
        }

   



    }
}
