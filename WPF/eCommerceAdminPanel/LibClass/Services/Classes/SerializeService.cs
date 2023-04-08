using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClass.Model;
using Newtonsoft.Json;
using System.Text.Json;

namespace LibClass.Services.Classes
{
    public class SerializeService
    {
        public static JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }
        public static T DeserializeList<T>(string json)  where T : class
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}
