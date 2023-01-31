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
    public class LoginController : ControllerBase
    {
      private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]

        public JsonResult Post(Login lgn)
        {

            string query = @"select Emp_id, UserName, Auth_role, EmpFist_Name from EmployeeDetails where UserName=@UserName and Password=@Password ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TimesheetAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserName", lgn.UserName);
                    myCommand.Parameters.AddWithValue("@Password", lgn.Password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    int rowCount = table.Rows.Count;
                    if (rowCount > 0)
                    {
                        myReader.Close();
                        myCon.Close();
                        return new JsonResult(table);

                    }
                    else
                    {
                        myReader.Close();
                        myCon.Close();
                        return new JsonResult("invalid user");
                        
                        
                    }
                }
                
                
            }
            
           
        }


    }
}
