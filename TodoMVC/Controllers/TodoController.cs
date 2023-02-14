using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Channels;
using System;
using TodoMVC.Models;

namespace TodoMVC.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext db;
        public TodoController(TodoContext _db)
        {
            db= _db;
        }
        public IActionResult Index()
        {
            return View(db.task_status.ToList());
        }
        [HttpPost]
       public void AddTodo(string username,string todo )
        {
            TodoModal tm = new TodoModal();
            tm.username = username; 
            tm.todo = todo;
            tm.working_queue= "";
            tm.completed_task = "";
            tm.completedtime = DateTime.Now;
            tm.status = 0;
            tm.created= DateTime.Now;
            tm.updated= DateTime.Now;

            db.task_status.Add(tm);
            db.SaveChanges();
        }
        [HttpGet]
        public IActionResult EndOfShift()
        {
            var completedTask = db.task_status.Where(x=> x.status == 2).ToList();
            return View(completedTask);
        }

        [HttpPost]
        public void AddWorking(int id)
        {
            var task = db.task_status.Where(x => x.id == id).FirstOrDefault();
            task.working_queue = task.todo;
            task.todo = "";
            task.status = 1;
            db.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        [HttpPost]
        public void AddCompleted(int id)
        {
            var task = db.task_status.Where(x => x.id == id).FirstOrDefault();
            task.completed_task = task.working_queue;
            task.working_queue = "";
            task.status = 2;
            db.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
