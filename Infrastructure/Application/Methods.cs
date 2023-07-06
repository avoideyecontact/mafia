using Domain.Entities;
using Domain.Persistance;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

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
        public static List<MafiaFamily> GetAllMafiaFamilies() 
        {
            return context.MafiaFamilies.ToList();
        }

        public static MafiaFamily GetMafiaFamilyById(int id)
        {
            
            return context.MafiaFamilies.Where(p => (p.Id == id)).Single();
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
        
        public static float CalculateFamilyIncome(int FamilyId)
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

        /*
          MafiaFamilies Queries
        */


        /*
          FamilyMembers Queries
        */
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
                Console.WriteLine(ex.Message);
            }
        }

        public static void EditFamilyMemberFirstName(int id, string FirstName)
        {
            FamilyMember member = GetFamilyMemberById(id);
            member.FirstName = FirstName;
            context.SaveChanges();
        }

        /*
          FamilyMembers Queries
        */


        /*
          Organizations Queries
        */
        public static List<Organization> GetAllOrganizations()
        {
            return context.Organizations.ToList();
        }

        public static Organization GetOrganizationById(int id)
        {
            return context.Organizations.Where(p => (p.Id == id)).Single();
        }

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
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public static void EditOrganization(int id, int OrganizationTypeId, string Name, string Description,
            int Income, int Expences, int Percent, int CollectorId, string ImageURL)
        {

        }
        /*
          Organizations Queries
        */



    }
}