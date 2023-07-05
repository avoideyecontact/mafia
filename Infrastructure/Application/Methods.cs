using Domain.Entities;
using Domain.Persistance;
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
        
        /// <summary>
        /// Create static JsonSeriliazerOptions to economy memory
        /// </summary>
        private static JsonSerializerOptions options = new() 
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
                jsonOrganizations += JsonSerializer.Serialize(organization, options) + "\n";
            }
            return jsonOrganizations;
        }

        public static string GetMafiaFamilyByIdAsString(int id)
        {
            MafiaFamily family = context.MafiaFamilies.Where(p => (p.Id == id)).Single();
            return JsonSerializer.Serialize(family, options);
        }

        public static string GetOrganizationByIdAsString(int id)
        {
            Organization organization = context.Organizations.Where(p => (p.Id == id)).Single();
            return JsonSerializer.Serialize(organization, options);
        }
    }
}