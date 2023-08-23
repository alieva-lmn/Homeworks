using PaintProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintProject.Services.Interfaces
{
    public interface IUserManageService
    {
        public Task<User> GetUserAsync(string username, string password);
        public Task<bool> CheckUserExistsAsync(string username);
        public Task<bool> AddUserAsync(User user);
    }
}
