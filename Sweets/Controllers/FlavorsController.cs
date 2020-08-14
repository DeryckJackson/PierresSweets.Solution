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
  public class FlavorsController : Controller
  {
    private readonly SweetsContext _db;
    private readonly UserManager<User> _userManager;

    public FlavorsController(UserManager<User> userManager, SweetsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      var model = _db.Flavors
        .Include(treat => treat.Treats)
        .ThenInclude(join => join.Treat)
        .ToList();
      return View(model);
    }

    [Authorize] 
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flav)
    {
      _db.Flavors.Add(flav);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
        .Include(treat => treat.Treats)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(Flavor => Flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [Authorize] 
    public ActionResult Edit (int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flav)
    {
      _db.Entry(flav).State = EntityState.Modified; 
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize] 
    public ActionResult Delete(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    { 
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize] 
    public ActionResult AddTreat(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Treat treat, int flavorId)
    {
      if (flavorId != 0 && treat.TreatId != 0)
      {
        _db.FlavorTreat.Add(new FlavorTreat() {FlavorId = flavorId, TreatId = treat.TreatId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = flavorId });
    }

    [Authorize] 
    [HttpPost]
    public ActionResult DeleteTreat(int id, int joinId)
    {
      var joinEntry = _db.FlavorTreat.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreat.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = id });
    }
  }
}