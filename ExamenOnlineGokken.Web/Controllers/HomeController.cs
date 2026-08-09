using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExamenOnlineGokken.Models;
using ExamenOnlineGokken.Data;
using ExamenOnlineGokken.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExamenOnlineGokken.Controllers
{
    public class HomeController : Controller
    {
        protected GambleDbContext _gambleDbContext;
        public HomeController(GambleDbContext gambleDbContext)
        {
            _gambleDbContext = gambleDbContext;
        }
        public async Task<IActionResult> Index()
        {
            HomeIndexVM homeIndexVM = new HomeIndexVM();
            homeIndexVM.Title = "Upcoming games";
            homeIndexVM.Games = await _gambleDbContext.Games
                .Include(g => g.Bets)
                .ThenInclude(b => b.User).OrderBy(g => g.DateOfGame)
                .ToListAsync();
            return View(homeIndexVM);
        }

        public async Task<IActionResult> FindByLeague(long? id)
        {
            HomeIndexVM homeIndexVM = new HomeIndexVM();
            homeIndexVM.Title = "Games by league";
            homeIndexVM.SelectedLeagueId = id;

            if (id.HasValue)
            {
                homeIndexVM.Games = await _gambleDbContext.Games
                    .Where(g => g.LeagueId == id)
                    .Include(g => g.Bets)
                    .ThenInclude(b => b.User)
                    .OrderBy(g => g.DateOfGame)
                    .ToListAsync();
            }

            return View(homeIndexVM);
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            SearchGameViewModel searchGameViewModel = new SearchGameViewModel();
            searchGameViewModel.Leagues = await GetLeagueSelectListAsync();
            return View(searchGameViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(SearchGameViewModel searchGameViewModel)
        {
            searchGameViewModel.Leagues = await GetLeagueSelectListAsync(searchGameViewModel.SelectedLeagueId);
            return View(searchGameViewModel);
        }

        private async Task<List<SelectListItem>> GetLeagueSelectListAsync(long? selectedLeagueId = null)
        {
            var leagues = await _gambleDbContext.Leagues
                .OrderBy(l => l.Name)
                .ToListAsync();

            var items = leagues
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name,
                    Selected = selectedLeagueId.HasValue && l.Id == selectedLeagueId
                })
                .ToList();

            items.Insert(0, new SelectListItem { Value = "", Text = "-- Alle leagues --" });
            return items;
        }

       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
