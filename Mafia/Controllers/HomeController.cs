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
        public ActionResult GetAllMafiaFamilies()
        {
            return Ok(JsonSerializer.Serialize(context.MafiaFamilies.ToList(), options));
        }
        public ActionResult GetMafiaFamilyById(int id)
        {
            MafiaFamily mafiaFamily = context.MafiaFamilies.Where(p => p.Id == id).Single();
            if (mafiaFamily == null) return NotFound("Не существует семьи под именем " + id);
            return Ok(JsonSerializer.Serialize(mafiaFamily, options));
        }

        public ActionResult GetMafiaFamilyByName(string name)
        {
            MafiaFamily mafiaFamily = context.MafiaFamilies.Where(p => p.Name == name).Single();
            if (mafiaFamily == null) return NotFound("Не существует семьи под именем " + name);
            return Ok(JsonSerializer.Serialize(context.MafiaFamilies.Where(p => p.Name == name).Single(), options));
        }

        public ActionResult GetAllFamilyMembersByMafiaFamiylyId(int id)
        {
            List<FamilyMember> members = context.FamilyMembers.Where(p => p.MafiaFamilyId == id).ToList();
            if (members == null) return NotFound("Не найдены участники у семьи под id " + id);
            return Ok(JsonSerializer.Serialize(members, options));
        }

        public ActionResult GetAllOrganizationsByMafiaFamilyId(int id)
        {
            List < FamilyMember > members = context.FamilyMembers.Where(p => p.MafiaFamilyId == id).ToList();

            List<Organization> organizations = context.Organizations.ToList();
            List<Organization> familyOrganizations = new ();

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
            return Ok(JsonSerializer.Serialize(familyOrganizations, options));
        }

        public ActionResult GetAllOrganizationsByMafiaFamilyName(string name)
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
            return Ok(JsonSerializer.Serialize(familyOrganizations, options));
        }

        public ActionResult CalculateFamilyIncomeByFamilyId(int id)
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

            return Ok(JsonSerializer.Serialize(sum, options)); 
        }

        /*
        public string CalclulateFamilyIncomeByFamilyName(string familyName)
        {
            return JsonSerializer.Serialize(Infrastructure.MafiaFamilyMethods.CalculateFamilyIncomeByFamilyName(familyName), options);
        }
        */
        //---GET
        //--POST
        public ActionResult AddMafiaFamily(string Name)
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
                return Ok("Запрос выполнен");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return BadRequest(ex.Message);
            };
        }

        public ActionResult DeleteMafiaFamilyById(int id) 
        {
            try
            {
                context.Remove(GetMafiaFamilyById(id));
                context.SaveChanges();
                return Ok("Запрос выполнен");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        //--POST

        /*
          MafiaFamily Queries
        */

        /*
          FamilyMembers Queries
        */
        //---GET
        public ActionResult GetAllFamilyMembers()
        {
            return Ok(JsonSerializer.Serialize(context.FamilyMembers.ToList(), options));
        }

        public ActionResult GetFamilyMemberById(int id)
        {
            FamilyMember member = context.FamilyMembers.Where(p => p.Id == id).Single();
            if (member == null) return NotFound("Такой член семьи не найден");
            return Ok(JsonSerializer.Serialize(member, options));
        }

        //---GET

        //--POST
        public ActionResult AddFamilyMember(int MafiaFamilyId, string FirstName, string SecondName, int Age, int RankId)
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
                return Ok("Запрос выполнен успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        public ActionResult DeleteFamilyMemberById(int id)
        {
            try
            {
                context.FamilyMembers.Remove(context.FamilyMembers.Where(p => p.Id == id).Single());
                context.SaveChanges();
                return Ok("Запрос выполнен успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return BadRequest(ex.Message);
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
        [HttpGet]
        public IActionResult GetAllOrganizations()
        {
            return Ok(JsonSerializer.Serialize(context.Organizations.ToList().OrderBy(p => p.Id), options));
        }

        public ActionResult GetAllOrganizationsWithoutCollector()
        {
            return Ok(JsonSerializer.Serialize(context.Organizations.Where(p => p.CollectorId == null).ToList(), options));
        }

        public string GetOrganizationById(int id)
        {
            return JsonSerializer.Serialize(context.Organizations.Where(p => (p.Id == id)).Single(), options);
        }
        //---GET

        //--POST
        public ActionResult AddOrganization(string Name, int Income, int? FamilyId = null)
        {
            int membersCount = 1;
            List<FamilyMember> members = new List<FamilyMember>();
            if (FamilyId != null)
            {
                members = members = context.FamilyMembers.Where(p => p.MafiaFamilyId == FamilyId).ToList();
                membersCount = (members.Count() == 0 ? 1 : members.Count);
            }
            if (Name.Length <= 0 || Name.Length > 50) return BadRequest("Неправильно введено имя");
            if (Income < 0) return BadRequest("Неправильно введённый доход");
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
                return Ok("Запрос прошёл успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
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
        public ActionResult DeleteOrganizationById(int id)
        {
            try
            {
                Organization org = context.Organizations.Where(p => p.Id == id).Single();
                if (org == null) { return NotFound("Не найдена организация"); }
                context.Organizations.Remove(org);
                context.SaveChanges();
                return Ok("Организация удалена");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }
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