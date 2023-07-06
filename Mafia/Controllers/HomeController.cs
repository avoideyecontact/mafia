using Domain;
using Domain.Entities;
using Domain.Persistance;
using Mafia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Mafia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Create static JsonSeriliazerOptions to economy memory
        /// </summary>
        private static JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        /*
          MafiaFamily Queries
        */
        public string GetAllMafiaFamilies()
        {
            return JsonSerializer.Serialize(Infrastructure.Methods.GetAllMafiaFamilies(), options);
        }
        public string GetMafiaFamilyById(int id)
        {
            return JsonSerializer.Serialize(Infrastructure.Methods.GetMafiaFamilyById(id), options);
        }

        public string GetAllFamilyMembersByMafiaFamiylyId(int id)
        {
            return JsonSerializer.Serialize(Infrastructure.Methods.GetAllFamilyMembersByMafiaFamiylyId(id), options);
        }

        public string GetAllOrganizationsByMafiaFamilyId(int id)
        {
            return JsonSerializer.Serialize(Infrastructure.Methods.GetAllOrganizationsByMafiaFamilyId(id), options);
        }

        public string CalculateFamilyIncome(int FamilyId)
        {
            return JsonSerializer.Serialize(Infrastructure.Methods.CalculateFamilyIncome(FamilyId), options);
        }
        /*
          MafiaFamily Queries
        */

        /*
          FamilyMembers Queries
        */
        public string GetFamilyMembers()
        {
            return JsonSerializer.Serialize(GetFamilyMembers(), options);
        }

        public string GetFamilyMemberById(int id)
        {
            return JsonSerializer.Serialize(GetFamilyMemberById(id), options);
        }

        public void AddFamilyMember(int id, int MafiaFamilyId, string FirstName, string SecondName, int Age, int RankId)
        {
            Infrastructure.Methods.AddFamilyMember(id, MafiaFamilyId, FirstName, SecondName, Age, RankId);
        }

        public void EditFamilyMemberFirstName(int id, string FirstName)
        {
            Infrastructure.Methods.EditFamilyMemberFirstName(id, FirstName);
        }

        /*
          FamilyMembers Queries
        */

        /*
          Organizations Queries
        */
        public string GetAllOrganizations()
        {
            return JsonSerializer.Serialize(Infrastructure.Methods.GetAllOrganizations(), options);
        }

        public string GetOrganizationById(int id)
        {
            return JsonSerializer.Serialize(Infrastructure.Methods.GetOrganizationById(id), options);
        }

        public void AddOrganization(int id, int OrganizationTypeId, string Name, string Description,
            int Income, int Expences, int Percent, int CollectorId, string ImageURL)
        {
            Infrastructure.Methods.AddOrganization(id, OrganizationTypeId, Name, Description,
            Income, Expences, Percent, CollectorId, ImageURL);
        }
        /*
          Organizations Queries
        */


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