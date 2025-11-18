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
    public IActionResult Login(string ReturnUrl){
        // ReturnUrl keeps the url of the action we are coming from, after login action, we want to return where we came from
        //ViewData["ReturnUrl"] = ReturnUrl; 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string? ReturnUrl = null){
        // ReturnUrl keeps the url of the action we are coming from, after login action, we want to return where we came from
        
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return View(model);
        }
        
        if (ModelState.IsValid){
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null){
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded){
                    // if the ReturnUrl is empty, the user will be returned to the home/index
                    return Redirect(ReturnUrl ?? "/"); 
                }
                else{
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            else{
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

        return View(model); 
    }

    public async Task<IActionResult> Logout(){
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }

}