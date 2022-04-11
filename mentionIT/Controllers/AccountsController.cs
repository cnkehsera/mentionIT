using mentionIT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace mentionIT.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountsController(UserManager<IdentityUser> userManager,
                                    SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Meals");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("Login", "Accounts");
         //           System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
         //new System.Net.Mail.MailAddress("sender@mydomain.com", "Web Registration"),
         //new System.Net.Mail.MailAddress(user.Email));
         //           m.Subject = "Email confirmation";
         //           m.Body = string.Format("Dear {0} <BR/>Thank you for your registration, please click on the below link to complete your registration: < a href =\"{1}\"title =\"User Email Confirm\">{1}</a>",
         //    user.UserName, Url.Action("ConfirmEmail", "Account",
         //    new { Token = user.Id, Email = user.Email }, Request.Scheme)); m.IsBodyHtml = true;
         //           System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.mydomain.com");
         //           smtp.Credentials = new System.Net.NetworkCredential("sender@mydomain.com", "password");
         //           /*smtp.ServerCertificateValidationCallback = () => true;*/ //Solution for client certificate error
         //           smtp.EnableSsl = true;
         //           smtp.Send(m);
         //           return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string Token, string Email)
        {
            IdentityUser user = await userManager.FindByIdAsync(Token);
            if (user != null)
            {
                if (user.Email == Email)
                {
                    user.EmailConfirmed= true;
                    await userManager.UpdateAsync(user);
                    return RedirectToAction("Index", "Home", new { ConfirmedEmail = user.Email });
                }
                else
                {
                    return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                }
            }
            else
            {
                return RedirectToAction("Confirm", "Account", new { Email = "" });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var options = new CookieOptions { Expires = DateTime.Now.AddDays(100) };
                    Response.Cookies.Append("ckiLikes", model.Email, options);
                    return RedirectToAction("Index", "Meals");
                }
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
    }
}
