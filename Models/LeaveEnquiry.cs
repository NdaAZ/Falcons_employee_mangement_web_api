using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApi.Models
{
    public class LeaveEnquiry
    {
        public int Emp_id { get; set; }

        public int Anual_leaves { get; set; }
        public int Project_Id { get; set; }
        public int Sick_leaves { get; set; }
        public int LeaveTaken_dates { get; set; }
        public int Study_leaves { get; set; }

        public string EmpFist_Name { get; set; }
    }
}
