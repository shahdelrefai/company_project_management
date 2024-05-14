using CompanyTasksManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyTasksManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataAccess dal = new DataAccess();
        private readonly PasswordHashService _passwordHashService = new PasswordHashService();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                return View("~/Views/Personal/Dashboard.cshtml");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Login()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                return View("~/Views/Personal/Dashboard.cshtml");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult AuthenticateLogin([Bind("Username,Password")] User user)
        {
            user.Password = _passwordHashService.HashPassword(user.Password);

            if(dal.ReturnIfUsernameFound(user.Username))
            {
                if(_passwordHashService.VerifyPassword(user.Password, dal.GetHashedPassword(user.Username)))
                {
                    user.Id = dal.GetUserIdByUsername(user.Username);
                    user.Name = dal.GetNameByUsername(user.Username);
                    user.AccountType = dal.GetAccountTypeByUeserId((int)user.Id);
                    user.Authority = dal.GetAuthorityeByUeserId((int) user.Id);

                    HttpContext.Session.SetInt32("UserId", (int) user.Id);
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Name", user.Name);
                    HttpContext.Session.SetString("type", user.AccountType);
                    HttpContext.Session.SetInt32("Authority", (int) user.Authority);

                    return View("~/Views/Personal/Dashboard.cshtml", user);
                }

                return View("Login");
            }

            return View("Login");


        }

        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUpUser([Bind("Name, Username, Email, Password")] User user)
        {
            bool isUsernameAvailable = !(dal.ReturnIfUsernameFound(user.Username));
            bool isEmailAvaiable = dal.ReturnIfEmailFound(user.Email);

            if (isUsernameAvailable && isEmailAvaiable)
            {
                user.Password = _passwordHashService.HashPassword(user.Password);
                dal.AddUserAcc(user);
                return View("SignUpCompleted", user);
            }
            if (!isUsernameAvailable)
            {
                user.Username = "unavailable";
            }
            if (!isEmailAvaiable)
            {
                user.Email = "unavailable";
            }

            return View("SignUpAgain", user);
        }


        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}