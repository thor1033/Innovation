using FindPlayers.Models;
using FindPlayers.StaticServices;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindPlayers.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
        private User _credentials;
        private INavigationService _navigationService;


        private bool isExecuting;
        public bool IsExecuting {
            get { return isExecuting; }
            set { SetProperty(ref isExecuting, value); }
        }

        private NotifyTaskCompletion<LoLAccount> riotAccount;
        public NotifyTaskCompletion<LoLAccount> RiotAccount {
            get { return riotAccount; }
            set { SetProperty(ref riotAccount, value); }
        }

        public DelegateCommand RestCommand { get; set; }

        public MainPageViewModel (INavigationService navigationService) : base(navigationService) {
            _navigationService = navigationService;
            RestCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => IsExecuting);
        }
        public override async void OnNavigatedTo(INavigationParameters parameters) {
            _credentials = parameters.GetValue<User>("User");
            if (_credentials == null)
            {
                await _navigationService.GoBackAsync();
            }
            if (CanExecute())
            {
                Execute();
            }

        }

        public bool CanExecute() {
            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //    return false;
            //}
            if (!IsExecuting)
            {
                return true;
            }
            return false;
        }
        public void Execute() {
            if (CrossConnectivity.Current.IsConnected)
            {
                IsExecuting = true;
                RiotAccount = new NotifyTaskCompletion<LoLAccount>(MoedetiderSS.GetLolAccountAsync(_credentials));
                IsExecuting = false;
                
                
            }
            else
            {
                IsExecuting = true;
                App.Current.MainPage.DisplayAlert("Ingen forbindelse", "kan ikke opdatere tider", "OK");
                IsExecuting = false;
            }
        }
    }
}
