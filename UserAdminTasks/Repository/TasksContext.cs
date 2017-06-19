using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserAdminTasks.Models;

namespace UserAdminTasks.Repository
{
    public class TasksContext : DbContext
    {
        public TasksContext() : base("TasksUsersEntity"){ }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ArchiveTask> ArchiveTasks { get; set; }
    }
}