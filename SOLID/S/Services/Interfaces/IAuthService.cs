using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.Services.Interfaces
{
    public interface IAuthService
    {
        public bool Authenticate(string username, string password)
        {
            // Проверяет есть ли пользователь в системе,
            // если да, то --->
            
            return true;
        }
    }
}
