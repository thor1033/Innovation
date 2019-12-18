using FindPlayers.Models;
using FindPlayers.StaticServices;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace FindPlayers.ViewModels
{
    public class LoginPageViewModel : ViewModelBase {
        private User user;
        public User User {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private string errmsg;
        public string Errmsg {
            get { return errmsg; }
            set { SetProperty(ref errmsg, value); }
        }

        private NotifyTaskCompletion<bool> isExecuting;
        public NotifyTaskCompletion<bool> IsExecuting {
            get { return isExecuting; }
            set { SetProperty(ref isExecuting, value); }
        }

        INavigationService _navigationService;

        private DelegateCommand loginCommand;
        public DelegateCommand LoginCommand => loginCommand ?? (loginCommand = new DelegateCommand(Execute));

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService) {
            _navigationService = navigationService;

            if (Application.Current.Properties.ContainsKey("username"))
            {
                User = new User
                {
                    Username = Application.Current.Properties["username"] as string
                };
            }
            else
            {
                User = new User();
            }
        }

        public void Execute() {
            IsExecuting = new NotifyTaskCompletion<bool>(LoginSS.GetLoginInfo(User, _navigationService, this));
        }
    }
}
