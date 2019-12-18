using FindPlayers.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindPlayers.ViewModels
{
    public class MenuPageViewModel : ViewModelBase {
        INavigationService _navigationService;

        private List<MDMenuItem> menuItems;
        public List<MDMenuItem> MenuItems {
            get { return menuItems; }
            set { SetProperty(ref menuItems, value); }
        }

        //For at den valgte side bliver ved med at være markeret i menuen.
        private MDMenuItem selectedItem;
        public MDMenuItem SelectedItem {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); selectedItem = null; }
        }

        private User user;
        private string currentDate;
        private PermissionsResult permissions;

        private DelegateCommand<MDMenuItem> navigateCommand;
        public DelegateCommand<MDMenuItem> NavigateCommand => navigateCommand ?? (navigateCommand = new DelegateCommand<MDMenuItem>(Navigate));

        public MenuPageViewModel(INavigationService navigationService) : base(navigationService) {
            _navigationService = navigationService;

            MenuItems = new List<MDMenuItem>
            {
                new MDMenuItem("Log ud", "Logud.png", "LoginPage"),
                new MDMenuItem("Main Page", "KollegerIcon.png", "MainPage"),
                //new MDMenuItem("Kalender", "Kalender.png", "KalenderPage"),
                //new MDMenuItem("Status", "Status.png", "StatusPage"),
                //new MDMenuItem("Kollegaer", "KollegerIcon.png", "ColleaguePage")
            };
        }

        private async void Navigate(MDMenuItem item) {
            if (item.Parameter == "LoginPage")
            {
                await _navigationService.NavigateAsync("/" + item.Parameter);
                return;
            }

            var p = new NavigationParameters
                {
                    { "CurrentDate", currentDate },
                    { "User", user },
                    { "Permissions", permissions }
                };

            var result = await _navigationService.NavigateAsync("NavigationPage/" + item.Parameter, p);
            if (!result.Success)
            {
                Console.WriteLine(result.Exception);
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters) {
            if (parameters.ContainsKey("User") && parameters.ContainsKey("CurrentDate") && parameters.ContainsKey("Permissions"))
            {
                user = parameters.GetValue<User>("User");
                currentDate = parameters.GetValue<string>("CurrentDate");
                permissions = parameters.GetValue<PermissionsResult>("Permissions");
            }
            else
            {
                _navigationService.NavigateAsync("/LoginPage");
            }
        }
    }
}
