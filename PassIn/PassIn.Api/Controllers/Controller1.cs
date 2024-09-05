using Microsoft.AspNetCore.Mvc;

namespace PassIn.Api.Controllers;

public class Controller1 : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}