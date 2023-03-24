using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceAdminPanel.Model;
using Newtonsoft.Json;
using System.Text.Json;

namespace eCommerceAdminPanel.Services
{
    public class SerializeService
    {
        public static JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };
        public static string Serialize<Book>(List<Book> obj)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }
        public static List<Book> DeserializeList(string json)
        {
            return JsonConvert.DeserializeObject<List<Book>>(json, settings);
        }
    }
}
