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

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var confirmationLink = Url.Action(
                    "ConfirmEmail",           
                    "Account",                
                    new { userId = user.Id, token = token }, 
                    protocol: Request.Scheme  // http/https
                );

                // for now, we show the confirmation link on RegisterSuccess page
                // in real projects, we often send confirmation link via e-mail 
                TempData["ConfirmationLink"] = confirmationLink;


                await _userManager.AddToRoleAsync(user, "User");

                return RedirectToAction("RegisterSuccess", "Account");
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            
            //AssignUserRole("ad5db69c-c7ad-451e-b512-eef68fe8415e");
            
        }
        return View(model);
    }

    public async Task<IActionResult> AssignUserRole(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return NotFound();

        await _userManager.AddToRoleAsync(user, "User");

        return RedirectToAction("Index"); 
    }

    [HttpGet]
    public IActionResult RegisterSuccess()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        if (userId == null || token == null)
            return View("ConfirmEmailSuccess", "Invalid confirmation link.");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return View("ConfirmEmailSuccess", "User not found.");

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
            return View("ConfirmEmailSuccess", "Your email has been successfully confirmed.");

        return View("ConfirmEmailSuccess", "Email confirmation failed.");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

}