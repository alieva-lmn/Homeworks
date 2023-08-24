using PaintProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaintProject.Services.Classes
{
    public class PasswordService
    {
        private readonly string _password;
        private readonly string _confirm;

        public PasswordService(PasswordBox password, PasswordBox confirm)
        {
            _password = password.Password;
            _confirm = confirm.Password;
        }

        public bool IsMatch(string email)
        {
            if (_password == _confirm && IsValidEmail(email))
            {
                return true;
            }
            return false;
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
