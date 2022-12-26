using Microsoft.AspNetCore.Mvc;

namespace ButlyaAdmin.Controllers;

public class DataController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}