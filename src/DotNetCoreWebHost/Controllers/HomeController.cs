using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using DotNetCoreWebHost.Models;

namespace DotNetCoreWebHost.Controllers
{
    public class HomeController : Controller
    {
        #region Private Members

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<HomeController> _logger;

        #endregion

        #region Ctor's

        public HomeController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IAuthorizationService authorizationService,
            ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
            _logger = logger;
        }

        #endregion

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            #region Obsolete
            //var userClaims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, "Name"),
            //        new Claim(ClaimTypes.Email, "email@domain.com"),
            //        new Claim("SubscriptionId", Guid.NewGuid().ToString())
            //    };

            //var userIdentity = new ClaimsIdentity(userClaims, "CookieAuth");
            //var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
            //HttpContext.SignInAsync(userPrincipal);
            #endregion

            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                
                // TODO: Get User Claims?

                return result.Succeeded ? RedirectToAction(nameof(Index)) : RedirectToAction("LoginFailure");
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(/*Policy = "DateOfBirth"*/)]
        public IActionResult Private()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string username, string password)
        {
            try
            {
                var identityUser = new IdentityUser(username);
                var result = await _userManager.CreateAsync(identityUser, password);
                
                // TODO: Set User Claims?

                return result.Succeeded ? RedirectToAction(nameof(Login)) : RedirectToAction("RegisterFailure");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                return BadRequest("An error occurred while creating the account. Please try again.");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
