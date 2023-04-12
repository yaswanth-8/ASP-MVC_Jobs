using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEB_APPLICATION.Models;
using Microsoft.Data.SqlClient;

namespace WEB_APPLICATION.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //  DBManager dbMan = new DBManager("Job");
            // List<T> read = dbMan.runQuery("SELECT * FROM Jobs",reader=>{
            //     Console.WriteLine("reader"+reader["JobId"].ToString());
            // });
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}