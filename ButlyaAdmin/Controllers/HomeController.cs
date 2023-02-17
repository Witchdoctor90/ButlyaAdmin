using Microsoft.AspNetCore.Mvc;

namespace ButlyaAdmin.Controllers;

public class HomeController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View(this.User);
    }
}