using Domain;
using Domain.Persistance;
using System.Text.Json;

namespace Infrastructure
{
    public class Methods
    {
        private static MafiaContext context = new MafiaContext();
        public static string GetAllMafiaFamiliesAsString() 
        {
            string jsonFamilies = "";
            List<MafiaFamily> families = context.MafiaFamilies.ToList();
            foreach (var family in families)
            {
                jsonFamilies += JsonSerializer.Serialize(family.Id) + "\n";
            }
            return jsonFamilies;
        }

        public static string GetAllOrganizationsAsString()
        {
            string jsonOrganizations = "";
            List<Organization> organizations = context.Organizations.ToList();
            foreach (var organization in organizations)
            {
                jsonOrganizations += JsonSerializer.Serialize(organization) + "\n";
            }
            return jsonOrganizations;
        }
    }
}