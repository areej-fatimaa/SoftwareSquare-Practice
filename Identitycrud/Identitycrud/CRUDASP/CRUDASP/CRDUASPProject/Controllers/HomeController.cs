using CRDUASPProject.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Diagnostics;

namespace CRDUASPProject.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public HomeController(ILogger<HomeController> logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult abc()
        {
            try
            {
                throw new Exception("lalalala");
            }
            catch (Exception ex) {
                LogManager.GetCurrentClassLogger().Error(ex, "An error occurred khfjkfhjin the Abc action.");
                LogManager.GetCurrentClassLogger().Info("Test log message.");
            }
            Thread.Sleep(2000);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}