using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic.ApplicationServices;
using PaintProject.Messages;
using PaintProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintProject.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        //private PaintProject.Model.User user = new();
        //private IUserManageService _userManageService;

        //public MainViewModel(IUserManageService userManageService)
        //{
        //    _userManageService = userManageService;
        //}
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Set(ref _currentViewModel, value);
            }
        }

        private readonly IMessenger _messenger;
        public void ReceiveMessage(NavigationMessage message)
        {
            CurrentViewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
        }
        public MainViewModel(IMessenger messenger)
        {
            if ()
            {
                
            }
            CurrentViewModel = App.Container.GetInstance<LoginViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, ReceiveMessage);
        }
    }
}
