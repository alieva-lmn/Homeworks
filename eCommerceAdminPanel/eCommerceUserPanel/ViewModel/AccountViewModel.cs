using eCommerceUserPanel.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LibClass.Messages;
using LibClass.Model;
using LibClass.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceUserPanel.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        public List<Cart> AllItems { get; set; } = new();
        public AccountViewModel(IMessenger messenger, INavigationService navigationService)
        {
            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<DataMessage>(this, message =>
            {
                AllItems = message.Data as List<Cart>;
            });
        }
    }
}
