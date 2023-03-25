using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClass.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using eCommerceUserPanel.ViewModel;
using LibClass.Services.Interfaces;
using INavigationService = LibClass.Services.Interfaces.INavigationService;

namespace eCommerceUserPanel.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly INavigationService _navigationService;
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
        public MainViewModel(IMessenger messenger, INavigationService navigationService = null)
        {
            CurrentViewModel = App.Container.GetInstance<UserPanelViewModel>();

            _navigationService = navigationService;
            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, ReceiveMessage);
        }

        public RelayCommand BackCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<UserPanelViewModel>();
            });
        }
    }
}
