﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FindPlayers.Models
{
    public class TFTRank
    {
        public string QueueType { get; set; }
        public string SummonerName { get; set; }
        public bool HotStreak { get; set; }
        public int Wins { get; set; }
        public bool Veteran { get; set; }
        public int Losses { get; set; }
        public string Rank { get; set; }
        public string Tier { get; set; }
        public bool Inactive { get; set; }
        public bool FreshBlood { get; set; }
        public string LeagueId { get; set; }
        public string SummonerId { get; set; }
        public int LeaguePoints{ get; set; }

    }
}
