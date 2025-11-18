using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CineClub.ViewModels;

namespace CineClub.Controllers;
public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager){
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login(string? ReturnUrl){
        // ReturnUrl keeps the url of the action we are coming from, after login action, we want to return where we came from
        //ViewData["ReturnUrl"] = ReturnUrl; 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string? ReturnUrl){
        // if we try to access some page and we dont have authorization
        // dotnet middleware keeps the url of the action we are coming from in ReturnUrl
        // after we login, we can return to the page we came from using ReturnUrl
        
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    return Redirect(ReturnUrl);

                return RedirectToAction("Index", "Home");
            }
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(model);
    }

    public async Task<IActionResult> Logout(){
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}