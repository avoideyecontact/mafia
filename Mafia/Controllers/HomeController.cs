using Domain;
using Domain.Entities;
using Domain.Persistance;
using Infrastructure;
using Mafia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Xml.Linq;

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
        private readonly MafiaContext context = new ();

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
            return JsonSerializer.Serialize(context.MafiaFamilies.ToList(), options);
        }
        public string GetMafiaFamilyById(int id)
        {
            return JsonSerializer.Serialize(context.MafiaFamilies.Where(p => (p.Id == id)).Single(), options);
        }

        public string GetMafiaFamilyByName(string name)
        {
            return JsonSerializer.Serialize(context.MafiaFamilies.Where(p => p.Name == name).Single(), options);
        }

        public string GetAllFamilyMembersByMafiaFamiylyId(int id)
        {
            List<FamilyMember> members = context.FamilyMembers.Where(p => p.MafiaFamilyId == id).ToList();
            return JsonSerializer.Serialize(members, options);
        }

        public string GetAllOrganizationsByMafiaFamilyId(int id)
        {
            List < FamilyMember > members = context.FamilyMembers.Where(p => p.MafiaFamilyId == id).ToList();

            List<Organization> organizations = context.Organizations.ToList();
            List<Organization> familyOrganizations = new List<Organization>();

            foreach (Organization organization in organizations)
            {
                foreach (FamilyMember member in members)
                {
                    if (organization.CollectorId == member.Id)
                    {
                        familyOrganizations.Add(organization);
                    }
                }
            }
            return JsonSerializer.Serialize(familyOrganizations, options);
        }

        public string GetAllOrganizationsByMafiaFamilyName(string name)
        {
            List<FamilyMember> members = context.MafiaFamilies.Where(p => (p.Name == name)).Single().FamilyMembers.ToList();

            List<Organization> organizations = context.Organizations.ToList();
            List<Organization> familyOrganizations = new List<Organization>();

            foreach (Organization organization in organizations)
            {
                foreach (FamilyMember member in members)
                {
                    if (organization.CollectorId == member.Id)
                    {
                        familyOrganizations.Add(organization);
                    }
                }
            }
            return JsonSerializer.Serialize(familyOrganizations, options);
        }

        public string CalculateFamilyIncomeByFamilyId(int id)
        {
            List<Organization> familyOrganization = new List<Organization>();
            List<FamilyMember> members = context.FamilyMembers.Where(p => p.MafiaFamilyId == id).ToList();
            List<Organization> organizations = context.Organizations.ToList();
            foreach (Organization organization in organizations)
            {
                foreach (FamilyMember member in members)
                {
                    if (organization.CollectorId == member.Id)
                    {
                        familyOrganization.Add(organization);
                    }
                }
            }
            float sum = 0;
            foreach (Organization org in familyOrganization)
            {
                sum += (float)(org.Income / 100 * org.Percent);
            }

            return JsonSerializer.Serialize(sum, options); 
        }

        /*
        public string CalclulateFamilyIncomeByFamilyName(string familyName)
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.CalculateFamilyIncomeByFamilyName(familyName), options);
        }
        */
        //---GET
        //--POST
        public void AddMafiaFamily(string Name)
        {
            context.Add(new MafiaFamily
            {
                Name = Name,
                Description = "Эта семья молодая, мы ничего о ней пока не знаем",
                ImageUrl = "../Img/NonameFamily.png"
            });
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            };
        }

        public void DeleteMafiaFamilyById(int id) 
        {
            try
            {
                context.Remove(GetMafiaFamilyById(id));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void EditMafiaFamilyName(int id, string Name)
        {
            Infrastructure.MafiaFamilyMethods.EditMafaFamilyName(id, Name);
        }

        public void EditMafiaFamilyDescription(int id, string Description)
        {
            Infrastructure.MafiaFamilyMethods.EditMafiaFamilyDescription(id, Description);
        }

        public void EditMafiaFamilyImageUrl(int id, string ImageUrl)
        {
            Infrastructure.MafiaFamilyMethods.EditMafiaFamilyImageUrl(id, ImageUrl);
        }

        //--POST

        /*
          MafiaFamily Queries
        */

        /*
          FamilyMembers Queries
        */
        //---GET
        public string GetAllFamilyMembers()
        {
            return JsonSerializer.Serialize(context.FamilyMembers.ToList(), options);
        }

        public string GetFamilyMemberById(int id)
        {
            return JsonSerializer.Serialize(context.FamilyMembers.Where(p => p.Id == id).Single(), options);
        }

        //---GET

        //--POST
        public void AddFamilyMember(int MafiaFamilyId, string FirstName, string SecondName, int Age, int RankId)
        {
            context.FamilyMembers.Add(new FamilyMember
            {
                MafiaFamilyId = MafiaFamilyId,
                FirstName = FirstName,
                SecondName = SecondName,
                Age = Age,
                RankId = RankId
            });
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void DeleteFamilyMemberById(int id)
        {
            try
            {
                context.FamilyMembers.Remove(context.FamilyMembers.Where(p => p.Id == id).Single());
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
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
            return JsonSerializer.Serialize(context.Organizations.ToList(), options);
        }

        public string GetAllOrganizationsWithoutCollector()
        {
            return JsonSerializer.Serialize(context.Organizations.Where(p => p.CollectorId == null).ToList(), options);
        }

        public string GetOrganizationById(int id)
        {
            return JsonSerializer.Serialize(context.Organizations.Where(p => (p.Id == id)).Single(), options);
        }
        //---GET

        //--POST
        public void AddOrganization(string Name, int Income, int? FamilyId = null)
        {
            int membersCount = 1;
            List<FamilyMember> members = new List<FamilyMember>();
            if (FamilyId != null)
            {
                members = members = context.FamilyMembers.Where(p => p.MafiaFamilyId == FamilyId).ToList();
                membersCount = (members.Count() == 0 ? 1 : members.Count);
            }

            context.Organizations.Add(new Organization
            {
                OrganizationTypeId = 5,
                Name = Name,
                Description = "Мы пока что мало знаем о данной организации",
                Income = Income,
                Expenses = Income / (1 + new Random(1).Next(10)),
                Percent = 10,
                CollectorId = FamilyId == null || membersCount == 0 ? null : members[new Random(1).Next(members.Count) % membersCount].Id,
                ImageUrl = "../Img/NonameCompany.png"
            });
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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