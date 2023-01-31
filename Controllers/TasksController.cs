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
    public class TasksController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TasksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @" 
                            select Task_ID, ProjectName, Task_description, Emp_id, Assigned_to, Status_id, Developer_notes, Status from
                            dbo.Tasks";

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
        public JsonResult Post(Tasks Task)
        {
            string query = @" insert into dbo.Tasks
                              ( ProjectName, Task_description, Emp_id, Assigned_to, Status_id, Developer_notes)
                       values ( @ProjectName, @Task_description, @Emp_id, @Assigned_to, @Status_id, @Developer_notes)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                  //  myCommand.Parameters.AddWithValue("@Task_ID", Task.Task_ID);
                    myCommand.Parameters.AddWithValue("@ProjectName", Task.ProjectName);
                    myCommand.Parameters.AddWithValue("@Task_description", Task.Task_Description);
                    myCommand.Parameters.AddWithValue("@Emp_id", Task.Emp_id);
                    myCommand.Parameters.AddWithValue("@Assigned_to", Task.Assigned_to);
                    myCommand.Parameters.AddWithValue("@Status_id", Task.Status_id);
                    myCommand.Parameters.AddWithValue("@Developer_notes", Task.Developer_notes);
      
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Tasks Task)
        {
            string query = @"
                            update dbo.Tasks
                            set ProjectName =@ProjectName,
                                Task_description = @Task_description,
                                Emp_id = @Emp_id,
                                Assigned_to = @Assigned_to,
                                Status_id = @Status_id,
                                Developer_notes = @Developer_notes
                                where Task_ID = @Task_ID";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Task_ID", Task.Task_ID);
                    myCommand.Parameters.AddWithValue("@ProjectName", Task.ProjectName);
                    myCommand.Parameters.AddWithValue("@Task_description", Task.Task_Description);
                    myCommand.Parameters.AddWithValue("@Emp_id", Task.Emp_id);
                    myCommand.Parameters.AddWithValue("@Assigned_to", Task.Assigned_to);
                    myCommand.Parameters.AddWithValue("@Status_id", Task.Status_id);
                    myCommand.Parameters.AddWithValue("@Developer_notes", Task.Developer_notes);

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
                            delete from dbo.Tasks
                            where Task_ID=@Task_ID";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Task_ID", id);
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
