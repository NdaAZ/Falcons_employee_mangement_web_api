using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApi.Models
{
    public class MyTasks
    {
        public int Emp_Id { get; set; }
        public int emp_Id { get; set; }
        public string ProjectName { get; set; }
        public string Tasks { get; set; }
        public string Status { get; set; }
        public string Task_description { get; set; }
        //time sheet logs
        public int timesheet_id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public  int Task_ID { get; set; }
        public  DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public DateTime break_time { get; set; }
        public DateTime total_hours_time { get; set; }
        public DateTime net_hours_time { get; set; }



    }
}
