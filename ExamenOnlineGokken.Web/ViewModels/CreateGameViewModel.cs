using ExamenOnlineGokken.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenOnlineGokken.ViewModels
{
    public class CreateGameViewModel
    {
        [Display(Name = "Home team")]
        [Required]
        public string HomeTeam { get; set; }

        [Display(Name = "Away team")]
        [Required]
        public string AwayTeam { get; set; }

        [Display(Name = "Date of game")]
        [DataType(DataType.Date)]
        [NotInThePast]
        public DateTime DateOfGame { get; set; }

        [Display(Name = "League")]
        [Required]
        public long? SelectedLeagueId { get; set; }
        public List<SelectListItem> Leagues { get; set; }
    }
}
