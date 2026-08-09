using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenOnlineGokken.ViewModels
{
    public class CreateGameViewModel
    {
        [Display(Name = "Home team")]
        public string HomeTeam { get; set; }

        [Display(Name = "Away team")]
        public string AwayTeam { get; set; }

        [Display(Name = "Date of game")]
        [DataType(DataType.Date)]
        public DateTime DateOfGame { get; set; }

        [Display(Name = "League")]
        public long? SelectedLeagueId { get; set; }
        public List<SelectListItem> Leagues { get; set; }
    }
}
