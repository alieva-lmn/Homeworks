using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using MVP_project.Model;

namespace MVP_project.Services
{
    internal class SerializeService
    {
        public static JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };
        public static string Serialize<Person>(List<Person> obj)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }
        public static List<Person> DeserializeList(string json)
        {
            return JsonConvert.DeserializeObject<List<Person>>(json, settings);
        }
    }
}
