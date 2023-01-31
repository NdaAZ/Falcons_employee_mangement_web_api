using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApi.Models
{
    public class Timesheet
    {
        public int TimesheetID { get; set; }
        public string Employee_Name { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public DateTime Break_time { get; set; }
        public DateTime Date { get; set; }
        public int  Emp_id { get; set; }

        public string Description { get; set; }
        public int Task_ID { get; set; }
  
    }
}
