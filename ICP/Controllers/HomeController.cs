using ICP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ICP.Controllers
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
            return View();
        }

        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/VerificationCategories")]
        public IActionResult VerificationCategories()
        {
            return View();
        }

        [Route("/VerificationCategory")]
        public IActionResult VerificationCategory(int categoryId)
        {
            return View();
        }

        [Route("/EMIRATESID")]
        public IActionResult Emiratesid()
        {
            return View();
        }

        [Route("/Questionnaire")]
        public IActionResult Questionnaire()
        {
            return View();
        }

        [Route("/QuestionnaireProgress")]
        public IActionResult QuestionnaireProgress()
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
