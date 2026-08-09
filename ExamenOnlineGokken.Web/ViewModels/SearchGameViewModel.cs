using ExamenOnlineGokken.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenOnlineGokken.ViewModels
{
    public class SearchGameViewModel
    {
        [Display(Name = "Home team")]
        public string HomeTeam { get; set; }

        [Display(Name = "Away team")]
        public string AwayTeam { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
