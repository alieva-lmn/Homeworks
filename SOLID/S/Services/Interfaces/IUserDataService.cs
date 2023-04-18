using S.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.Services.Interfaces
{
    public interface IUserDataService
    {
        public void AddUser(User user)
        {
            // Добавляет пользователя в бд
        }

        public void DeleteUser(User user)
        {
            // Удаляет пользователя из бд
        }

        public User GetUserByUsername(string username)
        {
            // Возвращает нужного пользователя из бд
            return new User();
        }
    }
}
