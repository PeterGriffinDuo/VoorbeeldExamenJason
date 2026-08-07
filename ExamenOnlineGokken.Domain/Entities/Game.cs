using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenOnlineGokken.Domain.Entities
{
    public class Game
    {
        public long Id { get; set; }
        public string Hometeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime DateOfGame { get; set; }
        public ICollection<Bet> Bets { get; set; }

        public long LeagueId { get; set; }
        public League League { get; set; }
    }
}
