using Domain.Entities;
using Domain.Persistance;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Linq;

namespace Infrastructure
{
    public class Methods
    {
        /// <summary>
        /// Create static MafiaContext to get Access to DataBase one time
        /// </summary>
        private static MafiaContext context = new();


        /*
          MafiaFamilies Queries
        */

        //---GET
        public static List<MafiaFamily> GetAllMafiaFamilies() 
        {
            return context.MafiaFamilies.ToList();
        }

        public static MafiaFamily GetMafiaFamilyById(int id)
        {
            
            return context.MafiaFamilies.Where(p => (p.Id == id)).Single();
        }

        public static MafiaFamily GetMafiaFamilyByName(string name)
        {
            return context.MafiaFamilies.Where(p => p.Name == name).Single();
        }

        public static List<FamilyMember> GetAllFamilyMembersByMafiaFamiylyId(int id)
        {
            List<FamilyMember> familyMembers = context.FamilyMembers.Where(p => (p.MafiaFamilyId == id) ).ToList();
            return familyMembers;
        }

        
        public static List<Organization> GetAllOrganizationsByMafiaFamilyId(int id)
        {
            List<FamilyMember> members = GetAllFamilyMembersByMafiaFamiylyId(id);

            List<Organization> organizations = GetAllOrganizations();
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
            return familyOrganizations;
        }
        
        public static float CalculateFamilyIncomeByFamilyId(int FamilyId)
        {
             
            List<Organization> FamilyOrganizations = GetAllOrganizationsByMafiaFamilyId(FamilyId);
            float familyIncomesSum = 0;
            foreach (Organization org in FamilyOrganizations)
            {
                if (org.Percent != null && org.Income != null)
                {
                    familyIncomesSum += (float)(org.Income / 100 * org.Percent);
                }
            }

            return familyIncomesSum;
        }

        public static float CalculateFamilyIncomeByFamilyName(string name)
        {
            MafiaFamily mafiaFamily = GetMafiaFamilyByName(name);
            List<Organization> FamilyOrganizations = GetAllOrganizationsByMafiaFamilyId(mafiaFamily.Id);
            float familyIncomesSum = 0;
            foreach (Organization org in FamilyOrganizations)
            {
                if (org.Percent != null && org.Income != null)
                {
                    familyIncomesSum += (float)(org.Income / 100 * org.Percent);
                }
            }
            return familyIncomesSum;
        }

        public static int CalculateFamilyExpencesByFamilyName(string name)
        {
            MafiaFamily mafiaFamily = GetMafiaFamilyByName(name);
            List<Organization> FamilyOrganizations = GetAllOrganizationsByMafiaFamilyId(mafiaFamily.Id);
            int familyExpencesSum = 0;
            foreach (Organization org in FamilyOrganizations)
            {
                if (org.Expenses != null)
                {
                    familyExpencesSum += (int)org.Expenses;
                }
            }
            return familyExpencesSum;
        }

