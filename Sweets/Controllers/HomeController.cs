using Microsoft.AspNetCore.Mvc;

namespace Sweets.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}