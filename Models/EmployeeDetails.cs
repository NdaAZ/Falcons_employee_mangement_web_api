using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApi.Models
{
    public class EmployeeDetails
    {
        public int Emp_id { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string SkypeID { get; set; }
        public string Whatsapp { get; set; }
        public string EmployeeGroup { get; set; }
        public string Auth_role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string EmpFist_Name { get; set; }
        public string EmpLast_Namec { get; set; }
        public string Comapny_role { get; set; }
        public string Company_Email { get; set; }
        public string Personal_Email { get; set; }
        public string Contract_Type { get; set; }

        public string Note { get; set; }
        public string Joined_Date { get; set; }

    }
}
