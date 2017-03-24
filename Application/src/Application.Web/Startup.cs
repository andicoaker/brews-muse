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
            var band1 = new Band();
            var band2 = new Band();
            var band3 = new Band();
            var band4 = new Band();
            var band5 = new Band();
            var band6 = new Band();
            var band7 = new Band();
            var band8 = new Band();
            var band9 = new Band();

            if (user == null)
            {
                //var userStore = new UserStore<ApplicationUser>(context);

                user = new ApplicationUser();


                user.Email = "vendor@vendor.com";
                await userManager.CreateAsync(user, "password");


                vendor.Name = "Bay Street Biergarten";
                vendor.OwnerName = "Jonathan Weitz";
                vendor.Address = "549 E Bay St";
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
                context.Vendors.Add(vendor);


                vendor2.Name = "Closed for Business";
                vendor2.Address = "453 King St";
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
                vendor3.Address = "480 King Street St";
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
                vendor4.Lng = -79.9388;
                vendor4.Lat = 32.7890;
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
                vendor5.VendorURL = "http://tattooedmoose.com/";
                vendor5.VendorPhone = "843-277-2990";
                vendor5.Rating = 5;
                vendor5.Lng = -79.9493;
                vendor5.Lat = 32.8114;
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
                vendor6.Lng = -79.9395;
                vendor6.Lat = 32.7903;
                vendor6.ImageURL = "http://www.thebelmontcharleston.com/logos/belmont-logo-v5.png";
                context.Vendors.Add(vendor6);

                vendor7.Name = "The Royal American";
                vendor7.Address = "970 Morrison Dr";
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

                vendor8.Name = "Midtown Bar & Grill";
                vendor8.Address = "559 King St";
                vendor8.City = "Charleston";
                vendor8.State = "SC";
                vendor8.ZipCode = 29401;
                vendor8.OwnerName = "Michael Shuler, Chris Houston, Thomas Shepard";
                vendor8.Owner = user;
                vendor8.Hours = "4:00 PM - 2:00 AM";
                vendor8.VendorURL = "http://www.midtownbarcharleston.com/";
                vendor8.VendorPhone = "843-737-4284";
                vendor8.Rating = 4;
                vendor8.Lng = -79.9388;
                vendor8.Lat = 32.7900;
                vendor8.ImageURL = "http://midtownbarcharleston.info/wp-content/uploads/2016/09/white-logo.png";
                context.Vendors.Add(vendor8);

                vendor9.Name = "The Alley";
                vendor9.Address = "131 Columbus St";
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
                vendor10.Address = "36 Broad St";
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

                beer.Name = "Kolsch";
                beer.Owner = user;
                beer.Price = 1;
                beer.Rating = 5;
                beer.Brewery = "COAST Brewing Company";
                beer.Type = "IPA";
                context.Beers.Add(beer);

                beer2.Name = "PB&J";
                beer2.Owner = user;
                beer2.Price = 1;
                beer2.Rating = 5;
                beer2.Brewery = "Edmund's Oast";
                beer2.Type = "Stout";
                context.Beers.Add(beer2);

                beer3.Name = "Hoptart";
                beer3.Owner = user;
                beer3.Price = 1;
                beer3.Rating = 5;
                beer3.Brewery = "Freehouse Brewery";
                beer3.Type = "Saison";
                context.Beers.Add(beer3);

                beer4.Name = "Blackbeerd";
                beer4.Owner = user;
                beer4.Price = 1;
                beer4.Rating = 5;
                beer4.Brewery = "COAST Brewing Company";
                beer4.Type = "Stout";
                context.Beers.Add(beer4);

                beer5.Name = "Viridi Rex";
                beer5.Owner = user;
                beer5.Price = 1;
                beer5.Rating = 5;
                beer5.Brewery = "Edmund's Oast";
                beer5.Type = "IPA";
                context.Beers.Add(beer5);

                beer6.Name = "Charleston Lager";
                beer6.Owner = user;
                beer6.Price = 1;
                beer6.Rating = 5;
                beer6.Brewery = "Palmetto Brewing Company";
                beer6.Type = "Amber Ale";
                context.Beers.Add(beer6);

                beer7.Name = "Palmetto Ale";
                beer7.Owner = user;
                beer7.Price = 1;
                beer7.Rating = 5;
                beer7.Brewery = "Palmetto Brewing Company";
                beer7.Type = "Ale";
                context.Beers.Add(beer7);

                beer8.Name = "White Thai";
                beer8.Owner = user;
                beer8.Price = 1;
                beer8.Rating = 5;
                beer8.Brewery = "Westbrook Brewing Company";
                beer8.Type = "Wheat beer";
                context.Beers.Add(beer8);

                beer9.Name = "Boy King Double IPA";
                beer9.Owner = user;
                beer9.Price = 1;
                beer9.Rating = 5;
                beer9.Brewery = "Coast Brewing Company";
                beer9.Type = "IPA";
                context.Beers.Add(beer9);

                beer10.Name = "Dead Arm";
                beer10.Owner = user;
                beer10.Price = 1;
                beer10.Rating = 5;
                beer10.Brewery = "COAST Brewing Company";
                beer10.Type = "American Pale Ale";
                context.Beers.Add(beer10);

                band.Name = "MoJo McGee";
                band.Owner = user;
                band.Genre = "Various";
                band.Rating = 5;
                band.Description = "4 piece rock-Fusion/Indie band based out of Charleston, SC that consists of guitar , keys, bass drums , saxophone. Can provide a variety of rock,Pop and R&B cover tunes as well as original music.";
                band.CoverCharge = 30;
                band.Showtime = "10:00 PM";
                context.Bands.Add(band);

                band1.Name = "The Vistas";
                band1.Owner = user;
                band1.Genre = "Rock";
                band1.Rating = 5;
                band1.Description = "When you book The Vistas, you can expect a fun, interactive, and exciting party. We can handle everything from the emcee duties, learning your special song, to keeping your guests on the dance floor all night long. ";
                band1.CoverCharge = 20;
                band1.Showtime = "10:00 PM";
                context.Bands.Add(band1);

                band2.Name = "The Officials Band";
                band2.Owner = user;
                band2.Genre = "Jazz";
                band2.Rating = 5;
                band2.Description = "The Officials Band is Charleston's most versatile private party band. Begin your special occasion with a lively jazz cocktail hour. Enjoy a variety of acoustic instruments from stand up bass and saxophone, to mandolin and guitar. Have a bite to eat while enjoying some funky old soul, then hold on tight for a supercharged dance floor experience as we cycle through your favorite genres. With a setlist that boasts over 300 songs, we have a little something for everyone. The Officials Band deliver as smooth as Frankie Blue Eyes, and as sharp as MJ. Feel free to request the anthem or ballad that fuels your trip down memory lane. You can relax and focus on having fun, because The Officials Band will do the rest.";
                band2.CoverCharge = 10;
                band2.Showtime = "10:00 PM";
                context.Bands.Add(band2);

                band3.Name = "Ocean Drive Party Band O.D.P.B.";
                band3.Owner = user;
                band3.Genre = "Variety";
                band3.Rating = 5;
                band3.Description = "Ocean Drive has over 350 of the most popular songs, Motown, Beach & Shag, Oldies, Classic Country Music, Tropical Rock (Jimmy Buffett style tunes), Classic Rock, Jazz, Blues, Southern Rock, Funk and more. Perfect for your budget and event, Ocean Drive is available as a 2, 3 or 4 piece band and can include an optional SAXOPHONE player, pending availability. ";
                band3.CoverCharge = 10;
                band3.Showtime = "10:00 PM";
                context.Bands.Add(band3);

                band4.Name = "Palmetto Soul";
                band4.Owner = user;
                band4.Genre = "Rock";
                band4.Rating = 5;
                band4.Description = "Coming to Charleston before the big day? We love to meet with our Brides, Grooms and their families to review reception layout, go over song selections, choose special dance songs, and answer any questions you may have. Having your ceremony at the same venue as your reception? Yep, we do that too! We are happy to provide beautiful ceremony music as your guest are arriving, during the actual ceremony and as you take your first steps down the aisle as Mr. & Mrs.! ";
                band4.CoverCharge = 10;
                band4.Showtime = "10:00 PM";
                context.Bands.Add(band);

                band5.Name = "Melonbelly Acoustic Guitarists Charleston SC";
                band5.Owner = user;
                band5.Genre = "Variety";
                band5.Rating = 5;
                band5.Description = "Dummy description";
                band5.CoverCharge = 10;
                band5.Showtime = "10:00 PM";
                context.Bands.Add(band5);

                band6.Name = "Andrew Thielen 'Motown' Band";
                band6.Owner = user;
                band6.Genre = "Oldies, disco, beach music";
                band6.Rating = 5;
                band6.Description = "You have found the best party band anywhere. This fabulous band with its numerous, sensational singers is like having the American Idol Band and your favorite singers entertain at your wedding, festival or corporate event. We play it all from classic rock & roll to swing and shag music. We also play funk, dance, light country, 50's, 60's, 70's, motown, beach music, disco, and music of today. But one of our best musical specialties is how we play authentic MOTOWN music with all the live horns saxes and brass. Everyone and every taste will be on the dance floor all night! Great singers, all those horns, fantastic energy, a world class drummer and the songs you just love. This is the band and party everyone will remember for years. Call us now to book your event. ";
                band6.CoverCharge = 10;
                band6.Showtime = "10:00 PM";
                context.Bands.Add(band6);

                band7.Name = "The SugarBees";
                band7.Owner = user;
                band7.Genre = "Variety";
                band7.Rating = 5;
                band7.Description = "The SugarBees are a six piece band which includes vocals, guitar, bass, keyboard, and drums and covers a wide variety of music. Along with covering hit songs from the 60s to today, the band has had many original beach, boogie, and blues hits of their own. ";
                band7.CoverCharge = 10;
                band7.Showtime = "10:00 PM";
                context.Bands.Add(band7);

                band8.Name = "Emerald Empire Band";
                band8.Owner = user;
                band8.Genre = "Various";
                band8.Rating = 5;
                band8.Description = "They play all your favorite songs! The Emerald Empire Band can play all the classics and 70s, 80s, 90s etc, and all the latest stuff too – from Frank Sinatra and Chuck Berry to Kings of Leon and Beyonce– and everything in between. Although this band was built from the ground up to fill the dance floor, all of the musicians are trained jazz musicians, who are just as happy to play cocktail music, acoustic covers, and all of those tunes that work best at the beginning of the night, before the party has really fired up! But when it is time to fill the dancefloor, this is when the band really excels! They pride themselves on knowing exactly the right songs to play at just the right time to pack your dancefloor. See their website for a full list of tunes that they can play, plus live recordings etc... ";
                band8.CoverCharge = 10;
                band8.Showtime = "10:00 PM";
                context.Bands.Add(band8);

                band9.Name = "Chewbacky Band";
                band9.Owner = user;
                band9.Genre = "Country";
                band9.Rating = 5;
                band9.Description = "We are regulars in the bar scene in Charleston and surrounding areas. Chewbacky books weddings, rehearsal dinners, fundraisers, & events of all kinds. Prior to 2016, we booked our special events/ bar gigs via word-of-mouth. Since joining Gigmasters in the December, 2015, we have booked almost 2-dozen events with many references. ";
                band9.CoverCharge = 10;
                band9.Showtime = "10:00 PM";
                context.Bands.Add(band9);
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
