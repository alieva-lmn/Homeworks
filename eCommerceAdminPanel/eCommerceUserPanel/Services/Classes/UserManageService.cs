using eCommerceUserPanel.Model;
using eCommerceUserPanel.Services.Interfaces;
using LibClass.Services.Interfaces;
using LibClass.Services.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using LibClass.Model;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace eCommerceUserPanel.Services.Classes
{
    public class UserManageService : IUserManageService
    {
        public static ObservableCollection<User> Users { get; set; } = new();
        private readonly string? path = FilePath.userPath;
        public ObservableCollection<User> DownloadUsersData()
        {
            var json = FileService.ReadFromFile(path, FileMode.OpenOrCreate);

            if (String.IsNullOrEmpty(json))
            {
                return Users;
            }
            else
            {
                return Users = SerializeService.DeserializeList<ObservableCollection<User>>(json);
            }
        }

        private User? DownloadUser(string username, string password)
        {
            var result = DownloadUsersData();
            var json = FileService.ReadFromFile(path, FileMode.OpenOrCreate);

            if (result.Count > 0)
            {
                Users = SerializeService.DeserializeList<ObservableCollection<User>>(json);

                foreach (var item in Users)
                {
                    if (item.Username == username && item.Password == password)
                    {
                        var res = item;
                        return res;
                    }
                }
            }
            return null;
        }
        public void SendData(ObservableCollection<User> users)
        {
            var res = SerializeService.Serialize(users);
            FileService.WriteToFile(res, path, FileMode.Truncate);
        }
        public void Add(User user)
        {
            Users = DownloadUsersData();
            Users.Add(user);

            SendData(Users);
        }

        public bool CheckExists(string username, string password)
        {
            var user = DownloadUser(username, password);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        public User GetUser(string username, string password)
        {
            var user = DownloadUser(username, password);

            if (user != null)
            {
                return user;
            }
            throw new NullReferenceException();
        }
    }
}

