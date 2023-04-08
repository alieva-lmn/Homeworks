using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using MVVM.Interfaces;
using MVVM.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Classes
{
    public class NavigationService : Interfaces.INavigationService
    {
        private readonly IMessenger _messenger;
        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = typeof(T)
            });
        }
    }
}
