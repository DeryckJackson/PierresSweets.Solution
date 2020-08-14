using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Sweets.Models;

namespace Sweets.Controllers
{
  public class HomeController : Controller
  {
    private readonly SweetsContext _db;

    public HomeController(SweetsContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.Treats = _db.Treats.ToList();
      ViewBag.Flavors = _db.Flavors.ToList();
      return View();
    }
  }
}