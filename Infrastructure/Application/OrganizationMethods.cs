using Domain.Entities;
using Domain.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OrganizationMethods
    {
        private static readonly MafiaContext context = new MafiaContext();

        //---GET
        public static List<Organization> GetAllOrganizations()
        {
            return context.Organizations.ToList();
        }

        public static List<Organization> GetAllOrganizationsWithouotCollector()
        {
            List<Organization> organizations = new List<Organization>();
            foreach (Organization org in context.Organizations)
            {
                if (org.CollectorId == null)
                {
                    organizations.Add(org);
                }
            }
            return organizations;
        }



        public static Organization GetOrganizationById(int id)
        {
            return context.Organizations.Where(p => (p.Id == id)).Single();
        }

        public static Organization GetOrganizationByName(string name)
        {
            return context.Organizations.Where(p => (p.Name == name)).Single();
        }
        //---GET

        //---POST

        public static void AddOrganization(string Name, int Income, int? FamilyId)
        {
            int membersCount = 1;
            List<FamilyMember> members = new List<FamilyMember>();
            if (FamilyId != null)
            {
                members = MafiaFamilyMethods.GetAllFamilyMembersByMafiaFamiylyId((int)FamilyId);
                membersCount = (members.Count() == 0 ? 1 : members.Count);
            }

            context.Organizations.Add(new Organization
            {
                OrganizationTypeId = 5,
                Name = Name,
                Description = "Мы пока что мало знаем о данной организации",
                Income = Income,
                Expenses = Income / 1 + new Random(1).Next(10),
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

        public static void EditOrganizationTypeId(int id, int OrganizationTypeId)
        {
            try
            {
                GetOrganizationById(id).OrganizationTypeId = OrganizationTypeId;
                context.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");
            }
        }


        public static void EditOrganizationName(int id, string Name)
        {
            try
            {
                GetOrganizationById(id).Name = Name;
                context.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void EditOrganizationDescription(int id, string Description)
        {
            Organization part = GetOrganizationById(id);
            part.Description = Description;
            context.SaveChanges();
        }
        public static void EditOrganizationIncome(int id, int Income)
        {
            try
            {
                GetOrganizationById(id).Income = Income;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public static void EditOrganizationExpenses(int id, int Expenses)
        {
            try
            {
                GetOrganizationById(id).Expenses = Expenses;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public static void EditOrganizationPercent(int id, int Percent)
        {
            try
            {
                GetOrganizationById(id).Percent = Percent;
                context.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public static void EditOrganizationCollectorId(int id, int CollectorId)
        {
            try
            {
                Organization org = GetOrganizationById(id);
                if (org.CollectorId != null)
                {
                    FamilyMember Collector = FamilyMemberMethods.GetFamilyMemberById((int)org.CollectorId);
                    Collector.Organizations.Remove(org);
                }
                org.CollectorId = CollectorId;
                FamilyMember newCollector = FamilyMemberMethods.GetFamilyMemberById((int)org.CollectorId);
                newCollector.Organizations.Add(org);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public static void EditOrganizationImageUrl(int id, string ImageUrl)
        {
            try
            {
                GetOrganizationById(id).ImageUrl = ImageUrl;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void RemoveCollectorFromOrganization(string name)
        {
            try
            {
                Organization org = GetOrganizationByName(name);
                if (org != null && org.CollectorId != null)
                {

                    FamilyMember member = FamilyMemberMethods.GetFamilyMemberById((int)org.CollectorId);
                    org.CollectorId = null;
                    member.Organizations.Remove(org);

                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        //---POST

    }
}
