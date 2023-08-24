using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PaintProject.Model;
using PaintProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using PaintProject.Services.Classes;

namespace PaintProject.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public User User { get; set; } = new();

        private readonly INavigationService _navigationService;
        private readonly IUserManageService _userManageService;

        public RegisterViewModel(INavigationService navigationService, IUserManageService userManageService)
        {
            _navigationService = navigationService;
            _userManageService = userManageService;
        }
        public RelayCommand LoginCommand
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<LoginViewModel>();
                });
        }

        public RelayCommand<object> RegisterCommand
        {
            get => new(
            async param =>
            {
                if (param != null)
                {
                    object[] res = (object[])param;

                    var password = (PasswordBox)res[0];
                    var confirm = (PasswordBox)res[1];

                    var checker = new PasswordService(password, confirm);
                    bool myres = await _userManageService.CheckUserExistsAsync(User.Username);

                    if (checker.IsMatch(User.Email) && !myres)
                    {
                        User.Password = password.Password;
                        User.Confirmation = confirm.Password;

                        await _userManageService.AddUserAsync(User);

                        var result = "You are successfully signed up";

                        MessageBox.Show(result, "FYI", MessageBoxButton.OK, MessageBoxImage.Information);

                        LoginViewModel.Username = User.Username;
                        _navigationService.NavigateTo<LoginViewModel>();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong...", "FYI", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });
        }
    }
}