        //---GET
        //---POST
        public static void AddMafiaFamily(int id, string Name, string Description, string ImageURL)
        {
            context.Add(new MafiaFamily
            {
                Id = id,
                Name = Name,
                Description = Description,
                ImageUrl = ImageURL
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

        public static void DeleteMafiaFamilyById(int id)
        {
            try
            {
                context.Remove(GetMafiaFamilyById(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }


        //---POST

        /*
          MafiaFamilies Queries
        */


        /*
          FamilyMembers Queries
        */
        //---GET
        public static List<FamilyMember> GetFamilyMembers()
        {
            return context.FamilyMembers.ToList();
        }

        public static FamilyMember GetFamilyMemberById(int id) 
        {
            return context.FamilyMembers.Where(p => (p.Id == id)).Single();
        }

        public static List<Organization> GetAllFamilyMemberOrganizations(int memberId)
        {
            return context.Organizations.Where(p => p.CollectorId == memberId).ToList();
        }
        //---GET
        //---POST
        public static void AddFamilyMember(int id, int MafiaFamilyId, string FirstName, string SecondName, int Age, int RankId)
        {
            context.FamilyMembers.Add(new FamilyMember
            {
                Id = id,
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

        public static void DeleteFamilyMemberById(int id)
        {
            try
            {
                context.FamilyMembers.Remove(GetFamilyMemberById(id));
                context.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void EditFamilyMemberFirstName(int id, string FirstName)
        {
            FamilyMember member = GetFamilyMemberById(id);
            member.FirstName = FirstName;
            context.SaveChanges();
        }

        public static void EditFamilyMemberSecondName(int id, string SecondName)
        {
            FamilyMember member = GetFamilyMemberById(id);
            member.SecondName = SecondName;
            context.SaveChanges();
        }
        public static void EditFamilyMemberAge(int id, int Age)
        {
            FamilyMember member = GetFamilyMemberById(id);
            member.Age = Age;
            context.SaveChanges();
        }

        public static void EditFamilyRankId(int id, int RankId)
        {

            FamilyMember member = GetFamilyMemberById(id);
            member.RankId = RankId;
            context.SaveChanges();
        }
        //---POST

        /*
          FamilyMembers Queries
        */


        /*
          Organizations Queries
        */

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
        public static void AddOrganization(int id, int OrganizationTypeId, string Name, string Description,
            int Income, int Expences, int Percent, int CollectorId, string ImageURL)
        {
            if (Percent > 0 && Percent < 100 )
            {
                context.Organizations.Add(new Organization
                {
                    Id = id,
                    OrganizationTypeId = OrganizationTypeId,
                    Name = Name,
                    Description = Description,
                    Income = Math.Abs(Income),
                    Expenses = Math.Abs(Expences),
                    Percent = Percent,
                    CollectorId = CollectorId,
                    ImageUrl = ImageURL
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
        }

        
        public static void RemoveCollectorFromOrganization(string name)
        {
            try
            {
                Organization org = GetOrganizationByName(name);
                if (org != null && org.CollectorId != null) 
                {

                    FamilyMember member = GetFamilyMemberById((int)org.CollectorId);
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

        /*
          Organizations Queries
        */
        // для игры

        public static void EditMemberHP(int id, int HP)
        {

            FamilyMember member = GetFamilyMemberById(id);
            member.HP = HP;
            context.SaveChanges();
        }

        public static void EditMemberATK(int id, int ATK)
        {

            FamilyMember member = GetFamilyMemberById(id);
            member.ATK = ATK;
            context.SaveChanges();
        }

        public static FamilyMember SummonFamilyMemberForGame(int id, string Name)
        {
            return GetFamilyMemberById(id);


        }

        public static void FightingBattle(int id,string Name,int HP,int ATK)
        {
            FamilyMember member1 = SummonFamilyMemberForGame(id,Name);
            FamilyMember member2 = SummonFamilyMemberForGame(id, Name);
            int hp1 = member1.HP;
            int hp2 = member2.HP;
            while ((hp1 > 0) | (hp2 > 0))
            {
                hp1 = hp1 - member2.ATK;
                hp2 = hp2 - member1.ATK;
            }
            if (hp1 > hp2)
            {
                EditMemberHP(member1.Id, member1.HP-5);
                EditMemberATK(member1.Id, member1.ATK + 3);
                EditMemberHP(member2.Id, member2.HP - 13);
            }
            else
            {
                EditMemberHP(member2.Id, member2.HP - 5);
                EditMemberATK(member2.Id, member2.ATK + 3);
                EditMemberHP(member1.Id, member1.HP - 13);
            }
        }

        public static void DeleteFamilyMemberByHP(int id, string Name, int HP, int ATK)
        {
            try
            {

                FamilyMember member = SummonFamilyMemberForGame(id, Name);
                if (member.HP == 0)
                {
                    context.FamilyMembers.Remove(member);
                    context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }


    }
}