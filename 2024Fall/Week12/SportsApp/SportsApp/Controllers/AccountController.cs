using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsApp.ViewModels;

public class AccountController : Controller{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager){
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl = "/"){
        // ReturnUrl keeps the url of the action we are coming from, after login action, we want to return where we came from
        ViewData["ReturnUrl"] = returnUrl; 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "/"){
        // ReturnUrl keeps the url of the action we are coming from, after login action, we want to return where we came from
        if (ModelState.IsValid){
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null){
                var result = 
                await _signInManager.PasswordSignInAsync(
                    user, model.Password, model.RememberMe, false);

                if (result.Succeeded){
                    if (Url.IsLocalUrl(returnUrl)){
                        return Redirect(returnUrl);
                    } else { 
                        return RedirectToAction("Index", "Home");
                    }
                }
                else{
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            else{
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

        ViewData["ReturnUrl"] = returnUrl;

        return View(model); 
    }

    public async Task<IActionResult> Logout(){
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid){
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User"); 
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }
}

