using System;
using System.Collections.Generic;
using System.Text;

namespace FindPlayers.Models
{
    public class Tournament
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Buyin { get; set; }
        public string Price { get; set; }
        public string Format { get; set; }
    }
}
