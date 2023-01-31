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
    public class MytimesheetController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MytimesheetController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get(int emp_Id)
        {
           
            string query = @"select Emp_id, Date, Description, Task_ID, start_time, end_time, break_time from Timesheetlogs where Emp_id=@emp_id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                  myCommand.Parameters.AddWithValue("@emp_id", emp_Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    
       [HttpPost]
        public JsonResult Post(Timesheet tsheet)
        {

            string query = @"Insert into Timesheetlogs(Emp_id,Date,Description,Task_ID,start_time,end_time,break_time)values(@Emp_id,@Date, @Description, @Task_ID, @start_time,@end_time,@break_time)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Emp_id", tsheet.Emp_id);
                    myCommand.Parameters.AddWithValue("@Date", tsheet.Date);
                    myCommand.Parameters.AddWithValue("@Description", tsheet.Description);                 
                    myCommand.Parameters.AddWithValue("@Task_ID", tsheet.Task_ID);
                    myCommand.Parameters.AddWithValue("@start_time", tsheet.Start_time);
                    myCommand.Parameters.AddWithValue("@end_time", tsheet.End_time);
                    myCommand.Parameters.AddWithValue("@break_time", tsheet.Break_time);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(("update Successfully"));
        }

        
     
      

    }
}
