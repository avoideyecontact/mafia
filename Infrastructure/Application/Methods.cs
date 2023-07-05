using Domain.Entities;
using Domain.Persistance;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Infrastructure
{
    public class Methods
    {
        private static MafiaContext context = new MafiaContext();
        private static JsonSerializerOptions options = new JsonSerializerOptions() 
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        public static string GetAllMafiaFamiliesAsString() 
        {
            string jsonFamilies = "";
            List<MafiaFamily> families = context.MafiaFamilies.ToList();
            foreach (var family in families)
            {
                jsonFamilies += JsonSerializer.Serialize(family, options) + "\n";
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