using System;
using System.Collections.Generic;
using System.Text;

namespace FindPlayers.Models
{
    public class LoLAccount
    {
        public int ProfileIconId { get; set; }
        public string Name { get; set; }
        public string Puuid { get; set; }
        public int SummonerLevel { get; set; }
        public string AccountId { get; set; }
        public string Id { get; set; }
        public string RevisionDate { get; set; }

    }
}
