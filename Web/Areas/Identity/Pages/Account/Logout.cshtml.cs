using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<User> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);
                user.LastSession = DateTime.Now;
                var result = await _signInManager.UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    _logger.LogInformation("User logged out.");
                }
            }

            return Redirect("~/");
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            user.LastSession = DateTime.Now;
            var result = await _signInManager.UserManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return RedirectToPage();
                }
            }
            return RedirectToPage();
        }
    }
}
