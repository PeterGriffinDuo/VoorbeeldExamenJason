using ExamenOnlineGokken.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenOnlineGokken.Controllers
{
    public class BetController : Controller
    {
        private const string CART_SESSION_KEY = "BettingCart";

        private readonly GambleDbContext _gambleDbContext;

        public BetController(GambleDbContext gambleDbContext)
        {
            _gambleDbContext = gambleDbContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(long gameId)
        {
            var gameIds = GetCartGameIds();

            if (!gameIds.Contains(gameId))
            {
                gameIds.Add(gameId);
                SaveCartGameIds(gameIds);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(long gameId)
        {
            var gameIds = GetCartGameIds();
            gameIds.Remove(gameId);
            SaveCartGameIds(gameIds);

            return RedirectToAction("ShowBets");
        }

        public async Task<IActionResult> ShowBets()
        {
            var gameIds = GetCartGameIds();

            var games = await _gambleDbContext.Games
                .Where(g => gameIds.Contains(g.Id))
                .OrderBy(g => g.DateOfGame)
                .ToListAsync();

            return View(games);
        }

        private List<long> GetCartGameIds()
        {
            string serializedCart = HttpContext.Session.GetString(CART_SESSION_KEY);

            if (serializedCart == null)
            {
                return new List<long>();
            }

            return JsonConvert.DeserializeObject<List<long>>(serializedCart);
        }

        private void SaveCartGameIds(List<long> gameIds)
        {
            string serializedCart = JsonConvert.SerializeObject(gameIds);
            HttpContext.Session.SetString(CART_SESSION_KEY, serializedCart);
        }
    }
}
