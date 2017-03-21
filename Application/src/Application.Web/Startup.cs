using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BrewsMuse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Application.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();


        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddMvc();


            services.AddDbContext<ApplicationContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;


            })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIdentity();


            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var context = app.ApplicationServices.GetRequiredService<ApplicationContext>();


            //context.Database.EnsureDeleted();
            context.Database.Migrate();
            var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync("vendor@vendor.com") ;



            var vendor = new Vendor();
            var vendor2 = new Vendor();
            var vendor3 = new Vendor();
            var beer = new Beer();
            var band = new Band();

            if (user == null)
            {
                //var userStore = new UserStore<ApplicationUser>(context);

                user = new ApplicationUser();


                user.Email = "vendor@vendor.com";
                await userManager.CreateAsync(user, "password");


                vendor.Name = "The Lonely Vendor";
                vendor.OwnerName = "John Q. Vendor";
                vendor.Address1 = "1234 Vendor Lane";
                vendor.Address2 = "101";
                vendor.City = "Charleston";
                vendor.State = "SC";
                vendor.ZipCode = 29401;
                vendor.OpeningTIme = "4:00 PM";
                vendor.ClosingTime = "2:00 AM";
                vendor.VendorURL = "www.vendor.com";
                vendor.VendorPhone = "555-555-5555";
                vendor.Rating = 5;
                //vendor.ImageURL = "https://cdn.meme.am/cache/images/folder943/600x600/14646943.jpg";
                vendor.Latitude = 32.123;
                vendor.Longitude = 33.333;
                vendor.OwnerId = user.Id;
                context.Vendors.Add(vendor);


                vendor2.Name = "Vendors R Us";
                vendor2.Address1 = "1533 Vendor Street";
                vendor2.Address1 = "Suite V";
                vendor2.City = "Mt Pleasant";
                vendor2.State = "SC";
                vendor2.ZipCode = 29464;
                vendor2.OwnerName = "Victor V. Vendor";
                vendor2.OwnerId = user.Id;
                vendor2.OpeningTIme = "3:00 PM";
                vendor2.ClosingTime = "1:00 AM";
                vendor2.VendorURL = "www.vendorsrus";
                vendor2.VendorPhone = "555-867-5309";
                vendor2.Rating = 4;
                vendor2.Latitude = 33.123;
                vendor2.Longitude = 35.333;
                context.Vendors.Add(vendor2);




                beer.Name = "Dummy Beer";
                beer.OwnerId = user.Id;
                beer.Price = 1;
                beer.Rating = 5;
                beer.Brewery = "Dummy Brewery";
                beer.Type = "IPA";
                context.Beers.Add(beer);

                band.Name = "The Dummies";
                band.OwnerId = user.Id;
                band.Genre = "Rock";
                band.Rating = 5;
                band.Description = "Dummy description";
                band.CoverCharge = 10;
                band.Showtime = "10:00 PM";
                context.Bands.Add(band);
            }


            //string[] roles = new string[] { "Vendor", "Consumer", "Anonymous" };

            //foreach (string role in roles)
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);

            //    if (!context.Roles.Any(r => r.Name == role))
            //    {
            //        await roleStore.CreateAsync(new IdentityRole(role));
            //    }
            //}



            context.SaveChanges();
        }
    }
}
