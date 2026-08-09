using ExamenOnlineGokken.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Display(Name = "League")]
        public long? SelectedLeagueId { get; set; }
        public List<SelectListItem> Leagues { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
