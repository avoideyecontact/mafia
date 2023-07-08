using Domain;
using Domain.Entities;
using Domain.Persistance;
using Mafia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Mafia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Create static JsonSeriliazerOptions to economy memory
        /// </summary>
        private static readonly JsonSerializerOptions options = new()
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

        //---GET
        public string GetAllMafiaFamilies()
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.GetAllMafiaFamilies(), options);
        }
        public string GetMafiaFamilyById(int id)
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.GetMafiaFamilyById(id), options);
        }

        public string GetMafiaFamilyByName(string name)
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.GetMafiaFamilyByName(name), options);
        }

        public string GetAllFamilyMembersByMafiaFamiylyId(int id)
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.GetAllFamilyMembersByMafiaFamiylyId(id), options);
        }

        public string GetAllOrganizationsByMafiaFamilyId(int id)
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.GetAllOrganizationsByMafiaFamilyId(id), options);
        }

        public string GetAllOrganizationsByMafiaFamilyName(string name)
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.GetAllOrganizationsByMafiaFamilyName(name), options);
        }

        public string CalculateFamilyIncomeByFamilyId(int FamilyId)
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.CalculateFamilyIncomeByFamilyId(FamilyId), options);
        }

        public string CalclulateFamilyIncomeByFamilyName(string familyName)
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.CalculateFamilyIncomeByFamilyName(familyName), options);
        }
        //---GET
        //--POST
        public void AddMafiaFamily(string Name)
        {
            Infrastructure.MafiaFamilyMethods.AddMafiaFamily(Name);
        }

        public void DeleteMafiaFamilyById(int id) 
        {
            Infrastructure.MafiaFamilyMethods.DeleteMafiaFamilyById(id);
        }

        public void EditMafiaFamilyName(int id, string Name)
        {

        }

        public void EditMafiaFamilyDescription(int id, string Description)
        {

        }

        public void EditMafiaFamilyImageUrl(int id, string ImageUrl)
        {

        }

        //--POST

        /*
          MafiaFamily Queries
        */

        /*
          FamilyMembers Queries
        */
        //---GET
        public string GetFamilyMembers()
        {
            return JsonSerializer.Serialize(Infrastructure.FamilyMemberMethods.GetFamilyMembers(), options);
        }

        public string GetFamilyMemberById(int id)
        {
            return JsonSerializer.Serialize(Infrastructure.FamilyMemberMethods.GetFamilyMemberById(id), options);
        }

        //---GET

        //--POST
        public void AddFamilyMember(int MafiaFamilyId, string FirstName, string SecondName, int Age, int RankId)
        {
            Infrastructure.FamilyMemberMethods.AddFamilyMember(MafiaFamilyId, FirstName, SecondName, Age, RankId);
        }

        public void DeleteFamilyMemberById(int id)
        {
            Infrastructure.FamilyMemberMethods.DeleteFamilyMemberById(id);
        }

        public void EditFamilyMemberFirstName(int id, string FirstName)
        {
            Infrastructure.FamilyMemberMethods.EditFamilyMemberFirstName(id, FirstName);
        }

        public void EditFamilyMemberSecondName(int id, string SecondName)
        {
            Infrastructure.FamilyMemberMethods.EditFamilyMemberSecondName(id, SecondName);
        }
        public void EditFamilyMemberAge(int id, int Age)
        {
            Infrastructure.FamilyMemberMethods.EditFamilyMemberAge(id, Age);
        }

        public void EditFamilyMemberRankId(int id, int RankId)
        {
            Infrastructure.FamilyMemberMethods.EditFamilyMemberRankId(id, RankId);
        }

        //--POST
        /*
          FamilyMembers Queries
        */

        /*
          Organizations Queries
        */
        //---GET
        public string GetAllOrganizations()
        {
            return JsonSerializer.Serialize(Infrastructure.OrganizationMethods.GetAllOrganizations(), options);
        }

        public string GetAllOrganizationsWithoutCollector()
        {
            return JsonSerializer.Serialize(Infrastructure.OrganizationMethods.GetAllOrganizationsWithouotCollector(), options);
        }

        public string GetOrganizationById(int id)
        {
            return JsonSerializer.Serialize(Infrastructure.OrganizationMethods.GetOrganizationById(id), options);
        }
        //---GET

        //--POST
        public void AddOrganization(string Name, int Income, int? FamilyId = null)
        {
            Infrastructure.OrganizationMethods.AddOrganization(Name, Income, FamilyId);
        }

        /*
        public void AddOrganization(int id, int OrganizationTypeId, string Name, string Description,
            int Income, int Expences, int Percent, int CollectorId, string ImageURL = "")
        {
            Infrastructure.Methods.AddOrganization(id, OrganizationTypeId, Name, Description,
            Income, Expences, Percent, CollectorId, ImageURL);
        }
         */

        public void EditOrganizationTypeId(int id, int OrganizationTypeId)
        {
            Infrastructure.OrganizationMethods.EditOrganizationTypeId(id, OrganizationTypeId);
        }

        public void EditOrganizationName(int id, string Name)
        {
            Infrastructure.OrganizationMethods.EditOrganizationName(id, Name);
        }

        public void EditOrganizationDescription(int id, string Description)
        {
            Infrastructure.OrganizationMethods.EditOrganizationDescription(id, Description);
        }
        public void EditOrganizationIncome(int id, int Income)
        {
            Infrastructure.OrganizationMethods.EditOrganizationIncome(id, Income);
        }
        public void EditOrganizationExpenses(int id, int Expenses)
        {
            Infrastructure.OrganizationMethods.EditOrganizationExpenses(id, Expenses);
        }
        public void EditOrganizationPercent(int id, int Percent)
        {
            Infrastructure.OrganizationMethods.EditOrganizationPercent(id, Percent);
        }
        public void EditOrganizationCollectorId(int id, int CollectorId)
        {
            Infrastructure.OrganizationMethods.EditOrganizationCollectorId(id, CollectorId);
        }
        public static void EditOrganizationImageUrl(int id, string ImageUrl)
        {
            Infrastructure.OrganizationMethods.EditOrganizationImageUrl(id, ImageUrl);
        }

        public void RemoveCollectorFromOrganization(string OrganizationName)
        {
            Infrastructure.OrganizationMethods.RemoveCollectorFromOrganization(OrganizationName);
        }


        //--POST
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