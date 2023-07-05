using Domain;
using Domain.Persistance;
using Mafia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mafia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string GetAllMafiaFamilies()
        {
            return Infrastructure.Methods.GetAllMafiaFamiliesAsString();
        }

        public string GetAllOrganizations()
        {
            return Infrastructure.Methods.GetAllOrganizationsAsString();
        }

        public string GetMafiaFamilyById(int id)
        {
            return Infrastructure.Methods.GetMafiaFamilyByIdAsString(id);
        }

        public string GetOrganizationById(int id)
        {
            return Infrastructure.Methods.GetOrganizationByIdAsString(id);
        }

        public ActionResult Index()
        {
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