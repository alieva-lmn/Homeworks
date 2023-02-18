using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;

namespace Introduction
{
    public class SerializeService
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
