﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewsMuse.Models;
using Microsoft.AspNetCore.Identity;


namespace Application.Web.Controllers
{
    public class CheckInController : Controller
    {
        private readonly ApplicationContext _context;
        private UserManager<ApplicationUser> _userManager { get; set; }
        public CheckInController(UserManager<ApplicationUser> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpPost]
        [Route("~/api/vendors/checkin")]
        public async Task<IActionResult> PostCheckIn(int vendorId, [FromBody]Vendor CheckIn)
        {
            var vendor = _context.Vendors.FirstOrDefault(q => q.Id == vendorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //CheckIn.OwnerId = _userManager.GetUserId(User);


            if (vendor.CheckIn >= 1)
            {
                return null;
            }
            else
            {
                int checkIn = vendor.CheckIn++;
                await _context.SaveChangesAsync();
                return View(checkIn);
            }

            return CreatedAtAction("PostCheckIn", new { id = CheckIn.Id }, CheckIn);
        }
    }
}
