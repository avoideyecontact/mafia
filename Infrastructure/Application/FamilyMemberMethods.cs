using Domain.Entities;
using Domain.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FamilyMemberMethods
    {
        private static readonly MafiaContext context = MafiaContext.getInstance();

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

        public static void AddFamilyMember(int MafiaFamilyId, string FirstName, string SecondName, int Age, int RankId)
        {
            context.FamilyMembers.Add(new FamilyMember
            {
                Id = context.FamilyMembers.Count() + 1,
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
            try
            {
                GetFamilyMemberById(id).FirstName = FirstName;
                context.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");   
            }
        }

        public static void EditFamilyMemberSecondName(int id, string SecondName)
        {
            try
            {
                GetFamilyMemberById(id).SecondName = SecondName;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
        public static void EditFamilyMemberAge(int id, int Age)
        {
            try
            {
                GetFamilyMemberById(id).Age = Age;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void EditFamilyMemberRankId(int id, int RankId)
        {
            try
            {
                GetFamilyMemberById(id).RankId = RankId;
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
