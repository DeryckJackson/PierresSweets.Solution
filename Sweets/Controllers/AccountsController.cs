using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Sweets.Models;
using System.Threading.Tasks;
using Sweets.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Sweets.Controllers
{
  public class AccountsController : Controller
  {
    private readonly SweetsContext _db;
    private readonly UserManager<User> _userManager;

    private readonly SignInManager<User> _signInManager;

    public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager, SweetsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new User { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);    
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}