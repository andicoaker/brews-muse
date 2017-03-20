using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewsMuse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;



// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Web.Controllers
{
    public class BeersController : Controller
    {
        private readonly ApplicationContext _context;
        private UserManager<ApplicationUser> _userManager { get; set; }
        public BeersController(UserManager<ApplicationUser> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        // GET: /<controller>/

        [Route("~/api/vendors/{vendorsId}/beers")]
        public IActionResult Beer(int beerId)
        {

            var vendors = _context.Vendors.Include(q => q.Beers).FirstOrDefault(m => m.Id == beerId);
            return View();
        }
        [HttpGet]
        [Route("~/api/vendors/{vendorsId}/beers/{id}")]
        public IEnumerable<Beer> GetBeers(int id)
        {
            var userId = _userManager.GetUserId(User);
            return _context.Beers.Where(q => q.Vendor.OwnerId == userId).ToList();
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetBeer(int beerId) 
        {
            var userId = _userManager.GetUserId(User);

            var vendor = _context.Vendors.Include(q => q.Beers).FirstOrDefault(q => q.Id == beerId);
            var beer = vendor.Beers.FirstOrDefault(q => q.Id == beerId); 
            if (beer == null)
            {
                return NotFound();
            }
            return Ok(beer);
        }

        [HttpPost]
        [Route("~/api/vendors/{vendorsId}/beers/{id}")]
        public async Task<IActionResult> PostBeer(int vendorId, [FromBody]Beer beer)
        {
            var vendor = _context.Vendors.FirstOrDefault(q => q.Id == vendorId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            beer.OwnerId = _userManager.GetUserId(User);
            vendor.Beers.Add(beer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (GroupExists(beer.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetBeer", new { id = beer.Id }, beer);
        }

        [HttpPut]
        [Route("~/api/vendors/{vendorsId}/beers/{id}")]
        public async Task<IActionResult> PutBeer(int id, [FromBody] Beer beer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beer.Id)
            {
                return BadRequest();
            }

            beer.OwnerId = _userManager.GetUserId(User);
            _context.Entry(beer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        
        [HttpDelete]
        [Route("~/api/vendors/{vendorsId}/beers/{id}")]
        public async Task<IActionResult> DeleteBeer(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = _userManager.GetUserId(User);
            Beer beer = await _context.Beers.Where(q => q.OwnerId == userId).SingleOrDefaultAsync(m => m.Id == id);
            if (beer == null)
            {
                return NotFound();
            }
            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();

            return Ok(beer);
        }

        private bool GroupExists(int id)
        {
            var userId = _userManager.GetUserId(User);
            return _context.Beers.Any(e => e.OwnerId == userId && e.Id == id);
        }

        [HttpPost]
        public IActionResult PostImage(Vendor ImageURL)
        {
            var image = _context.Vendors.FirstOrDefault(q => q.Id == ImageURL.Id);

            if (ModelState.IsValid)
            {
                _context.Vendors.Add(ImageURL);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ImageURL);
        }
    }
}

