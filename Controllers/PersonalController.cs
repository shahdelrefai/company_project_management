using CompanyTasksManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyTasksManagement.Controllers
{
    public class PersonalController : Controller
    {
        private readonly DataAccess dal = new DataAccess();
        public IActionResult Dashboard()
        {
            User user = new User();
            user.Name = HttpContext.Session.GetString("Name");
            user.AccountType = HttpContext.Session.GetString("type");
            return View(user);
        }

        public IActionResult Admin()
        {
            ForAdmin forAdmin = new ForAdmin();
            forAdmin.Tasks =  dal.GetAllUserTasks();
            forAdmin.Users = dal.GetAllUsers();
           
            return View(forAdmin);
        }

        public IActionResult EditUser(int userId) 
        {
            User user = new User();
            user = dal.GetUserByUserId(userId);
            
            return View(user); 
        }

        public IActionResult Today()
        {
            User user = new User();
            user.Tasks = dal.GetTodayTasksByUserId(HttpContext.Session.GetInt32("UserId"));
            
            return View(user);
        }

        public IActionResult AddTaskForToday([Bind("Name, Summary, Details, Deadline")] TaskM newTask)
        {
            newTask.AssignFor = HttpContext.Session.GetInt32("UserId");
            newTask.AssignBy = HttpContext.Session.GetInt32("UserId");
            newTask.SetForDate = DateTime.Now;
       
            dal.AddTask(newTask);
            return RedirectToAction("Today");
        }

        public IActionResult AllTasks()
        {
            User user = new User();
            user.Tasks = dal.GetTasksByUserId(HttpContext.Session.GetInt32("UserId"));

            return View(user);
        }

        public IActionResult AddTask([Bind("Name, Summary, Details, SetForDate, Deadline")] TaskM newTask)
        {
            newTask.AssignFor = HttpContext.Session.GetInt32("UserId");
            newTask.AssignBy = HttpContext.Session.GetInt32("UserId");

            dal.AddTask(newTask);
            return RedirectToAction("AllTasks");
        }
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
