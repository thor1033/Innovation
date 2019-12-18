using FindPlayers.Models;
using FindPlayers.ViewModels;
using Plugin.Connectivity;
using Prism.Navigation;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FindPlayers.StaticServices
{
    public static class LoginSS {
        //TODO: Skift return til Errmsg string, så ikke behov for vm?
        public static async Task<bool> GetLoginInfo(User User, INavigationService _navigationService, LoginPageViewModel vm) {
            if (!CrossConnectivity.Current.IsConnected)
            {
                vm.Errmsg = "Fejl: Ingen internetforbindelse";
                return false;
            }

            if (string.IsNullOrEmpty(User.Username))
            {
                vm.Errmsg = "Fejl: Intet brugernavn angivet";
                return false;
            }

            User.FullInfo = User.Username + " " + User.Password;

            Application.Current.Properties["username"] = User.Username;
            await Application.Current.SavePropertiesAsync();

            var p = new NavigationParameters
                {
                    { "CurrentDate", DateTime.Now.ToString("dd-MM-yyyy") },
                    { "User", User },

                };

            var result = await _navigationService.NavigateAsync("/MenuPage/NavigationPage/MainPage", p);
            return true;
        }
    }
}
