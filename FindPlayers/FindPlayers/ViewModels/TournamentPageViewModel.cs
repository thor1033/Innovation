using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using FindPlayers.Models;
using Prism.Navigation;

namespace FindPlayers.ViewModels
{
	public class TournamentPageViewModel : ViewModelBase
	{
        private List<Tournament> allTournaments;
        public List<Tournament> AllTournaments {
            get { return allTournaments; }
            set { SetProperty(ref allTournaments, value); }
        }

        public TournamentPageViewModel(INavigationService navigationService) : base(navigationService) {
            


        }
        public override async void OnNavigatedTo(INavigationParameters parameters) {

            AllTournaments = new List<Tournament>();
            AllTournaments.Add(new Tournament {
                Id = "0001",
                Name = "SmallTourny",
                Buyin = "2$",
                Format = "Single Round Robin",
                Price = "20$"
            });
            AllTournaments.Add(new Tournament
            {
                Id = "0002",
                Name = "BigTourny",
                Buyin = "15$",
                Format = "Single Elimination",
                Price = "300$"
            });
            AllTournaments.Add(new Tournament
            {
                Id = "0003",
                Name = "MediumTourny",
                Buyin = "15$",
                Format = "Double Round Robin",
                Price = "150$"
            });
            AllTournaments.Add(new Tournament
            {
                Id = "0004",
                Name = "GrandTourny",
                Buyin = "100$",
                Format = "Single Elimination",
                Price = "10000$"
            });

        }
    }
}
