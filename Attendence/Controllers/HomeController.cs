using Attendence.Models;
using Attendence.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;


namespace Attendence.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRegister _dalReg;

       
        public HomeController(ILogger<HomeController> logger, IStudentRegister dalReg)
        {
            _logger = logger;
            this._dalReg = dalReg;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Register obj)

        {
            if (obj.ContactNumber!=null)
            {
                var res=_dalReg.SearchStudent(obj);
                List<Register> register = JsonConvert.DeserializeObject<List<Register>>(res);
                return View(register);
            }
            else
            {
                return View(null);
            }
        }
        [HttpPost]
        public IActionResult Attend(Register obj)
        {    
            var res= _dalReg.Attendence(obj);
            List<Register> response = JsonConvert.DeserializeObject<List<Register>>(res);
            return View("Index",response);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register obj)
        {
            if (obj.StudentName!=null && obj.ContactNumber!=null)
            {
                var res=_dalReg.AddStudent(obj);
               
                return View();
            }
            else

            {
                return RedirectToAction("Register");
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}