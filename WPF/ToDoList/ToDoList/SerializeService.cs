using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;

namespace ToDoList
{
    public class SerializeService
    {
        public static JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };
        public static string Serialize<Task>(List<Task> obj)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }
        public static List<Task> DeserializeList(string json)
        {
            return JsonConvert.DeserializeObject<List<Task>>(json, settings);
        }
    }
}
