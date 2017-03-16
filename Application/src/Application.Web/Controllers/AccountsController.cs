﻿using BrewsMuse.Models;
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
        [Route("~/api/username")]
        public IActionResult Name()
        {
            return Ok(User.Identity.Name);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/accounts/{signature}")]
        public IActionResult GetInfo(string signature)
        {
            Guid userSignature = Guid.Empty;
            if (!Guid.TryParse(signature, out userSignature))
            {
                var state = new ModelStateDictionary();
                state.AddModelError("signature", "Invalid user signature format. ");
                return BadRequest(state);
            }
            else
            {
                var state = new ModelStateDictionary();
                return Ok(state);
            }

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

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return Ok();
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
            //newUser.Email = model.Email;
            //newUser.UserName = model.Email;

            var identity = await _userManager.CreateAsync(newUser, model.Password);

            var result = await _signInManager.PasswordSignInAsync(newUser, model.Password, true, false);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("~/api/accounts/logoff")]
        public async Task<IActionResult> Logoff()
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

