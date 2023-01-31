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
    public class ProjectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @" 
                            select ProjectID, ProjectName, Description, Customer, AssignTo, Assigned_Date, Due_Date, Comments, Status,Tasks, Task_ID   from
                            dbo.Project";

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
        public JsonResult Post(Project project)
        {
            string query = @" insert into dbo.Project
                              (ProjectName, Description, Customer, AssignTo, Assigned_Date, Due_Date, Comments, Status,Tasks, Task_ID)
                       values (@ProjectName, @Description, @Customer, @AssignTo, @Assigned_Date, @Due_Date, @Comments, @Status, @Tasks, @Task_ID)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ProjectName",project.ProjectName);
                    myCommand.Parameters.AddWithValue("@Description", project.Description);
                    myCommand.Parameters.AddWithValue("@Customer", project.Customer);
                    myCommand.Parameters.AddWithValue("@AssignTo", project.AssignTo);
                    myCommand.Parameters.AddWithValue("@Assigned_Date", project.Assigned_Date);
                    myCommand.Parameters.AddWithValue("@Due_Date", project.Due_Date);
                    myCommand.Parameters.AddWithValue("@Comments", project.Comments);
                    myCommand.Parameters.AddWithValue("@Status", project.Status);
                    myCommand.Parameters.AddWithValue("@Tasks", project.Tasks);
                    myCommand.Parameters.AddWithValue("@Task_ID", project.Task_ID);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Project project)
        {
            string query = @"
                            update dbo.Project
                            set ProjectName =@ProjectName,
                                Description = @Description,
                                Customer = @Customer,
                                AssignTo = @AssignTo,
                                Assigned_Date = @Assigned_Date,
                                Due_Date = @Due_Date,
                                Comments = @Comments,
                                Status = @Status,
                                Tasks =@Tasks,
                                Task_ID = @Task_ID
                                where ProjectID = @ProjectID";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ProjectID", project.ProjectID);
                    myCommand.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    myCommand.Parameters.AddWithValue("@Description", project.Description);
                    myCommand.Parameters.AddWithValue("@Customer", project.Customer);
                    myCommand.Parameters.AddWithValue("@AssignTo", project.AssignTo);
                    myCommand.Parameters.AddWithValue("@Assigned_Date", project.Assigned_Date);
                    myCommand.Parameters.AddWithValue("@Due_Date", project.Due_Date);
                    myCommand.Parameters.AddWithValue("@Comments", project.Comments);
                    myCommand.Parameters.AddWithValue("@Status", project.Status);
                    myCommand.Parameters.AddWithValue("@Tasks", project.Tasks);
                    myCommand.Parameters.AddWithValue("@Task_ID", project.Task_ID);
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
                            delete from dbo.Project
                            where ProjectID=@ProjectID";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ProjectID", id);
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
