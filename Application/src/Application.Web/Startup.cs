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
                vendor.Address = "1234 Vendor Lane";
                vendor.City = "Charleston";
                vendor.State = "SC";
                vendor.ZipCode = 29401;
                vendor.Hours = "4:00 PM - 2:00 AM";
                vendor.VendorURL = "www.vendor.com";
                vendor.VendorPhone = "555-555-5555";
                vendor.Rating = 5;
                vendor.ImageURL = "http://i.imgur.com/uSExX74.jpg";
                vendor.Lat = 79.9342;
                vendor.Lng = 32.7799;
                vendor.Owner = user;
                context.Vendors.Add(vendor);


                vendor2.Name = "Vendors R Us";
                vendor2.Address = "1533 Vendor Street";
                vendor2.City = "Charleston";
                vendor2.State = "SC";
                vendor2.ZipCode = 29464;
                vendor2.OwnerName = "Victor von Vendorstein";
                vendor2.Owner = user;
                vendor2.Hours = "3:00 PM - 1:00 AM";
                vendor2.VendorURL = "www.vendorsrus";
                vendor2.VendorPhone = "555-867-5309";
                vendor2.Rating = 4;
                vendor2.Lat = 79.9274;
                vendor2.Lng = 32.7785;
                vendor2.ImageURL = "http://m5.paperblog.com/i/76/765810/calendar-pin-up-dogs-that-look-smashingly-cut-L-ga5X3B.jpeg";
                context.Vendors.Add(vendor2);

                vendor3.Name = "Vendors and Sons";
                vendor3.Address = "1600 Pennsylvendor Avenue";
                vendor3.City = "Charleston";
                vendor3.State = "SC";
                vendor3.ZipCode = 29401;
                vendor3.OwnerName = "Val Vendor Sr.";
                vendor.Owner = user;
                vendor3.Hours = "10:00 AM";
                vendor3.VendorURL = "www.vendorsandsons.com";
                vendor3.Rating = 4;
                vendor3.Lat = 79.9287;
                vendor3.Lng = 32.7768;
                vendor3.ImageURL = "http://ichef.bbci.co.uk/news/624/cpsprodpb/D677/production/_85730945_monkey3.jpg";
                context.Vendors.Add(vendor3);

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
