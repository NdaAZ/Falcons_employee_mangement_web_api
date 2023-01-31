using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApi.Models
{
    public class Tasks
    {
        public int Task_ID{ get; set; }
        public string ProjectName { get; set; }
        public string Task_Description { get; set; }
        public int Emp_id { get; set; }
        public string Assigned_to { get; set; }
        public int Status_id { get; set; }
        public string Developer_notes { get; set; }
        public string Status { get; set; }
   

    }
}
