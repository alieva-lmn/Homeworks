using Newtonsoft.Json;
using PaintProject.DBContext;
using PaintProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class DbManageService
    {
        public static DrawingDbContext Context { get; set; } = new();
        public static bool CheckUserExists(string username)
        {
            var user = Context.Users.Contains(Context.Users.FirstOrDefault(x => x.Username == username));

            if (user)
            {
                return true;
            }
            return false;
        }

        public static string GetUser(string username, string password)
        {
            try
            {
                User user = Context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                
                if (user != null)
                {
                    string userData = JsonConvert.SerializeObject(user);
                    return userData;
                }
                else
                {
                    return "User not found";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving user: " + ex.Message);
                return null;
            }
        }

        public static bool AddUser(string userData)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(userData);

                Context.Users.Add(user);
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding user: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateUser(string data)
        {
            try
            {
                User updatedUser = JsonConvert.DeserializeObject<User>(data);
                User existingUser = Context.Users.FirstOrDefault(u => u.Username == updatedUser.Username);

                if (existingUser != null)
                {
                    //existingUser.PicCollection.Add(data);

                    Context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user: " + ex.Message);
                return false;
            }
        }
    }
}
