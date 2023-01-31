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
    public class MyTaskController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MyTaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get(int emp_Id)
        {
           
            string query = @"select tsk.Task_ID, tsk.Emp_id, tsk.ProjectName, tsk.Task_description, tsk.Developer_notes, tsk.Tasks, tsk.Status from dbo.Tasks tsk where Emp_id = @emp_id ";

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
    
       [HttpPut]
        public JsonResult Put(Tasks tsk)
        {

            string query = @"UPDATE dbo.Tasks SET Developer_notes =@Developer_notes,  Status=@Status  WHERE Emp_id=@Emp_id and Task_ID=@Task_ID";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Developer_notes", tsk.Developer_notes);
                    //myCommand.Parameters.AddWithValue("@Status_id", tsk.Status_id);
                    myCommand.Parameters.AddWithValue("@Emp_id", tsk.Emp_id);
                    myCommand.Parameters.AddWithValue("@Task_ID", tsk.Task_ID);
                    myCommand.Parameters.AddWithValue("@Status", tsk.Status);
           
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        
     
      

    }
}
