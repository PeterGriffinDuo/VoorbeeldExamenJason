using ExamenOnlineGokken.Data;
using ExamenOnlineGokken.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenOnlineGokken.Controllers
{
    public class GameController : Controller
    {
        private readonly GambleDbContext _gambleDbContext;

        public GameController(GambleDbContext gambleDbContext)
        {
            _gambleDbContext = gambleDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateGameViewModel createGameViewModel = new CreateGameViewModel();
            createGameViewModel.Leagues = await GetLeagueSelectListAsync();
            return View(createGameViewModel);
        }

        private async Task<List<SelectListItem>> GetLeagueSelectListAsync(long? selectedLeagueId = null)
        {
            var leagues = await _gambleDbContext.Leagues
                .OrderBy(l => l.Name)
                .ToListAsync();

            return leagues
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name,
                    Selected = selectedLeagueId.HasValue && l.Id == selectedLeagueId
                })
                .ToList();
        }
    }
}
