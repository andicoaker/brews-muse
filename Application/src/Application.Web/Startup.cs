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


            context.Database.EnsureDeleted();
            context.Database.Migrate();
            var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync("vendor@vendor.com");



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
            var vendor11 = new Vendor();

            var beer = new Beer();
            var beer2 = new Beer();
            var beer3 = new Beer();
            var beer4 = new Beer();
            var beer5 = new Beer();
            var beer6 = new Beer();
            var beer7 = new Beer();
            var beer8 = new Beer();
            var beer9 = new Beer();
            var beer10 = new Beer();

            var band = new Band();
            var band2 = new Band();
            var band3 = new Band();
            var band4 = new Band();
            var band5 = new Band();
            var band6 = new Band();
            var band7 = new Band();
            var band8 = new Band();
            var band9 = new Band();
            var band10 = new Band();

            if (user == null)
            {
                //var userStore = new UserStore<ApplicationUser>(context);

                user = new ApplicationUser();


                user.Email = "vendor@vendor.com";
                await userManager.CreateAsync(user, "password");
                context.Add(user);

                vendor.Name = "Bay Street Biergarten";
                vendor.OwnerName = "Jonathan Weitz";
                vendor.Address = "549 E Bay St.";
                vendor.City = "Charleston";
                vendor.State = "SC";
                vendor.ZipCode = 29403;
                vendor.Hours = "11:00 AM - 2:00 AM";
                vendor.VendorURL = "http://baystreetbiergarten.com/";
                vendor.VendorPhone = "843-266-2437";
                vendor.Rating = 4;
                vendor.ImageURL = "https://pbs.twimg.com/profile_images/578927224771870720/u-sRbrst.jpeg";
                vendor.Lng = -79.9314;
                vendor.Lat = 32.7920;
                vendor.Owner = user;
                beer.Vendor = vendor;
                context.Vendors.Add(vendor);
                context.Vendors.Add(beer.Vendor);


                vendor2.Name = "Closed for Business";
                vendor2.Address = "453 King St.";
                vendor2.City = "Charleston";
                vendor2.State = "SC";
                vendor2.ZipCode = 29403;
                vendor2.OwnerName = "The Indigo Road";
                vendor2.Owner = user;
                vendor2.Hours = "11:00 AM - 2:00 AM";
                vendor2.VendorURL = "http://closed4business.com/";
                vendor2.VendorPhone = "843-853-8466";
                vendor2.Rating = 4;
                vendor2.Lng = -79.9384;
                vendor2.Lat = 32.7886;
                vendor2.ImageURL = "https://media1.fdncms.com/charleston/imager/u/blog/6018630/cfb_logo.jpg?cb=1478128577";
                context.Vendors.Add(vendor2);

                vendor3.Name = "Charleston Beer Works";
                vendor3.Address = "480 King Street St.";
                vendor3.City = "Charleston";
                vendor3.State = "SC";
                vendor3.ZipCode = 29401;
                vendor3.OwnerName = "Joe Raya";
                vendor.Owner = user;
                vendor3.Hours = "11:30 PM - 2:00 AM";
                vendor3.VendorURL = "http://charlestonbeerworks.com/";
                vendor3.VendorPhone = "843-577-6111";
                vendor3.Rating = 4;
                vendor3.Lng = -79.9287;
                vendor3.Lat = 32.7768;
                vendor3.ImageURL = "http://ichef.bbci.co.uk/news/624/cpsprodpb/D677/production/_85730945_monkey3.jpg";
                context.Vendors.Add(vendor3);

                vendor4.Name = "Lagunitas";
                vendor4.Address = "161 E Bay St.";
                vendor4.City = "Charleston";
                vendor4.State = "SC";
                vendor4.ZipCode = 29401;
                vendor5.OwnerName = "Tony Magee";
                vendor4.Owner = user;
                vendor4.Hours = "1200 PM - 9:00 PM";
                vendor4.VendorURL = "https://lagunitas.com/taprooms/charleston";
                vendor4.VendorPhone = "843-853-4677";
                vendor4.Rating = 5;
                vendor4.Lng = -79.9274;
                vendor4.Lat = 32.7785;
                vendor4.ImageURL = "http://www.stevennoble.com/main.php?g2_view=core.DownloadItem&g2_itemId=19404&g2_serialNumber=2";
                context.Vendors.Add(vendor4);


                //vendor4.Name = "A C's Bar and Grill";
                //vendor4.Address = "467 King St.";
                //vendor4.City = "Charleston";
                //vendor4.State = "SC";
                //vendor4.ZipCode = 29403;
                //vendor4.OwnerName = "Jim Curley";
                //vendor4.Owner = user;
                //vendor4.Hours = "3:00 PM - 2:00 AM";
                //vendor4.VendorURL = "http://www.acsbar.com/";
                //vendor4.VendorPhone = "843-577-6742";
                //vendor4.Rating = 4;
                //vendor4.Lng = -79.9388;
                //vendor4.Lat = 32.7890;
                //vendor4.ImageURL = "http://www.acsbar.com/images/logo%20copy.jpg";
                //context.Vendors.Add(vendor4);

                vendor5.Name = "The Tattood Moose";
                vendor5.Address = "3328 Maybank Hwy.";
                vendor5.City = "Charleston";
                vendor5.State = "SC";
                vendor5.ZipCode = 29455;
                vendor5.OwnerName = "Mike Kulick";
                vendor5.Owner = user;
                vendor5.Hours = "11:30 AM - 2:00 AM";
                vendor5.VendorURL = "http://tattooedmoose.com/";
                vendor5.VendorPhone = "843-277-2990";
                vendor5.Rating = 5;
                vendor5.Lng = -79.9493;
                vendor5.Lat = 32.8114;
                vendor5.ImageURL = "http://tattooedmoose.com/images/moose_logo_400px.png?crc=4036922751";
                context.Vendors.Add(vendor5);

                vendor6.Name = "Tommy Condons";
                vendor6.Address = "160 Church St.";
                vendor6.City = "Charleston";
                vendor6.State = "SC";
                vendor6.ZipCode = 29401;
                vendor6.OwnerName = "Alison Vandal Baker and Allan Vandal";
                vendor6.Owner = user;
                vendor6.Hours = "11:00 AM - 2:00 AM";
                vendor6.VendorURL = "tommycondons.com";
                vendor6.VendorPhone = "843-577-3818";
                vendor6.Rating = 5;
                vendor6.Lng = -79.9295;
                vendor6.Lat = 32.7801;
                vendor6.ImageURL = "http://www.explorecharleston.net/photos/TommyCondon.jpg";
                context.Vendors.Add(vendor6);

                //vendor6.Name = "The Belmont";
                //vendor6.Address = "511 King St.";
                //vendor6.City = "Charleston";
                //vendor6.State = "SC";
                //vendor6.ZipCode = 29403;
                //vendor6.OwnerName = "Mickey Moran";
                //vendor6.Owner = user;
                //vendor6.Hours = "5:30 PM - 2:00 AM";
                //vendor6.VendorURL = "http://www.thebelmontcharleston.com/";
                //vendor6.VendorPhone = "843-628-5515";
                //vendor6.Rating = 5;
                //vendor6.Lng = -79.9395;
                //vendor6.Lat = 32.7903;
                //vendor6.ImageURL = "http://www.thebelmontcharleston.com/logos/belmont-logo-v5.png";
                //context.Vendors.Add(vendor6);

                vendor7.Name = "The Royal American";
                vendor7.Address = "970 Morrison Dr.";
                vendor7.City = "Charleston";
                vendor7.State = "SC";
                vendor7.ZipCode = 29403;
                vendor7.OwnerName = "John Jacob Jingleheimer Schmidt";
                vendor7.Owner = user;
                vendor7.Hours = "4:00 PM - 2:00 AM";
                vendor7.VendorURL = "http://theroyalamerican.com/";
                vendor7.VendorPhone = "843-817-6925";
                vendor7.Rating = 5;
                vendor7.Lng = -79.9420;
                vendor7.Lat = 32.8067;
                vendor7.ImageURL = "https://media2.fdncms.com/charleston/imager/the-royal-american/u/zoom/4007753/royalam.jpg";
                context.Vendors.Add(vendor7);


                vendor8.Name = "The Griffon";
                vendor8.Address = "18 Vendue Range";
                vendor8.City = "Charleston";
                vendor8.State = "SC";
                vendor8.ZipCode = 29401;
                vendor8.OwnerName = "";
                vendor8.Owner = user;
                vendor8.Hours = "12:00 Pm - 2:00 AM";
                vendor8.VendorURL = "www.griffoncharleston.com";
                vendor8.VendorPhone = "843-723-1700";
                vendor8.Rating = 3;
                vendor8.Lng = -79.9262;
                vendor8.Lat = 32.7790;
                vendor8.ImageURL = "https://cdn0.vox-cdn.com/uploads/chorus_image/image/42527886/upload.0.jpg";
                context.Vendors.Add(vendor8);

                //    //vendor8.Name = "Midtown Bar & Grill";
                //    //vendor8.Address = "559 King St";
                //    //vendor8.City = "Charleston";
                //    //vendor8.State = "SC";
                //    //vendor8.ZipCode = 29401;
                //    //vendor8.OwnerName = "Michael Shuler, Chris Houston, Thomas Shepard";
                //    //vendor8.Owner = user;
                //    //vendor8.Hours = "4:00 PM - 2:00 AM";
                //    //vendor8.VendorURL = "http://www.midtownbarcharleston.com/";
                //    //vendor8.VendorPhone = "843-737-4284";
                //    //vendor8.Rating = 4;
                //    //vendor8.Lng = -79.9388;
                //    //vendor8.Lat = 32.7900;
                //    //vendor8.ImageURL = "http://midtownbarcharleston.info/wp-content/uploads/2016/09/white-logo.png";
                //    //context.Vendors.Add(vendor8);

                vendor9.Name = "The Alley";
                vendor9.Address = "131 Columbus St.";
                vendor9.City = "Charleston";
                vendor9.State = "SC";
                vendor9.ZipCode = 29403;
                vendor9.OwnerName = "David Crowley";
                vendor9.Owner = user;
                vendor9.Hours = "11:00 AM - 2:00 AM";
                vendor9.VendorURL = "http://thealleycharleston.com/";
                vendor9.VendorPhone = "843-818-4080";
                vendor9.Rating = 4;
                vendor9.Lng = -79.9407;
                vendor9.Lat = 32.7938;
                vendor9.ImageURL = "http://www.charlestoncvb.com/images/calendar/29191618911352901.jpg";
                context.Vendors.Add(vendor9);

                vendor10.Name = "Blind Tiger Pub";
                vendor10.Address = "36 Broad St.";
                vendor10.City = "Charleston";
                vendor10.State = "SC";
                vendor10.ZipCode = 29401;
                vendor10.OwnerName = "Lisa Brown";
                vendor10.Owner = user;
                vendor10.Hours = "11:00 AM - 2:00 AM";
                vendor10.VendorURL = "http://blindtigerchs.com/";
                vendor10.VendorPhone = "843-872-6700";
                vendor10.Rating = 4;
                vendor10.Lng = -79.9287;
                vendor10.Lat = 32.7768;
                vendor10.ImageURL = "http://blindtigerchs.com/wp-content/uploads/2016/08/logo-mobile.png";
                context.Vendors.Add(vendor10);

                vendor11.Name = "Salty Mike's";
                vendor11.Address = "17 Lockwood Dr.";
                vendor11.City = "Charleston";
                vendor11.State = "SC";
                vendor11.ZipCode = 29401;
                vendor11.OwnerName = "Mike Salini";
                vendor11.Owner = user;
                vendor11.Hours = "3:00 PM - 10:00 PM";
                vendor11.VendorURL = "https://www.varietystorerestaurant.com/";
                vendor11.VendorPhone = "843-937-0208";
                vendor11.Rating = 5;
                vendor11.Lng = -79.9503;
                vendor11.Lat = 32.7787;
                vendor11.ImageURL = "https://static.wixstatic.com/media/ff43d5_2f7309ede9144011bb97d3ac93f04248.png/v1/fill/w_449,h_630,al_c,usm_0.66_1.00_0.01/ff43d5_2f7309ede9144011bb97d3ac93f04248.png";
                context.Vendors.Add(vendor11);



                beer.Name = "Kolsch";
                beer.Owner = vendor.Owner;
                beer.Price = 1;
                beer.Rating = 5;
                beer.Brewery = "COAST Brewing Company";
                beer.Type = "Pilsner";
                beer.AlcoholContent = 4.8m;
                ////if you're wondering about the m, it's needed as a suffix for the decimal. Why? I don't know. Blame Bill Gates.

                vendor.Beers.Add(beer);

                beer2.Name = "PB&J";
                beer2.Owner = vendor.Owner;
                beer2.Price = 1;
                beer2.Rating = 5;
                beer2.Brewery = "Edmund's Oast";
                beer2.Type = "Stout";
                beer.AlcoholContent = 5.0m;
                vendor.Beers.Add(beer2);

                beer3.Name = "Hoptart";
                beer3.Owner = vendor.Owner;
                beer3.Price = 1;
                beer3.Rating = 5;
                beer3.Brewery = "Freehouse Brewery";
                beer3.Type = "Saison";
                beer.AlcoholContent = 8.0m;
                vendor.Beers.Add(beer3);

                beer4.Name = "Blackbeerd";
                beer4.Owner = vendor.Owner;
                beer4.Price = 1;
                beer4.Rating = 5;
                beer4.Brewery = "COAST Brewing Company";
                beer4.Type = "Stout";
                beer.AlcoholContent = 9.3m;
                vendor.Beers.Add(beer4);

                beer5.Name = "Viridi Rex";
                beer5.Owner = vendor.Owner;
                beer5.Price = 1;
                beer5.Rating = 5;
                beer5.Brewery = "Edmund's Oast";
                beer5.Type = "IPA";
                beer.AlcoholContent = 9.5m;
                vendor.Beers.Add(beer5);

                beer6.Name = "Charleston Lager";
                beer6.Owner = vendor.Owner;
                beer6.Price = 1;
                beer6.Rating = 5;
                beer6.Brewery = "Palmetto Brewing Company";
                beer6.Type = "Amber Ale";
                beer.AlcoholContent = 5.4m;
                vendor.Beers.Add(beer6);

                beer7.Name = "Palmetto Pale Ale";
                beer7.Owner = vendor.Owner;
                beer7.Price = 1;
                beer7.Rating = 5;
                beer7.Brewery = "Palmetto Brewing Company";
                beer7.Type = "American Pale Ale";
                beer.AlcoholContent = 5.2m;
                vendor.Beers.Add(beer7);

                beer8.Name = "White Thai";
                beer8.Owner = vendor.Owner;
                beer8.Price = 1;
                beer8.Rating = 5;
                beer8.Brewery = "Westbrook Brewing Company";
                beer8.Type = "Wheat beer";
                beer.AlcoholContent = 5.0m;
                vendor.Beers.Add(beer8);

                beer9.Name = "Boy King Double IPA";
                beer9.Owner = vendor.Owner;
                beer9.Price = 1;
                beer9.Rating = 5;
                beer9.Brewery = "Coast Brewing Company";
                beer9.Type = "IPA";
                beer.AlcoholContent = 9.7m;
                vendor.Beers.Add(beer9);

                beer10.Name = "Dead Arm";
                beer10.Owner = vendor.Owner;
                beer10.Price = 1;
                beer10.Rating = 5;
                beer10.Brewery = "COAST Brewing Company";
                beer10.Type = "American Pale Ale";
                beer.AlcoholContent = 6.0m;
                vendor.Beers.Add(beer10);

                band.Name = "MoJo McGee";
                band.Owner = user;
                band.Genre = "Various";
                band.Rating = 5;
                band.CoverCharge = 30;
                band.Showtime = "4/10/2017 8:00 PM - 12:00 AM";
                vendor.Bands.Add(band);

                band2.Name = "The Officials Band";
                band2.Owner = user;
                band2.Genre = "Jazz";
                band2.Rating = 5;
                band2.CoverCharge = 10;
                band2.Showtime = "4/5/2017 10:00 PM - 12:00 AM";
                vendor.Bands.Add(band2);

                band3.Name = "Ocean Drive Party Band O.D.P.B.";
                band3.Owner = user;
                band3.Genre = "Variety";
                band3.Rating = 5;
                band3.CoverCharge = 10;
                band3.Showtime = "4/7/2017 10:00 PM - 2:00 AM";
                vendor.Bands.Add(band3);

                band4.Name = "Palmetto Soul";
                band4.Owner = user;
                band4.Genre = "Rock";
                band4.Rating = 5;
                band4.CoverCharge = 10;
                band4.Showtime = "4/4/2017 10:00 PM - 12:00 AM";
                vendor.Bands.Add(band);

                band5.Name = "Melonbelly Acoustic Guitarists Charleston SC";
                band5.Owner = user;
                band5.Genre = "Variety";
                band5.Rating = 5;
                band5.CoverCharge = 10;
                band5.Showtime = "4/11/2017 9:00 PM - 12:00 AM";
                vendor.Bands.Add(band5);

                band6.Name = "Andrew Thielen 'Motown' Band";
                band6.Owner = user;
                band6.Genre = "Oldies, disco, beach music";
                band6.Rating = 5;
                band6.CoverCharge = 10;
                band6.Showtime = "4/6/2017 10:00 PM - 12:00 AM";
                vendor.Bands.Add(band6);

                band7.Name = "The SugarBees";
                band7.Owner = user;
                band7.Genre = "Variety";
                band7.Rating = 5;
                band7.CoverCharge = 10;
                band7.Showtime = "4/3/2017 10:00 PM - 12:00 AM";
                vendor.Bands.Add(band7);

                band8.Name = "Emerald Empire Band";
                band8.Owner = user;
                band8.Genre = "Variety";
                band8.Rating = 5;
                band8.CoverCharge = 10;
                band8.Showtime = "4/5/2017 10:30 PM - 12:00 AM";
                vendor.Bands.Add(band8);

                band9.Name = "Chewbacky Band";
                band9.Owner = user;
                band9.Genre = "Country";
                band9.Rating = 5;
                band9.CoverCharge = 10;
                band9.Showtime = "4/5/2017 8:00 PM - 12:00 AM";
                vendor.Bands.Add(band9);

                band10.Name = "The Vistas";
                band10.Owner = user;
                band10.Genre = "Rock";
                band10.Rating = 5;
                band10.CoverCharge = 20;
                band10.Showtime = "4/6/2017 10:00 PM - 12:00 AM";
                vendor.Bands.Add(band10);
            }


            ////string[] roles = new string[] { "Vendor", "Consumer", "Anonymous" };

            ////foreach (string role in roles)
            ////{
            ////    var roleStore = new RoleStore<IdentityRole>(context);

            ////    if (!context.Roles.Any(r => r.Name == role))
            ////    {
            ////        await roleStore.CreateAsync(new IdentityRole(role));
            ////    }
            ////}



            context.SaveChanges();
            }
        }
    }

