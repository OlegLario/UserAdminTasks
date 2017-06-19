using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserAdminTasks.Models;
using UserAdminTasks.Repository;

namespace UserAdminTasks.Controllers
{
    public class TasksController : Controller
    {
        private TasksContext db = new TasksContext();

        // GET: Tasks
        public ActionResult Index(string searchString)
        {
            var tasks = db.Tasks.Include(t => t.FromUser).Include(t => t.ToUser);
            if(!String.IsNullOrEmpty(searchString))
            {
                tasks = tasks.Where(t => t.FromUser.FullName.Contains(searchString) || (t.ToUser.FullName.Contains(searchString)));
            }
            return View(tasks.ToList());
        }
        [HttpGet]
        public ActionResult GetArchiveTasks()
        {
            var archiveTasks = db.ArchiveTasks.Include(t => t.FromUser).Include(t => t.ToUser);
            return View(archiveTasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.FromUserId = new SelectList(db.Users, "Id", "FullName");
            ViewBag.ToUserId = new SelectList(db.Users, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FromUserId = new SelectList(db.Users, "Id", "FullName", task.FromUserId);
            ViewBag.ToUserId = new SelectList(db.Users, "Id", "FullName", task.ToUserId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromUserId = new SelectList(db.Users, "Id", "FullName", task.FromUserId);
            ViewBag.ToUserId = new SelectList(db.Users, "Id", "FullName", task.ToUserId);
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task task)
        {
            if (ModelState.IsValid && task.IsDone == true)
            {
                var tasks = from a in db.Tasks
                          select a;
                ArchiveTask archiveTasks = new ArchiveTask();
                foreach (var str in tasks)
                {
                    archiveTasks.Id = str.Id;
                    archiveTasks.StartDateTask = str.StartDateTask;
                    archiveTasks.Description = str.Description;
                    archiveTasks.PlannedStartDate = str.PlannedStartDate;
                    archiveTasks.PlannedCompletionDate = str.PlannedCompletionDate;
                    archiveTasks.StartExecution = str.StartExecution;
                    archiveTasks.IsExecution = str.IsExecution;
                    archiveTasks.IsDone = str.IsDone;
                    archiveTasks.FromUserId = str.FromUserId;
                    archiveTasks.ToUserId = str.ToUserId;
                    
                    db.ArchiveTasks.Add(archiveTasks);
                    //db.Tasks.Remove(db.Tasks.Where(x => x.Id == str.Id).FirstOrDefault());
                    //db.Tasks.Where(x => x.Id == task.Id).Select(t => new ArchiveTask
                }
                var deleteTask = db.Tasks.Single(x => x.Id == task.Id);
                db.Tasks.Remove(deleteTask);

                //db.Tasks.Remove(task);
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.FromUserId = new SelectList(db.Users, "Id", "FullName", task.FromUserId);
            ViewBag.ToUserId = new SelectList(db.Users, "Id", "FullName", task.ToUserId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

/*public ActionResult Edit(Task task)
{
    if (ModelState.IsValid && task.IsDone == true)
    {
        var tasks =
        db.ArchiveTasks.Add(task)
                db.Tasks.Remove(task);
        db.Entry(task).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    ViewBag.FromUserId = new SelectList(db.Users, "Id", "FullName", task.FromUserId);
    ViewBag.ToUserId = new SelectList(db.Users, "Id", "FullName", task.ToUserId);
    return View(task);
}*/

/*public ActionResult Edit(Task task)
{
    ArchiveTask arhivedTask;
    if (ModelState.IsValid && task.IsDone == true)
    {

        arhivedTask = db.Tasks.Where(x => x.Id == task.Id).Select(t => new ArchiveTask
        {
            Id = t.Id,
            StartDateTask = t.StartDateTask,
            Description = t.Description,
            PlannedStartDate = t.PlannedStartDate,
            PlannedCompletionDate = t.PlannedCompletionDate,
            FromUserId = t.FromUserId,
            ToUserId = t.ToUserId,
        }).FirstOrDefault();
        db.ArchiveTasks.Add(arhivedTask);
        db.Tasks.Remove(task);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    ViewBag.FromUserId = new SelectList(db.Users, "Id", "FullName", task.FromUserId);
    ViewBag.ToUserId = new SelectList(db.Users, "Id", "FullName", task.ToUserId);
    return View(task);*/