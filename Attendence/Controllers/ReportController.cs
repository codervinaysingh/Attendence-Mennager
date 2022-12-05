using Attendence.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace Attendence.Controllers
{
    public class ReportController : Controller
    {
        private readonly IStudentRegister _register;

        public ReportController(IStudentRegister  register)
        {
            _register = register;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(DateTime date)
        {
            var today = date.ToShortDateString();     
            var res = _register.GetReport(today);
            List<Report> reportList = JsonConvert.DeserializeObject<List<Report>>(res);
            return View(reportList);
        }
    }
}
