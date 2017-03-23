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
            var vendor4 = new Vendor();
            var beer = new Beer();
            var band = new Band();

            if (user == null)
            {
                //var userStore = new UserStore<ApplicationUser>(context);

                user = new ApplicationUser();


                user.Email = "vendor@vendor.com";
                await userManager.CreateAsync(user, "password");


                vendor.Name = "The Rooftop Bar at Vendue";
                vendor.OwnerName = "Jonathan Weitz";
                vendor.Address = "19 Vendue Range";
                vendor.City = "Charleston";
                vendor.State = "SC";
                vendor.ZipCode = 29401;
                vendor.Hours = "11:30 AM - 12:00 AM";
                vendor.VendorURL = "http://places.singleplatform.com/the-rooftop-at-the-vendue/menu?ref=google";
                vendor.VendorPhone = "843-577-7970";
                vendor.Rating = 4;
                vendor.ImageURL = "https://media-cdn.tripadvisor.com/media/photo-s/01/c6/4d/ca/rooftop-with-a-view.jpg";
                vendor.Lat = 79.9265;
                vendor.Lng = 32.7786;
                vendor.Owner = user;
                context.Vendors.Add(vendor);


                vendor2.Name = "The Cocktail Club";
                vendor2.Address = "479 King St #200";
                vendor2.City = "Charleston";
                vendor2.State = "SC";
                vendor2.ZipCode = 29403;
                vendor2.OwnerName = "The Indigo Road";
                vendor2.Owner = user;
                vendor2.Hours = "5:00 PM - 2:00 AM";
                vendor2.VendorURL = "http://www.thecocktailclubcharleston.com/";
                vendor2.VendorPhone = "843-724-9411";
                vendor2.Rating = 4;
                vendor2.Lat = 79.9389;
                vendor2.Lng = 32.7894;
                vendor2.ImageURL = "http://www.thecocktailclubcharleston.com/wordpress2/wp-content/uploads/2014/11/cc-logo.jpg";
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

                vendor4.Name = "Vendors and Sons";
                vendor4.Address = "1600 Pennsylvendor Avenue";
                vendor4.City = "Charleston";
                vendor4.State = "SC";
                vendor4.ZipCode = 29401;
                vendor4.OwnerName = "Val Vendor Sr.";
                vendor4.Owner = user;
                vendor4.Hours = "10:00 AM";
                vendor4.VendorURL = "www.vendorsandsons.com";
                vendor4.Rating = 4;
                vendor4.Lat = 79.9287;
                vendor4.Lng = 32.7768;
                vendor4.ImageURL = "http://ichef.bbci.co.uk/news/624/cpsprodpb/D677/production/_85730945_monkey3.jpg";
                context.Vendors.Add(vendor4);

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
