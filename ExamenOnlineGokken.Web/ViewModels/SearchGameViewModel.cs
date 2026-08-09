using ExamenOnlineGokken.Domain.Entities;
using ExamenOnlineGokken.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenOnlineGokken.ViewModels
{
    public class SearchGameViewModel
    {
        [Display(Name = "Home team")]
        [MaxLength(35)]
        [RequireEither(nameof(AwayTeam), ErrorMessage = "Vul minstens Home team of Away team in.")]
        public string HomeTeam { get; set; }

        [Display(Name = "Away team")]
        [MaxLength(35)]
        [RequireEither(nameof(HomeTeam), ErrorMessage = "Vul minstens Home team of Away team in.")]
        public string AwayTeam { get; set; }

        [Display(Name = "League")]
        public long? SelectedLeagueId { get; set; }
        public List<SelectListItem> Leagues { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
