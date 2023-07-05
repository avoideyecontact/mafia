using Domain.Entities;
using Domain.Persistance;
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
        

        public static int CalculateFamilyIncome(int id)
        {
            /*
             
            MafiaFamily family = context.MafiaFamilies.Where(p => (p.Id == id)).Single();
            int familyIncomesSum = 0;
            */
            


            return 0;
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
        /*
          Organizations Queries
        */



    }
}