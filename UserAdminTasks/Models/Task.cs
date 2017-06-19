using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAdminTasks.Models
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime StartDateTask { get; set; }
        public string Description { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedCompletionDate { get; set; }
        public bool StartExecution { get; set; }
        public bool IsExecution { get; set; }
        public bool IsDone { get; set; }
        public int? FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public User ToUser { get; set; }
        public User FromUser { get; set; }
    }
}