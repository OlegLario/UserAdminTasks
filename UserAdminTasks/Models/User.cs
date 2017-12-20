using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAdminTasks.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        //public virtual ICollection<ArchiveTask> ArchiveTasks { get; set; }
        public int RoleId { get; set; }
        public Role Roles { get; set; }
        public User()
        {
            Tasks = new List<Task>();
            //ArchiveTasks = new List<ArchiveTask>();
        }
    }
}
//add
//add2