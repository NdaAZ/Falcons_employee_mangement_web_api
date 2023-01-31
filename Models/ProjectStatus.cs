using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApi.Models
{
    public class ProjectStatus
    {
        public string Comments { get; set; }
        public string Status { get; set; }

        public int Emp_id { get; set; }
    }
}
