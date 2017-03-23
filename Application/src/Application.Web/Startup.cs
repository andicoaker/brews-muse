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
            var vendor5 = new Vendor();
            var vendor6 = new Vendor();
            var vendor7 = new Vendor();
            var vendor8 = new Vendor();
            var vendor9 = new Vendor();
            var vendor10 = new Vendor();

            var beer = new Beer();
            var beer2 = new Beer();
            var beer3 = new Beer();

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
                vendor.Lat = -79.9265;
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
                vendor2.Lat = -79.9389;
                vendor2.Lng = 32.7894;
                vendor2.ImageURL = "http://www.thecocktailclubcharleston.com/wordpress2/wp-content/uploads/2014/11/cc-logo.jpg";
                context.Vendors.Add(vendor2);

                vendor3.Name = "The Gin Joint";
                vendor3.Address = "182 E Bay St";
                vendor3.City = "Charleston";
                vendor3.State = "SC";
                vendor3.ZipCode = 29401;
                vendor3.OwnerName = "Joe Raya";
                vendor.Owner = user;
                vendor3.Hours = "3:00 PM - 2:00 AM";
                vendor3.VendorURL = "https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=webhp&cd=&cad=rja&uact=8&ved=0ahUKEwjR9cbc_-zSAhXHRyYKHYJJCqgQhAcIJA&url=http%3A%2F%2Ftheginjoint.com%2Fcategory%2Fmenu-2%2F&usg=AFQjCNHT-y-_13inQz4GsLDege2r9kfM4A";
                vendor3.VendorPhone = "843-577-6111";
                vendor3.Rating = 4;
                vendor3.Lat = -79.9287;
                vendor3.Lng = 32.7768;
                vendor3.ImageURL = "http://ichef.bbci.co.uk/news/624/cpsprodpb/D677/production/_85730945_monkey3.jpg";
                context.Vendors.Add(vendor3);

                vendor4.Name = "A C's Bar and Grill";
                vendor4.Address = "467 King St";
                vendor4.City = "Charleston";
                vendor4.State = "SC";
                vendor4.ZipCode = 29403;
                vendor4.OwnerName = "Jim Curley";
                vendor4.Owner = user;
                vendor4.Hours = "3:00 PM - 2:00 AM";
                vendor4.VendorURL = "http://www.acsbar.com/";
                vendor4.VendorPhone = "843-577-6742";
                vendor4.Rating = 4;
                vendor4.Lat = 79.9388;
                vendor4.Lng = 32.7890;
                vendor4.ImageURL = "http://www.acsbar.com/images/logo%20copy.jpg";
                context.Vendors.Add(vendor4);

                vendor5.Name = "Tattood Moose";
                vendor5.Address = "3328 Maybank Highway";
                vendor5.City = "Charleston";
                vendor5.State = "SC";
                vendor5.ZipCode = 29455;
                vendor5.OwnerName = "Mike Kulick";
                vendor5.Owner = user;
                vendor5.Hours = "11:30 AM - 2:00 AM";
                vendor5.VendorURL = "http://tattooedmoose.com/home-copy-2-copy-2.html";
                vendor5.VendorPhone = "843-277-2990";
                vendor5.Rating = 5;
                vendor5.Lat = -79.9493;
                vendor5.Lng = 32.8114;
                vendor5.ImageURL = "http://tattooedmoose.com/images/moose_logo_400px.png?crc=4036922751";
                context.Vendors.Add(vendor5);

                vendor6.Name = "The Belmont";
                vendor6.Address = "511 King St.";
                vendor6.City = "Charleston";
                vendor6.State = "SC";
                vendor6.ZipCode = 29403;
                vendor6.OwnerName = "Mickey Moran";
                vendor6.Owner = user;
                vendor6.Hours = "5:30 PM - 2:00 AM";
                vendor6.VendorURL = "http://www.thebelmontcharleston.com/";
                vendor6.VendorPhone = "843-628-5515";
                vendor6.Rating = 5;
                vendor6.Lat = -79.9395;
                vendor6.Lng = 32.7903;
                vendor6.ImageURL = "http://www.thebelmontcharleston.com/logos/belmont-logo-v5.png";
                context.Vendors.Add(vendor6);

                vendor7.Name = "The Royal American";
                vendor7.Address = "970 Morrison Dr";
                vendor7.City = "Charleston";
                vendor7.State = "SC";
                vendor7.ZipCode = 29403;
                vendor7.OwnerName = "John";
                vendor7.Owner = user;
                vendor7.Hours = "4:00 PM - 2:00 AM";
                vendor7.VendorURL = "http://theroyalamerican.com/menu/";
                vendor7.VendorPhone = "843-817-6925";
                vendor7.Rating = 5;
                vendor7.Lat = -79.9420;
                vendor7.Lng = 32.8067;
                vendor7.ImageURL = "https://media2.fdncms.com/charleston/imager/the-royal-american/u/zoom/4007753/royalam.jpg";
                context.Vendors.Add(vendor7);

                vendor8.Name = "The Rarebit";
                vendor8.Address = "474 King St";
                vendor8.City = "Charleston";
                vendor8.State = "SC";
                vendor8.ZipCode = 29403;
                vendor8.OwnerName = "John Adamson";
                vendor8.Owner = user;
                vendor8.Hours = "11:00 AM - 2:00 AM";
                vendor8.VendorURL = "http://therarebit.com/";
                vendor8.VendorPhone = "843-974-5483";
                vendor8.Rating = 4;
                vendor8.Lat = -79.9388;
                vendor8.Lng = 32.7900;
                vendor8.ImageURL = "http://therarebit.com/custom/logo_cover.png";
                context.Vendors.Add(vendor8);

                vendor9.Name = "The Alley";
                vendor9.Address = "131 Columbus St";
                vendor9.City = "Charleston";
                vendor9.State = "SC";
                vendor9.ZipCode = 29403;
                vendor9.OwnerName = "David Crowley";
                vendor9.Owner = user;
                vendor9.Hours = "11:00 AM - 2:00 AM";
                vendor9.VendorURL = "http://thealleycharleston.com/about";
                vendor9.VendorPhone = "843-818-4080";
                vendor9.Rating = 4;
                vendor9.Lat = -79.9407;
                vendor9.Lng = 32.7938;
                vendor9.ImageURL = "http://www.charlestoncvb.com/images/calendar/29191618911352901.jpg";
                context.Vendors.Add(vendor9);

                vendor10.Name = "Salty Mike's";
                vendor10.Address = "17 Lockwood Dr";
                vendor10.City = "Charleston";
                vendor10.State = "SC";
                vendor10.ZipCode = 29401;
                vendor10.OwnerName = "Charleston Harbor";
                vendor10.Owner = user;
                vendor10.Hours = "3:00 PM - 10:00 PM";
                vendor10.VendorURL = "https://www.facebook.com/saltymikes/";
                vendor10.VendorPhone = "843-937-0208";
                vendor10.Rating = 4;
                vendor10.Lat = -79.9503;
                vendor10.Lng = 32.7787;
                vendor10.ImageURL = "http://www.charlestoncvb.com/images/calendar/29191618911352901.jpg";
                context.Vendors.Add(vendor10);

                beer.Name = "Kolsch";
                beer.OwnerId = user.Id;
                beer.Price = 1;
                beer.Rating = 5;
                beer.Brewery = "COAST Brewing Company";
                beer.Type = "IPA";
                context.Beers.Add(beer);

                beer2.Name = "PB&J";
                beer2.OwnerId = user.Id;
                beer2.Price = 1;
                beer2.Rating = 5;
                beer2.Brewery = "Edmund's Oast";
                beer2.Type = "IPA";
                context.Beers.Add(beer2);

                beer3.Name = "Ashley Farmhouse Ale";
                beer3.OwnerId = user.Id;
                beer3.Price = 1;
                beer3.Rating = 5;
                beer3.Brewery = "Freehouse Brewery";
                beer3.Type = "Saison";
                context.Beers.Add(beer3);

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
