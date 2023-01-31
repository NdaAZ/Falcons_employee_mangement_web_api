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

namespace EmployeeMnageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyLeaveRequestController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MyLeaveRequestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get(int emp_Id)
        {
            string query = @"select Anual_leaves, Sick_leaves, Study_leaves,leaveTaken_dates , Available_dates from LeaveManagementAvailability where Emp_id=@emp_id";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDatasource))
            {
                mycon.Open();
                using(SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@emp_id", emp_Id);
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myReader.Close();
                    mycon.Close();
                }

            }
            return new JsonResult(table);
        }


   



    }
}
