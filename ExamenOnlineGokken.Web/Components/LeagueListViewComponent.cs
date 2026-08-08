using ExamenOnlineGokken.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenOnlineGokken.Components
{
    public class LeagueListViewComponent : ViewComponent
    {
        private readonly GambleDbContext _gambleDbContext;

        public LeagueListViewComponent(GambleDbContext gambleDbContext)
        {
            _gambleDbContext = gambleDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var leagues = await _gambleDbContext.Leagues
                .OrderBy(l => l.Name)
                .ToListAsync();

            return View(leagues);
        }
    }
}
