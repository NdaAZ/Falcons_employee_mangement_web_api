using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApi.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Customer{ get; set; }
        public string AssignTo { get; set; }
        public DateTime Assigned_Date { get; set; }
        public DateTime Due_Date { get; set; }
        public string Comments{ get; set; }
        public string Status { get; set; }
        public int Task_ID { get; set; }
        public string Tasks { get; set; }
    }

}
