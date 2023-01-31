using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApi.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Emp_id { get; set; }
        public string Auth_role { get; set; }
        public string EmpFist_Name { get; set; }

    }
}
