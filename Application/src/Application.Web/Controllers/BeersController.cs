using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewsMuse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;




// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Web.Controllers
{
    public class BeersController : Controller
    {
        private readonly ApplicationContext _context;
        private UserManager<ApplicationUser> _userManager { get; set; }
        private IHostingEnvironment _environment { get; set; }
        public BeersController(IHostingEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationContext context)
        {
            _environment = environment;
            _userManager = userManager;
            _context = context;
        }
        // GET: /<controller>/
        [AllowAnonymous]
        [Route("~/api/vendors/{vendorsId}/beers")]
        public IActionResult Beer(int beerId)
        {


            var userName = _userManager.GetUserName(User);
            var vendors = _context.Vendors.Include(q => q.Beers).Where(m => m.UserName == userName).FirstOrDefault(m => m.Id == beerId);
            //return View();
            return Ok(vendors);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/vendors/{vendorsId}/beers/")]
        public IEnumerable<Beer> GetBeers(int vendorsId)
        {
            //var userId = _userManager.GetUserId(User);

            var userName = _userManager.GetUserName(User);
            var vendor = _context.Vendors.Where(q => q.UserName == userName).SingleOrDefault(m => m.Id == vendorsId);
            return vendor.Beers.ToList(); //_context.Beers.Where(q => q.Vendor.Id == vendorsId).ToList();
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/vendors/{vendorsId}/beers/{id}")]
        public IActionResult GetBeer(int vendorsId, int id)
        {
            //var userId = _userManager.GetUserId(User);

            var userName = _userManager.GetUserName(User);
            var vendor = _context.Vendors.Include(q => q.Beers).Where(m => m.UserName == userName).FirstOrDefault(q => q.Id == vendorsId);
            var beer = vendor.Beers.FirstOrDefault(q => q.Id == id);//vendorsId); 
            if (beer == null)
            {
                return NotFound();
            }
            return Ok(beer);
        }

        [HttpPost]
        [Authorize]
        [Route("~/api/vendors/{vendorsId}/beers/")]
        public async Task<IActionResult> PostBeer(int vendorsId, [FromBody]Beer beer) //int id //[FromBody]Beer beer)
        {
            var vendor = _context.Vendors.FirstOrDefault(q => q.Id == vendorsId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //beer.OwnerId = _userManager.GetUserId(User);

            var user = await _userManager.GetUserAsync(User);
            //beer = await _context.Beers.Where(q => q.Owner == user).SingleOrDefaultAsync(m => m.Id == id);

            var userName = _userManager.GetUserName(User);

            beer.UserName = vendor.UserName;

            if (user.UserName == vendor.UserName)
            {
                vendor.Beers.Add(beer);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    if (BeerExists(beer.Id))
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

            else
            {
                return BadRequest("You do not have permission to add beers.");

            }
            //vendor.Beers.Add(beer);
           
        }

        [HttpPut]
        [Authorize]
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

            //beer.Owner = await _userManager.GetUserAsync(User);
            _context.Entry(beer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!BeerExists(id))
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
        [Authorize]
        [Route("~/api/vendors/{vendorsId}/beers/{id}")]
        public async Task<IActionResult> DeleteBeer(int id, int vendorsId, [FromBody] Beer beer)
        {

            var vendor = _context.Vendors.FirstOrDefault(q => q.Id == vendorsId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var user = await _userManager.GetUserAsync(User);
            beer = await _context.Beers.SingleOrDefaultAsync(m => m.Id == id);

            //beer.Owner = user;
            if (beer == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            if (user.UserName == vendor.UserName)
            {
                _context.Beers.Remove(beer);
                await _context.SaveChangesAsync();
                //return Ok(beer);
                return Ok("Beer Deleted");
            }
            else
            {
                return BadRequest("You do not have permission to delete beers");
            }
           

            
        }

        private bool BeerExists(int id)
        {
            //var userId = _userManager.GetUserId(User);
            return _context.Beers.Any(e => e.Id == id);//e.OwnerId == userId && e.Id == id);
        }

        [HttpPost]
        [Authorize]
        [Route("~/api/beers/image")]
        public async Task<IActionResult> PostPicture(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var vendor = new Vendor();

            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
            {
                var name = Guid.NewGuid().ToString();
                var path = Path.Combine(_environment.WebRootPath, "images", "vendors", $"{name}.{extension}");

                using (var image = System.IO.File.Create(path))
                {
                    file.CopyTo(image);
                }

                vendor.ImageURL = $"/images/vendors/{name}.{extension}";
                return Ok(vendor.ImageURL);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

