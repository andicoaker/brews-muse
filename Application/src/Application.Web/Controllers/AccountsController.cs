using BrewsMuse.Models;
using ChatRoom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewsMuse.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = "Identity.Application")]
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/authenticated")]
        public IActionResult Authentication()
        {
            return Ok(User.Identity.IsAuthenticated);
        }

        

        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/accounts/")]
        public IActionResult GetInfo()
        {
            return Ok(new { IsAuthenticated = User.Identity.IsAuthenticated, Name = User.Identity.Name });

        }


        [HttpPost]
        [AllowAnonymous]
        [Route("~/api/accounts/login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest("Email not found.");
            }

            var newUser = new User();
            newUser.Email = model.Email;
            newUser.UserName = model.Email;

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return Ok(newUser);
            }

            return BadRequest("Invalid login attempt.");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("~/api/accounts/register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                return BadRequest("Email already in use.");
            }

            var newUser = new ApplicationUser();
            newUser.Email = model.Email;
            newUser.UserName = model.Email;

            var identity = await _userManager.CreateAsync(newUser, model.Password);

            var result = await _signInManager.PasswordSignInAsync(newUser, model.Password, true, false);

            var resultConfirm = await _signInManager.PasswordSignInAsync(newUser, model.PasswordConfirm, true, false);

            if (result.Succeeded)
            {

                //return Ok(result);
                if (resultConfirm.Succeeded && resultConfirm == result)
                {
                    return Ok(newUser);
                }
                else
                {
                    return BadRequest(resultConfirm);
                }
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("~/api/accounts/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

        [HttpPut]
        [Route("~/api/accounts/password")]
        public async Task<IActionResult> ChangePassword([FromBody]PasswordChangeRequest model)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            if (user == null)
            {
                return BadRequest("User not found... are you logged in?");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return Ok("Password change successful!");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}


