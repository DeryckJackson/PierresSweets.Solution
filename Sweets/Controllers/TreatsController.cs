using Microsoft.AspNetCore.Mvc;
using Sweets.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Sweets.Controllers
{
  [Authorize] 
  public class TreatsController : Controller
  {
    private readonly SweetsContext _db;
    private readonly UserManager<User> _userManager;

    public TreatsController(UserManager<User> userManager, SweetsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      var model = _db.Treats
        .Include(flav => flav.Flavors)
        .ThenInclude(join => join.Flavor)
        .ToList();
      return View(model);
    }


  }
}