using ExamenOnlineGokken.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenOnlineGokken.ViewModels
{
    public class HomeIndexVM
    {
        public string Title { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public long? SelectedLeagueId { get; set; }
    }
}
