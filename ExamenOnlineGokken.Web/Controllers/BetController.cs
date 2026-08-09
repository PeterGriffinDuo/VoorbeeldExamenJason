using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenOnlineGokken.Controllers
{
    public class BetController : Controller
    {
        private const string BET_COUNT_KEY = "BetCount";

        [HttpPost]
        public IActionResult Add(long gameId)
        {
            int betCount = HttpContext.Session.GetInt32(BET_COUNT_KEY) ?? 0;
            HttpContext.Session.SetInt32(BET_COUNT_KEY, betCount + 1);

            return RedirectToAction("Index", "Home");
        }
    }
}
