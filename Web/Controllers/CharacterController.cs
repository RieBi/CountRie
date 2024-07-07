using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
public class CharacterController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
