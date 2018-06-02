using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models;
using SporthalHuren.Models.ViewModels;

namespace SporthalHuren.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        public Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public AccountController(UserManager<ApplicationUser> userMgr,
            SignInManager<ApplicationUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(loginModel.Email);
                bool admin = await userManager.IsInRoleAsync(user, "Administrator");
                bool proprietor = await userManager.IsInRoleAsync(user, "Proprietor");
                bool normalUser = await userManager.IsInRoleAsync(user, "NormalUser");
                bool proprietorAdmin = await userManager.IsInRoleAsync(user, "ProprietorAdmin");

                if (user != null && admin)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }

                if (user != null && proprietor)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Proprietor/Index");
                    }
                }

                if (user != null && normalUser)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/NormalUser/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Onjuist e-mail adres of wachtwoord");
            return View(loginModel);
        }

        [AllowAnonymous]
        public ViewResult Register(string returnUrl)
        {
            return View(new RegisterModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string SelectedRole, RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = registerModel.Email, Email = registerModel.Email, PhoneNumber = registerModel.PhoneNumber };
                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded && SelectedRole == "NormalUser")
                {
                    await userManager.AddToRoleAsync(user, "NormalUser");

                    if ((await signInManager.PasswordSignInAsync(user,
                    registerModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(registerModel?.ReturnUrl ?? "/NormalUser/Index");
                    }
                }
                if (result.Succeeded && SelectedRole == "Proprietor")
                {
                    await userManager.AddToRoleAsync(user, "Proprietor");

                    if ((await signInManager.PasswordSignInAsync(user,
                    registerModel.Password, false, false)).Succeeded)
                    {
                        return Redirect("/Proprietor/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Het is niet gelukt om een account aan te maken...");
            return View(registerModel);
        }


        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
  
    }
}

