using Microsoft.AspNetCore.Mvc;

namespace ExamenOnlineGokken.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
