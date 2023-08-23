using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using PaintProject.ViewModel;
using PaintProject.Services.Classes;
using PaintProject.Services.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using PaintProject.View;

namespace PaintProject
{
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();
        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            MainStartup();

            base.OnStartup(e);
        }
        private void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<Services.Interfaces.INavigationService, Services.Classes.NavigationService>();
            Container.RegisterSingleton<IShapeDrawService, ShapeDrawService>();
            Container.RegisterSingleton<IPictureSaverService, PictureSaverService>();
            Container.RegisterSingleton<IUserManageService, UserManageService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<DrawingViewModel>();
            Container.RegisterSingleton<GreetingViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<RegisterViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainView();
            mainView.DataContext = Container?.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
