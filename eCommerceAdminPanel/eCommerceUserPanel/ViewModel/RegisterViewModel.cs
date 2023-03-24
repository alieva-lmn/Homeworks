using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibClass.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using eCommerceUserPanel.Model;
using eCommerceUserPanel.Services.Classes;
using eCommerceUserPanel.Services.Interfaces;

namespace eCommerceUserPanel.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public User User { get; set; } = new();

        private readonly INavigationService _navigationService;
        private readonly IUserManageService _userService;

        public RegisterViewModel(INavigationService navigationService, IUserManageService userService)
        {
            _navigationService = navigationService;
            _userService = userService;
        }

        public RelayCommand BackCommand
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<UserPanelViewModel>();
                });
        }

        public RelayCommand LoginCommand
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AuthViewModel>();
                });
        }

        public RelayCommand<object> RegisterCommand
        {
            get => new(
                param =>
                {
                    if (param != null)
                    {
                        object[] res = (object[])param;

                        var password = (PasswordBox)res[0];
                        var confirm = (PasswordBox)res[1];

                        var checker = new PasswordService(password, confirm);

                        if (checker.IsMatch() && !_userService.CheckExists(User.Username, password.Password))
                        {
                            User.Password = password.Password;
                            User.Confirmation = confirm.Password;

                            _userService.Add(User);
                            MessageBox.Show("YES");
                        }
                        else
                        {
                            MessageBox.Show("No");
                        }
                    }
                });
        }
    }
}
