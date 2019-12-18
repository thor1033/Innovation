using Prism.Navigation;
using Prism.Commands;
using Xamarin.Forms;

namespace FindPlayers.Views
{
    public partial class MenuPage : MasterDetailPage, IMasterDetailPageOptions {
        public MenuPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation {
            get { return Device.Idiom != TargetIdiom.Phone; }
        }
    }
}