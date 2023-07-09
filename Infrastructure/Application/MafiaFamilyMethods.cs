using Domain.Entities;
using Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Infrastructure
{

    public class MafiaFamilyMethods
    {
        //---GET
        private static readonly MafiaContext context = new MafiaContext();

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
            MafiaFamily mafiaFamily = GetMafiaFamilyById(id);
            if (mafiaFamily != null) return mafiaFamily.FamilyMembers.ToList();
            return new List<FamilyMember>();
        }


        public static List<Organization> GetAllOrganizationsByMafiaFamilyId(int id)
        {
            List<FamilyMember> members = GetAllFamilyMembersByMafiaFamiylyId(id);

            List<Organization> organizations = OrganizationMethods.GetAllOrganizations();
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

        public static List<Organization> GetAllOrganizationsByMafiaFamilyName(string name)
        {
            List<Organization> familyOrganizations = new();
            try
            {
                MafiaFamily family = GetMafiaFamilyByName(name);
                if (family != null)
                {
                    List<FamilyMember> members = GetAllFamilyMembersByMafiaFamiylyId(family.Id);
                    List<Organization> organizations = OrganizationMethods.GetAllOrganizations();
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
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            return familyOrganizations;
        }

        public static float CalculateFamilyIncomeByFamilyId(int FamilyId)
        {
            List<FamilyMember> members = context.FamilyMembers.Where(p => (p.MafiaFamilyId == FamilyId)).ToList();
            List<Organization> organizations = new ();
            foreach (FamilyMember member in members)
            {
                foreach (Organization org in member.Organizations)
                {
                    organizations.Add(org);
                }
            }
            float familyIncomesSum = 0;
            foreach (Organization org in organizations)
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

        public static void AddMafiaFamily(string Name)
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
            }
        }

        public static void DeleteMafiaFamilyById(int id)
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

        public static void EditMafaFamilyName(int id, string Name)
        {
            try
            {
                GetMafiaFamilyById(id).Name = Name;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void EditMafiaFamilyDescription(int id, string Description)
        {
            try
            {
                GetMafiaFamilyById(id).Description = Description;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void EditMafiaFamilyImageUrl(int id, string ImageUrl)
        {
            try
            {
                GetMafiaFamilyById(id).ImageUrl = ImageUrl;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
