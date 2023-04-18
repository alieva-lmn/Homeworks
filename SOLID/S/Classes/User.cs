using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.Classes
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /*
         SRP (Single Responsibility Principle)
     
         Чтобы класс "User" не был загроможден и хранил в себе только информацию о пользователе,
         а не отвечал одновременно за авторизацию и манипуляцию данными,
         программа была разделена на интерфейсы "IAuthService" и "IUserDataService".
         
         В таком случае, если мы изменим процесс авторизации и/или работу с данными пользователя,
         они никак не повлияют друг на друга, тем самым код не сломается и будет более гибким.

     */

}
