﻿using BrewsMuse.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web
{
    public static class DataSeeder
    {

        public static async void SeedData(this IApplicationBuilder app)
        {
            //Thanks Nikolay Kostov: http://stackoverflow.com/questions/34536021/seed-initial-data-in-entity-framework-7-rc-1-and-asp-net-mvc-6

            var context = app.ApplicationServices.GetRequiredService<ApplicationContext>();

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var vendor1 = new Vendor();
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

            var beer1 = new Beer();
            var beer2 = new Beer();
            var beer3 = new Beer();
            var beer4 = new Beer();
            var beer5 = new Beer();
            var beer6 = new Beer();
            var beer7 = new Beer();
            var beer8 = new Beer();
            var beer9 = new Beer();
            var beer10 = new Beer();
            var beer11 = new Beer();
            var beer12 = new Beer();
            var beer13 = new Beer();
            var beer14 = new Beer();
            var beer15 = new Beer();
            var beer16 = new Beer();
            var beer17 = new Beer();
            var beer18 = new Beer();
            var beer19 = new Beer();
            var beer20 = new Beer();
            var beer21 = new Beer();
            var beer22 = new Beer();
            var beer23 = new Beer();
            var beer24 = new Beer();
            var beer25 = new Beer();
            var beer26 = new Beer();
            var beer27 = new Beer();
            var beer28 = new Beer();
            var beer29 = new Beer();
            var beer30 = new Beer();
            var beer31 = new Beer();
            var beer32 = new Beer();
            var beer33 = new Beer();
            var beer34 = new Beer();
            var beer35 = new Beer();
            var beer36 = new Beer();
            var beer37 = new Beer();
            var beer38 = new Beer();
            var beer39 = new Beer();
            var beer40 = new Beer();
            var beer41 = new Beer();
            var beer42 = new Beer();
            var beer43 = new Beer();
            var beer44 = new Beer();
            var beer45 = new Beer();


            var band1 = new Band();
            var band2 = new Band();
            var band3 = new Band();
            var band4 = new Band();
            var band5 = new Band();
            var band6 = new Band();
            var band7 = new Band();
            var band8 = new Band();
            var band9 = new Band();
            var band10 = new Band();
            var band11 = new Band();
            var band12 = new Band();
            var band13 = new Band();
            var band14 = new Band();
            var band15 = new Band();
            var band16 = new Band();
            var band17 = new Band();
            var band18 = new Band();
            var band19 = new Band();
            var band20 = new Band();


            var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync("vendor@vendor.com");
            //var userStore = new UserStore<ApplicationUser>(context);

            user = new ApplicationUser();


            user.Email = "vendor@vendor.com";
            await userManager.CreateAsync(user, "password");
            context.Add(user);


            vendor1.Name = "Bay Street Biergarten";
            vendor1.OwnerName = "Jonathan Weitz";
            vendor1.Address = "549 E Bay St";
            vendor1.City = "Charleston";
            vendor1.State = "SC";
            vendor1.ZipCode = 29403;
            vendor1.Hours = "11:00 AM - 2:00 AM";
            vendor1.VendorURL = "http://baystreetbiergarten.com/";
            vendor1.VendorPhone = "843-266-2437";
            vendor1.Rating = 4;
            vendor1.ImageURL = "https://pbs.twimg.com/profile_images/578927224771870720/u-sRbrst.jpeg";
            vendor1.Lng = -79.9314;
            vendor1.Lat = 32.7920;
            //vendor1.Owner = user;
            vendor1.UserName = user.UserName;
            context.Vendors.Add(vendor1);


            vendor2.Name = "Closed for Business";
            vendor2.Address = "453 King St.";
            vendor2.City = "Charleston";
            vendor2.State = "SC";
            vendor2.ZipCode = 29403;
            vendor2.OwnerName = "The Indigo Road";
            //vendor2.Owner = user;
            vendor2.Hours = "11:00 AM - 2:00 AM";
            vendor2.VendorURL = "http://closed4business.com/";
            vendor2.VendorPhone = "843-853-8466";
            vendor2.Rating = 4;
            vendor2.Lng = -79.9384;
            vendor2.Lat = 32.7886;
            vendor2.ImageURL = "https://media1.fdncms.com/charleston/imager/u/blog/6018630/cfb_logo.jpg?cb=1478128577";
            vendor2.UserName = user.UserName;
            context.Vendors.Add(vendor2);

            vendor3.Name = "Charleston Beer Works";
            vendor3.Address = "480 King Street St.";
            vendor3.City = "Charleston";
            vendor3.State = "SC";
            vendor3.ZipCode = 29401;
            vendor3.OwnerName = "Joe Raya";
            //vendor3.Owner = user;
            vendor3.Hours = "11:30 PM - 2:00 AM";
            vendor3.VendorURL = "http://charlestonbeerworks.com/";
            vendor3.VendorPhone = "843-577-6111";
            vendor3.Rating = 4;
            vendor3.Lng = -79.9287;
            vendor3.Lat = 32.7768;
            vendor3.UserName = user.UserName;
            vendor3.ImageURL = "http://res.cloudinary.com/seanryanhubbard/image/upload/d_logo-placeholder_pdnlzn.png,t_logo_transformation/v1459548809/charleston-beer-works.png";
            context.Vendors.Add(vendor3);

            vendor4.Name = "Lagunitas";
            vendor4.Address = "161 E Bay St.";
            vendor4.City = "Charleston";
            vendor4.State = "SC";
            vendor4.ZipCode = 29401;
            vendor5.OwnerName = "Tony Magee";
            //vendor4.Owner = user;
            vendor4.Hours = "1200 PM - 9:00 PM";
            vendor4.VendorURL = "https://lagunitas.com/taprooms/charleston";
            vendor4.VendorPhone = "843-853-4677";
            vendor4.Rating = 5;
            vendor4.Lng = -79.9274;
            vendor4.Lat = 32.7785;
            vendor4.UserName = user.UserName;
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
            //vendor5.Owner = user;
            vendor5.Hours = "11:30 AM - 2:00 AM";
            vendor5.VendorURL = "http://tattooedmoose.com/";
            vendor5.VendorPhone = "843-277-2990";
            vendor5.Rating = 5;
            vendor5.Lng = -79.9493;
            vendor5.UserName = user.UserName;
            vendor5.Lat = 32.8114;
            vendor5.ImageURL = "http://tattooedmoose.com/images/moose_logo_400px.png?crc=4036922751";
            context.Vendors.Add(vendor5);

            vendor6.Name = "Tommy Condons";
            vendor6.Address = "160 Church St.";
            vendor6.City = "Charleston";
            vendor6.State = "SC";
            vendor6.ZipCode = 29401;
            vendor6.OwnerName = "Alison Vandal Baker and Allan Vandal";
            //vendor6.Owner = user;
            vendor6.Hours = "11:00 AM - 2:00 AM";
            vendor6.VendorURL = "tommycondons.com";
            vendor6.VendorPhone = "843-577-3818";
            vendor6.Rating = 5;
            vendor6.Lng = -79.9295;
            vendor6.Lat = 32.7801;
            vendor6.UserName = user.UserName;
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
            //vendor7.Owner = user;
            vendor7.Hours = "4:00 PM - 2:00 AM";
            vendor7.VendorURL = "http://theroyalamerican.com/";
            vendor7.VendorPhone = "843-817-6925";
            vendor7.Rating = 5;
            vendor7.Lng = -79.9420;
            vendor7.Lat = 32.8067;
            vendor7.UserName = user.UserName;
            vendor7.ImageURL = "https://media2.fdncms.com/charleston/imager/the-royal-american/u/zoom/4007753/royalam.jpg";
            context.Vendors.Add(vendor7);


            vendor8.Name = "The Griffon";
            vendor8.Address = "18 Vendue Range";
            vendor8.City = "Charleston";
            vendor8.State = "SC";
            vendor8.ZipCode = 29401;
            vendor8.OwnerName = "";
            //vendor8.Owner = user;
            vendor8.Hours = "12:00 Pm - 2:00 AM";
            vendor8.VendorURL = "www.griffoncharleston.com";
            vendor8.VendorPhone = "843-723-1700";
            vendor8.Rating = 3;
            vendor8.Lng = -79.9262;
            vendor8.Lat = 32.7790;
            vendor8.UserName = user.UserName;
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
            //vendor9.Owner = user;
            vendor9.Hours = "11:00 AM - 2:00 AM";
            vendor9.VendorURL = "http://thealleycharleston.com/";
            vendor9.VendorPhone = "843-818-4080";
            vendor9.Rating = 4;
            vendor9.Lng = -79.9407;
            vendor9.Lat = 32.7938;
            vendor9.UserName = user.UserName;
            vendor9.ImageURL = "http://www.charlestoncvb.com/images/calendar/29191618911352901.jpg";
            context.Vendors.Add(vendor9);

            vendor10.Name = "Blind Tiger Pub";
            vendor10.Address = "36 Broad St.";
            vendor10.City = "Charleston";
            vendor10.State = "SC";
            vendor10.ZipCode = 29401;
            vendor10.OwnerName = "Lisa Brown";
            // vendor10.Owner = user;
            vendor10.Hours = "11:00 AM - 2:00 AM";
            vendor10.VendorURL = "http://blindtigerchs.com/";
            vendor10.VendorPhone = "843-872-6700";
            vendor10.Rating = 4;
            vendor10.Lng = -79.9287;
            vendor10.Lat = 32.7768;
            vendor10.UserName = user.UserName;
            vendor10.ImageURL = "http://blindtigerchs.com/wp-content/uploads/2016/08/logo-mobile.png";
            context.Vendors.Add(vendor10);

            vendor11.Name = "Salty Mike's";
            vendor11.Address = "17 Lockwood Dr.";
            vendor11.City = "Charleston";
            vendor11.State = "SC";
            vendor11.ZipCode = 29401;
            vendor11.OwnerName = "Mike Salato";
            //vendor11.Owner = user;
            vendor11.Hours = "3:00 PM - 10:00 PM";
            vendor11.VendorURL = "https://www.varietystorerestaurant.com/";
            vendor11.VendorPhone = "843-937-0208";
            vendor11.Rating = 5;
            vendor11.Lng = -79.9503;
            vendor11.Lat = 32.7787;
            vendor11.UserName = user.UserName;
            vendor11.ImageURL = "https://static.wixstatic.com/media/ff43d5_2f7309ede9144011bb97d3ac93f04248.png/v1/fill/w_449,h_630,al_c,usm_0.66_1.00_0.01/ff43d5_2f7309ede9144011bb97d3ac93f04248.png";
            context.Vendors.Add(vendor11);

            beer1.Name = "Kolsch";
            // beer1.Owner = vendor1.Owner;
            beer1.Price = 1;
            beer1.Rating = 5;
            beer1.Brewery = "COAST Brewing Company";
            beer1.Type = "Pilsner";
            beer1.AlcoholContent = 4.8m;
            beer1.ImageURL = "https://static1.squarespace.com/static/550a07dee4b0fbec78ea4081/t/55b62405e4b0c854e25c297f/1438000147227/Kolsch+can+and+stange.jpg";
            vendor1.Beers.Add(beer1);

            beer2.Name = "PB&J";
            // beer2.Owner = vendor2.Owner;
            beer2.Price = 1;
            beer2.Rating = 5;
            beer2.Brewery = "Edmund's Oast";
            beer2.Type = "Stout";
            beer2.AlcoholContent = 5.0m;
            beer2.ImageURL = "https://cdn.pastemagazine.com/www/articles/edmunds%20beer%20interior.jpg";
            vendor2.Beers.Add(beer2);

            beer3.Name = "Hoptart";
            // beer3.Owner = vendor3.Owner;
            beer3.Price = 1;
            beer3.Rating = 5;
            beer3.Brewery = "Freehouse Brewery";
            beer3.Type = "Saison";
            beer3.AlcoholContent = 8.0m;
            beer3.ImageURL = "http://www.charminginns.com/blog/wp-content/uploads/2014/05/Freehouse-Brewery-Circa-Patio.jpg";
            vendor3.Beers.Add(beer3);

            ///
            beer4.Name = "Blackbeerd";
            // beer4.Owner = vendor4.Owner;
            beer4.Price = 1;
            beer4.Rating = 5;
            beer4.Brewery = "COAST Brewing Company";
            beer4.Type = "Stout";
            beer4.AlcoholContent = 9.3m;
            beer4.ImageURL = "https://coppertopbrews.files.wordpress.com/2010/07/coast-brewery-6-of-11.jpg";
            vendor4.Beers.Add(beer4);

            beer5.Name = "Viridi Rex";
            //beer5.Owner = vendor5.Owner;
            beer5.Price = 1;
            beer5.Rating = 5;
            beer5.Brewery = "Edmund's Oast";
            beer5.Type = "IPA";
            beer5.AlcoholContent = 9.5m;
            beer5.ImageURL = "https://untappd.akamaized.net/photo/2016_02_14/689c288fcc717f5a833337523c25c7cf_320x320.jpg";
            vendor5.Beers.Add(beer5);



            beer6.Name = "Charleston Lager";
            //beer6.Owner = vendor6.Owner;
            beer6.Price = 1;
            beer6.Rating = 5;
            beer6.Brewery = "Palmetto Brewing Company";
            beer6.Type = "Amber Ale";
            beer6.AlcoholContent = 5.4m;
            beer6.ImageURL = "http://1.bp.blogspot.com/-DRDPFpFt2as/UFsk2bBUcWI/AAAAAAAAAhg/t_T0dDLXcTc/s1600/IMG_1120.jpg";
            vendor6.Beers.Add(beer6);


            ///
            beer7.Name = "Palmetto Pale Ale";
            //beer7.Owner = vendor7.Owner;
            beer7.Price = 1;
            beer7.Rating = 5;
            beer7.Brewery = "Palmetto Brewing Company";
            beer7.Type = "American Pale Ale";
            beer7.AlcoholContent = 5.2m;
            beer7.ImageURL = "https://s-media-cache-ak0.pinimg.com/736x/45/30/01/45300116731abd81f406b43ec6fbe82e.jpg";
            vendor7.Beers.Add(beer7);

            beer8.Name = "White Thai";
            //beer8.Owner = vendor8.Owner;
            beer8.Price = 1;
            beer8.Rating = 5;
            beer8.Brewery = "Westbrook Brewing Company";
            beer8.Type = "Wheat beer";
            beer8.AlcoholContent = 5.0m;
            beer8.ImageURL = "http://www.camrgb.org/wp-content/uploads/2013/09/White-Thai.jpg";
            vendor8.Beers.Add(beer8);

            beer9.Name = "Boy King Double IPA";
           // beer9.Owner = vendor9.Owner;
            beer9.Price = 1;
            beer9.Rating = 5;
            beer9.Brewery = "Coast Brewing Company";
            beer9.Type = "IPA";
            beer9.AlcoholContent = 9.7m;
            beer9.ImageURL = "https://dontdrinkbeer.files.wordpress.com/2012/07/boyking.jpg";
            vendor9.Beers.Add(beer9);

            beer10.Name = "Dead Arm";
            //beer10.Owner = vendor10.Owner;
            beer10.Price = 1;
            beer10.Rating = 5;
            beer10.Brewery = "COAST Brewing Company";
            beer10.Type = "American Pale Ale";
            beer10.AlcoholContent = 6.0m;
            beer10.ImageURL = "http://beerstreetjournal.com/wp-content/uploads/Coast-Brewing-Dead-Arm-Pale-Ale.jpg";
            vendor10.Beers.Add(beer10);

            beer11.Name = "Bells Two Hearted Ale";
            //beer11.Owner = vendor11.Owner;
            beer11.Price = 1;
            beer11.Rating = 5;
            beer11.Brewery = "Bell's Brewery";
            beer11.Type = "American IPA";
            beer11.AlcoholContent = 7.0m;
            beer11.ImageURL = "http://image.mlive.com/home/mlive-media/width620/img/grpress/entertainment_impact/photo/10755972-standard.jpg";
            vendor11.Beers.Add(beer11);
            vendor9.Beers.Add(beer11);
            vendor1.Beers.Add(beer11);
            vendor2.Beers.Add(beer11);
            vendor3.Beers.Add(beer11);
            vendor4.Beers.Add(beer11);
            vendor5.Beers.Add(beer11);
            vendor6.Beers.Add(beer11);
            vendor7.Beers.Add(beer11);
            vendor8.Beers.Add(beer11);
            vendor10.Beers.Add(beer11);


            beer12.Name = "Dead Arm";
            //beer12.Owner = vendor1.Owner;
            beer12.Price = 1;
            beer12.Rating = 5;
            beer12.Brewery = "COAST Brewing Company";
            beer12.Type = "American Pale Ale";
            beer12.AlcoholContent = 6.0m;
            beer12.ImageURL = "http://beerstreetjournal.com/wp-content/uploads/Coast-Brewing-Dead-Arm-Pale-Ale.jpg";
            vendor1.Beers.Add(beer12);

            beer13.Name = "ALTerior Motive";
            //beer13.Owner = vendor2.Owner;
            beer13.Price = 1;
            beer13.Rating = 4;
            beer13.Brewery = "COAST Brewing Company";
            beer13.Type = "Altbier";
            beer13.AlcoholContent = 6.30m;
            beer13.ImageURL = "https://cdn.beeradvocate.com/im/beers/44410.jpg";
            vendor2.Beers.Add(beer13);

            beer14.Name = "Belafonte";
            //beer14.Owner = vendor3.Owner;
            beer14.Price = 1;
            beer14.Rating = 4;
            beer14.Brewery = "COAST Brewing Company";
            beer14.Type = "Belgian Pale Ale";
            beer14.AlcoholContent = 5.7m;
            beer14.ImageURL = "https://s3-media3.fl.yelpcdn.com/bphoto/9DzfWSM0u-PwBwT2NgkYAA/o.jpg";
            vendor3.Beers.Add(beer14);

            beer15.Name = "Oktoberfest";
            //beer15.Owner = vendor4.Owner;
            beer15.Price = 4;
            beer15.Rating = 4;
            beer15.Brewery = "COAST Brewing Company";
            beer15.Type = "Oktoberfest";
            beer15.AlcoholContent = 6.0m;
            beer15.ImageURL = "https://static1.squarespace.com/static/550a07dee4b0fbec78ea4081/55a03784e4b007dc1bdec44f/55cdbfc6e4b0a1e3b9c0558d/1439583241165/Oktoberfest+Website.jpg";
            vendor4.Beers.Add(beer15);

            beer16.Name = "Pinata Pirate";
            //beer16.Owner = vendor5.Owner;
            beer16.Price = 4;
            beer16.Rating = 4;
            beer16.Brewery = "COAST Brewing Company";
            beer16.Type = "American Brown Ale";
            beer16.AlcoholContent = 4.20m;
            beer16.ImageURL = "https://static1.squarespace.com/static/550a07dee4b0fbec78ea4081/55a03784e4b007dc1bdec44f/55ce49a4e4b0f1c896899d7f/1439583323345/Pinata+Pirate+Wesbite.jpg";
            vendor5.Beers.Add(beer16);

            beer17.Name = "Session IPA";
            //beer17.Owner = vendor6.Owner;
            beer17.Price = 4;
            beer17.Rating = 4;
            beer17.Brewery = "COAST Brewing Company";
            beer17.Type = "American IPA";
            beer17.AlcoholContent = 4.70m;
            beer17.ImageURL = "http://www.holycitysinner.com/wp-content/uploads/2017/02/paradisegl.jpg";
            vendor6.Beers.Add(beer17);

            beer18.Name = "ToeTally Pale";
           // beer18.Owner = vendor7.Owner;
            beer18.Price = 4;
            beer18.Rating = 4;
            beer18.Brewery = "COAST Brewing Company";
            beer18.Type = "American Pale Ale";
            beer18.AlcoholContent = 5.4m;
            beer18.ImageURL = "https://s3-media4.fl.yelpcdn.com/bphoto/aeNQZYs1X-dhs2ScpqbgfA/348s.jpg";
            vendor7.Beers.Add(beer18);

            beer19.Name = "Saison Du Fus";
            //beer19.Owner = vendor8.Owner;
            beer19.Price = 4;
            beer19.Rating = 4;
            beer19.Brewery = "COAST Brewing Company";
            beer19.Type = "Saison";
            beer19.AlcoholContent = 7.3m;
            beer19.ImageURL = "https://cdn.beeradvocate.com/im/beers/96120.jpg";
            vendor8.Beers.Add(beer19);

            beer20.Name = "Same Old, Same Old";
           // beer20.Owner = vendor9.Owner;
            beer20.Price = 4;
            beer20.Rating = 5;
            beer20.Brewery = "COAST Brewing Company";
            beer20.Type = "American Amber";
            beer20.AlcoholContent = 5.50m;
            beer20.ImageURL = "https://cdn.beeradvocate.com/im/beers/91808.jpg";
            vendor9.Beers.Add(beer20);


            beer21.Name = "Bulls Bay Oyster Stout";
           // beer21.Owner = vendor10.Owner;
            beer21.Price = 4;
            beer21.Rating = 5;
            beer21.Brewery = "COAST Brewing Company";
            beer21.Type = "Export Stout";
            beer21.AlcoholContent = 5.80m;
            beer21.ImageURL = "https://cdn.beeradvocate.com/im/beers/65420.jpg";
            vendor10.Beers.Add(beer21);

            beer22.Name = "Harold";
           // beer22.Owner = vendor11.Owner;
            beer22.Price = 4;
            beer22.Rating = 4;
            beer22.Brewery = "COAST Brewing Company";
            beer22.Type = "American Stout";
            beer22.AlcoholContent = 6.0m;
            beer22.ImageURL = "https://media1.fdncms.com/charleston/imager/coast-brewings-beers-will-on-hand-at-brewvial/u/zoom/4023085/coastaltbier129_resized.jpg";
            vendor11.Beers.Add(beer22);

            beer23.Name = "Wadamalaw Sunset";
           // beer23.Owner = vendor1.Owner;
            beer23.Price = 4;
            beer23.Rating = 4;
            beer23.Brewery = "COAST Brewing Company";
            beer23.Type = "Belgian Strong Pale Ale";
            beer23.AlcoholContent = 7.50m;
            beer23.ImageURL = "https://www.wheretraveler.com/sites/default/files/styles/large/public/Palmetto_Brewing.jpg?itok=Oj1Kkuc9";
            vendor1.Beers.Add(beer23);

            beer24.Name = "Hi-Red";
           // beer24.Owner = vendor2.Owner;
            beer24.Price = 4;
            beer24.Rating = 4;
            beer24.Brewery = "Palmetto Brewery";
            beer24.Type = "American Amber";
            beer24.AlcoholContent = 5.50m;
            beer24.ImageURL = "https://lh4.ggpht.com/dPGO_x3U1cryf3HGXCZSi1IMW0mIfPaO65XdahCyVDw5YEcfDUvrUgPgFeYhJVFfuYP3piq9bul9MGuogyqkan7RfqMscQ=s750";
            vendor2.Beers.Add(beer24);

            beer25.Name = "Colonel Rathburn's Farmhouse Ale";
            //beer25.Owner = vendor3.Owner;
            beer25.Price = 4;
            beer25.Rating = 4;
            beer25.Brewery = "Palmetto Brewery";
            beer25.Type = "Farmhouse Ale";
            beer25.AlcoholContent = 7.80m;
            beer25.ImageURL = "http://bloximages.newyork1.vip.townnews.com/postandcourier.com/content/tncms/assets/v3/editorial/0/11/011c9ba4-2ba2-5bd4-81a5-c2f6ba49b72c/5804feccbf4b6.image.jpg?resize=1200%2C1594";
            vendor3.Beers.Add(beer25);

            beer26.Name = "Maize To Black";
            //beer26.Owner = vendor4.Owner;
            beer26.Price = 4;
            beer26.Rating = 4;
            beer26.Brewery = "Palmetto Brewery";
            beer26.Type = "Lager - Dark";
            beer26.AlcoholContent = 4.1m;
            beer26.ImageURL = "http://www.brewerydb.com/img/glassware/pint_medium.png";
            vendor4.Beers.Add(beer26);

            beer27.Name = "Nero";
           // beer27.Owner = vendor5.Owner;
            beer27.Price = 4;
            beer27.Rating = 4;
            beer27.Brewery = "Palmetto Brewery";
            beer27.Type = "IPA - Black";
            beer27.AlcoholContent = 5.5m;
            beer27.ImageURL = "https://lh4.ggpht.com/dPGO_x3U1cryf3HGXCZSi1IMW0mIfPaO65XdahCyVDw5YEcfDUvrUgPgFeYhJVFfuYP3piq9bul9MGuogyqkan7RfqMscQ=s750";
            vendor5.Beers.Add(beer27);

            beer28.Name = "50 Shades of Green";
           // beer28.Owner = vendor6.Owner;
            beer28.Price = 1;
            beer28.Rating = 5;
            beer28.Brewery = "Holy City Brewing";
            beer28.Type = "Imperial IPA";
            beer28.AlcoholContent = 9.0m;
            beer28.ImageURL = "http://www.holycitybrewing.com/sites/default/files/hcb_logo.png";
            vendor6.Beers.Add(beer28);

            beer29.Name = "#BillPitts";
           // beer29.Owner = vendor7.Owner;
            beer29.Price = 1;
            beer29.Rating = 5;
            beer29.Brewery = "Holy City Brewing";
            beer29.Type = "English Pale Mild Ale";
            beer29.AlcoholContent = 3.7m;
            beer29.ImageURL = "http://www.holycitybrewing.com/sites/all/themes/hcb/images/photo-empty.jpg";
            vendor7.Beers.Add(beer29);

            beer30.Name = "Pluff Mud Porter";
           // beer30.Owner = vendor8.Owner;
            beer30.Price = 4;
            beer30.Rating = 4;
            beer30.Brewery = "Holy City Brewing";
            beer30.Type = "American Porter";
            beer30.AlcoholContent = 5.50m;
            beer30.ImageURL = "http://www.holycitybrewing.com/sites/default/files/imagecache/custom_1000px/photos/093b1692.jpg";
            vendor8.Beers.Add(beer30);

            beer31.Name = "Holy City Pilsner";
            //beer31.Owner = vendor9.Owner;
            beer31.Price = 4;
            beer31.Rating = 4;
            beer31.Brewery = "Holy City Brewing";
            beer31.Type = "German Pilsner";
            beer31.AlcoholContent = 5.0m;
            beer31.ImageURL = "http://res.cloudinary.com/ratebeer/image/upload/w_250,c_limit/beer_139963.jpg";
            vendor9.Beers.Add(beer31);

            beer32.Name = "Washout Wheat";
            //beer32.Owner = vendor10.Owner;
            beer32.Price = 4;
            beer32.Rating = 4;
            beer32.Brewery = "Holy City Brewing";
            beer32.Type = "Hefeweizen";
            beer32.AlcoholContent = 5.3m;
            beer32.ImageURL = "http://68.media.tumblr.com/4148b40ecde756f2b146d7bfde10f316/tumblr_inline_mvvcebCcOl1rlvsal.jpg";
            vendor10.Beers.Add(beer32);

            beer33.Name = "Smells Like Rick";
            //beer33.Owner = vendor11.Owner;
            beer33.Price = 4;
            beer33.Rating = 4;
            beer33.Brewery = "Holy City Brewing";
            beer33.Type = "Germna Pilsner";
            beer33.AlcoholContent = 5.0m;
            beer33.ImageURL = "https://res.cloudinary.com/ratebeer/image/upload/w_120,c_limit/beer_217870.jpg";
            vendor11.Beers.Add(beer33);

            beer34.Name = "Fancy Stout";
            //beer34.Owner = vendor1.Owner;
            beer34.Price = 4;
            beer34.Rating = 4;
            beer34.Brewery = "Holy City Brewing";
            beer34.Type = "American Stout";
            beer34.AlcoholContent = 5.80m;
            beer34.ImageURL = "http://www.holycitybrewing.com/sites/all/themes/hcb/images/photo-beers.jpg";
            vendor1.Beers.Add(beer34);

            beer35.Name = "Overly Friendly IPA";
            //beer35.Owner = vendor2.Owner;
            beer35.Price = 4;
            beer35.Rating = 4;
            beer35.Brewery = "Holy City Brewing";
            beer35.Type = "IPA";
            beer35.AlcoholContent = 6.9m;
            beer35.ImageURL = "https://beerconnoisseur.com/sites/default/files/styles/beer_page_245w/public/beer/overly-friendly-ipa-by-holy-city-brewing-co.jpg?itok=tzBLbESZ";
            vendor2.Beers.Add(beer35);

            beer36.Name = "Carlsberg Beer";
           // beer36.Owner = vendor3.Owner;
            beer36.Price = 3;
            beer36.Rating = 3;
            beer36.Brewery = "Carlsberg Danmark";
            beer36.Type = "German Pilsner";
            beer36.AlcoholContent = 5.0m;
            beer36.ImageURL = "http://kingofwallpapers.com/carlsberg/carlsberg-004.jpg";
            vendor3.Beers.Add(beer36);

            beer37.Name = "Guinness Blonde American Lager";
            //beer37.Owner = vendor4.Owner;
            beer37.Price = 3;
            beer37.Rating = 3;
            beer37.Brewery = "Guinness";
            beer37.Type = "American Pale Lager";
            beer37.AlcoholContent = 5.0m;
            beer37.ImageURL = "http://res.cloudinary.com/ratebeer/image/upload/w_250,c_limit/beer_288072.jpg";
            vendor4.Beers.Add(beer37);

            beer38.Name = "Guinness Extra Stout";
            //beer38.Owner = vendor5.Owner;
            beer38.Price = 4;
            beer38.Rating = 4;
            beer38.Brewery = "Guinness";
            beer38.Type = "Irish Dry Stout";
            beer38.AlcoholContent = 6.0m;
            beer38.ImageURL = "http://www.beerfm.com/wp-content/uploads/2012/03/Guinness-Extra-Stout.jpg";
            vendor5.Beers.Add(beer38);

            beer39.Name = "Stella Artois";
            //beer39.Owner = vendor6.Owner;
            beer39.Price = 3;
            beer39.Rating = 3;
            beer39.Brewery = "Stella Artois";
            beer39.Type = "Euro Pale Lager";
            beer39.AlcoholContent = 5.0m;
            beer39.ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/10/Stella_Artois_new_logo.png/220px-Stella_Artois_new_logo.png";
            vendor6.Beers.Add(beer39);

            beer40.Name = "Heineken Lager Beer";
            //beer40.Owner = vendor7.Owner;
            beer40.Price = 3;
            beer40.Rating = 3;
            beer40.Brewery = "Heineken Nederland B.V.";
            beer40.Type = "Euro Pale Lager";
            beer40.AlcoholContent = 5.0m;
            beer40.ImageURL = "http://www.visitspirits.com/media/catalog/product/cache/1/image/500x500/9df78eab33525d08d6e5fb8d27136e95/h/e/heineken_lager_beer_2.jpg";
            vendor7.Beers.Add(beer40);

            beer41.Name = "Dead Arm";
            //beer41.Owner = vendor8.Owner;
            beer41.Price = 1;
            beer41.Rating = 5;
            beer41.Brewery = "COAST Brewing Company";
            beer41.Type = "American Pale Ale";
            beer41.AlcoholContent = 6.0m;
            beer41.ImageURL = "http://beerstreetjournal.com/wp-content/uploads/Coast-Brewing-Dead-Arm-Pale-Ale.jpg";
            vendor8.Beers.Add(beer41);

            beer42.Name = "Foster's Lager";
            //beer42.Owner = vendor9.Owner;
            beer42.Price = 3;
            beer42.Rating = 3;
            beer42.Brewery = "Foster's Group Limited";
            beer42.Type = "American Adjunct Lager";
            beer42.AlcoholContent = 5.0m;
            beer42.ImageURL = "https://www.owliquors.com/image/cache/data/beer/fosters/fosters-lager-can-500x500.jpg";
            vendor9.Beers.Add(beer42);

            beer43.Name = "Jupiler";
            //beer43.Owner = vendor10.Owner;
            beer43.Price = 3;
            beer43.Rating = 3;
            beer43.Brewery = "Brasserie Piedboeuf ";
            beer43.Type = "Euro Pale Lager";
            beer43.AlcoholContent = 5.20m;
            beer43.ImageURL = "https://www.beermerchants.com/media/catalog/product/cache/1/image/x400/17f82f742ffe127f42dca9de82fb58b1/j/u/jupiler_2.png";
            vendor10.Beers.Add(beer43);

            beer44.Name = "Blue Moon Belgian White";
           // beer44.Owner = vendor11.Owner;
            beer44.Price = 1;
            beer44.Rating = 5;
            beer44.Brewery = "Coors Brewing Company";
            beer44.Type = "Whitbier";
            beer44.AlcoholContent = 5.40m;
            beer44.ImageURL = "https://www.bluemoonbrewingcompany.com/sites/bluemoon/files/our-beers/bottle-image/BM_SB_BottlePour_AC.png";
            vendor11.Beers.Add(beer44);

            beer45.Name = "Vodka and Sprite";
         //   beer45.Owner = vendor11.Owner;
            beer45.Price = 0;
            beer45.Rating = 0;
            beer45.Brewery = "Russians, I guess";
            beer45.Type = "Cocktail";
            beer45.AlcoholContent = 100.0m;

            if (user.Email == "colby@burke.com")
            {
                vendor11.Beers.Add(beer45);
            }
            else
            {

            }


            band1.Name = "MoJo McGee";
            //band1.Owner = user;
            band1.Genre = "Various";
            band1.Rating = 5;
            band1.CoverCharge = 30;
            band1.Showtime = "4/5/2017 10:00 PM - 12:00 AM";
            band1.ImageURL = "http://metronomecharleston.com/wp-content/uploads/2012/10/Mojo-McGee-July-2012-Tattooed-Moose.jpg";
            vendor1.Bands.Add(band1);
            vendor10.Bands.Add(band1);


            band2.Name = "The Officials Band";
            //band2.Owner = user;
            band2.Genre = "Jazz";
            band2.Rating = 5;
            band2.CoverCharge = 10;
            band2.Showtime = "4/10/2017 8:00 PM - 12:00 AM";
            band2.ImageURL = "http://www.gogetwed.com/server/php/rental/thumbnail/1476204254The%20Officials%20Band.JPG";
            vendor1.Bands.Add(band2);
            vendor10.Bands.Add(band2);

            band3.Name = "Ocean Drive Party Band O.D.P.B.";
            //band3.Owner = user;
            band3.Genre = "Variety";
            band3.Rating = 5;
            band3.CoverCharge = 10;
            band3.Showtime = "4/4/2017 10:00 PM - 12:00 AM";
            band3.ImageURL = "https://bandphotoschool.com/wp-content/gallery/ocean-drive-party-band-with-lights-smoke/Ocean-Drive-Party-Band-with-Lights-Smoke-Promo-Composite-2.jpg";
            vendor2.Bands.Add(band3);
            vendor10.Bands.Add(band3);

            band4.Name = "Palmetto Soul";
            //band4.Owner = user;
            band4.Genre = "Rock";
            band4.Rating = 5;
            band4.CoverCharge = 10;
            band4.Showtime = "4/7/2017 10:00 PM - 2:00 AM";
            band4.ImageURL = "https://i.ytimg.com/vi/y-D6f8Ni7Qw/maxresdefault.jpg";
            vendor2.Bands.Add(band4);
            vendor10.Bands.Add(band4);

            band5.Name = "Melonbelly Acoustic Guitarists";
            //band5.Owner = user;
            band5.Genre = "Variety";
            band5.Rating = 5;
            band5.CoverCharge = 10;
            band5.Showtime = "4/6/2017 10:00 PM - 12:00 AM";
            band5.ImageURL = "https://borrowed-and-blue-photos.s3.amazonaws.com/resized/1920/000/790/449/790449.jpg";
            vendor3.Bands.Add(band5);
            vendor10.Bands.Add(band5);

            band6.Name = "Andrew Thielen 'Motown' Band";
            //band6.Owner = user;
            band6.Genre = "Oldies, disco, beach music";
            band6.Rating = 5;
            band6.CoverCharge = 10;
            band6.Showtime = "4/11/2017 9:00 PM - 12:00 AM";
            band6.ImageURL = "http://otherbrotherent.com/wp-content/uploads/2016/09/unnamed.jpg";
            vendor3.Bands.Add(band6);
            vendor10.Bands.Add(band6);

            band7.Name = "The SugarBees";
            //band7.Owner = user;
            band7.Genre = "Variety";
            band7.Rating = 5;
            band7.CoverCharge = 10;
            band7.Showtime = "4/3/2017 10:00 PM - 12:00 AM";
            band7.ImageURL = "https://static.pexels.com/photos/164693/pexels-photo-164693.jpeg";
            vendor4.Bands.Add(band7);
            vendor10.Bands.Add(band7);

            band8.Name = "Emerald Empire Band";
            //band8.Owner = user;
            band8.Genre = "Variety";
            band8.Rating = 5;
            band8.CoverCharge = 10;
            band8.Showtime = "4/5/2017 10:30 PM - 12:00 AM";
            band8.ImageURL = "http://www.enchantedbrides.com/wp-content/uploads/2015/05/Band5.jpg";
            vendor4.Bands.Add(band8);
            vendor10.Bands.Add(band8);

            band9.Name = "Chewbacky Band";
            //band9.Owner = user;
            band9.Genre = "Country";
            band9.Rating = 5;
            band9.CoverCharge = 10;
            band9.Showtime = "4/5/2017 8:00 PM - 12:00 AM";
            band9.ImageURL = "https://scontent-mia1-1.xx.fbcdn.net/v/t1.0-9/13619818_548372268698930_1955597742789786052_n.jpg?oh=b548f1640d6723515965b641370bab8a&oe=594D2828";
            vendor5.Bands.Add(band9);

            band10.Name = "The Vistas";
            //band10.Owner = user;
            band10.Genre = "Rock";
            band10.Rating = 5;
            band10.CoverCharge = 20;
            band10.Showtime = "4/6/2017 10:00 PM - 12:00 AM";
            band10.ImageURL = "https://d3ew4rh7xxgmkq.cloudfront.net/performer/42038/photos/42038-e6a0c158bd444cf1a7cf8f7cdb2a22be-1.jpg";
            vendor5.Bands.Add(band10);

            band11.Name = "Bringers of the Dawn";
           // band11.Owner = user;
            band11.Genre = "Country, Rock";
            band11.Rating = 4;
            band11.CoverCharge = 7;
            band11.Showtime = "4/7/2017 9:00 PM";
            band11.ImageURL = "http://www.myfathersmustache.com/wp-content/uploads/2016/03/bod-1.jpg";
            vendor6.Bands.Add(band11);

            band12.Name = "Marsh Green Mamas";
           // band12.Owner = user;
            band12.Genre = "Bluegrass";
            band12.Rating = 5;
            band12.CoverCharge = 10;
            band12.Showtime = "4/8/2017 10:00 PM";
            band12.ImageURL = "https://scontent-mia1-1.xx.fbcdn.net/v/t31.0-8/469650_417315354979930_1812448824_o.jpg?oh=9ab81b8c0da726c3fa7fb52c34e8ae24&oe=5951C0CC";
            vendor6.Bands.Add(band12);

            band13.Name = "Deadontime";
           // band13.Owner = user;
            band13.Genre = "Punk, Metal";
            band13.Rating = 3;
            band13.CoverCharge = 7;
            band13.Showtime = "4/14/2017 11:00 PM";
            band13.ImageURL = "https://scontent-mia1-1.xx.fbcdn.net/v/t1.0-9/15219367_1299290473428092_1880116306183743992_n.jpg?oh=fb1ad3cd34a2744d2d22f1b01a1dc2f7&oe=59526644";
            vendor7.Bands.Add(band13);

            band14.Name = "Tidal Jive";
            //band14.Owner = user;
            band14.Genre = "Funk";
            band14.Rating = 5;
            band14.CoverCharge = 6;
            band14.Showtime = "4/15/2017 9:00 PM";
            band14.ImageURL = "https://scontent-mia1-1.xx.fbcdn.net/v/t1.0-9/14705743_10153833991561945_3301461508607850334_n.jpg?oh=0ad73e169c957703e730e9b1d570f8c6&oe=59695E05";
            vendor7.Bands.Add(band14);

            band15.Name = "Lumberjack Time Traveller";
            //band15.Owner = user;
            band15.Genre = "Funk";
            band15.Rating = 5;
            band15.CoverCharge = 11;
            band15.Showtime = "4/8/2017 10:00 PM";
            band15.ImageURL = "https://scontent-mia1-1.xx.fbcdn.net/v/t1.0-9/11855817_497368230421559_2507773402350805194_n.jpg?oh=52bf0caa9265891e47f80a9a5149a906&oe=59584C81";
            vendor8.Bands.Add(band15);

            band16.Name = "Guilt Ridden Troubadour";
            //band16.Owner = user;
            band16.Genre = "Rock";
            band16.Rating = 4;
            band16.CoverCharge = 7;
            band16.Showtime = "4/15/2017 8:00 PM";
            band16.ImageURL = "http://theartmag.com/wp-content/uploads/2013/09/GRT-472x315.jpg";
            vendor8.Bands.Add(band16);

            band17.Name = "James Slater Trio";
            //band17.Owner = user;
            band17.Genre = "Jazz";
            band17.Rating = 4;
            band17.CoverCharge = 0;
            band17.Showtime = "4/5/2017 7:00 PM";
            band17.ImageURL = "https://i.ytimg.com/vi/DKySbxmLveo/maxresdefault.jpg";
            vendor9.Bands.Add(band17);

            band18.Name = "Whiskey Diablo";
           // band18.Owner = user;
            band18.Genre = "Country";
            band18.Rating = 3;
            band18.CoverCharge = 5;
            band18.Showtime = "4/15/2017 11:00 PM";
            band18.ImageURL = "https://scontent-mia1-1.xx.fbcdn.net/v/t31.0-8/472722_294547127302189_1147589592_o.jpg?oh=708e34f13761c4e9a1383c5c14c6347c&oe=594DC495";
            vendor9.Bands.Add(band18);

            band19.Name = "Whit's End";
            //band19.Owner = user;
            band19.Genre = "Accoustic Duo";
            band19.Rating = 4;
            band19.CoverCharge = 5;
            band19.Showtime = "4/9/2017 7:00 PM";
            band19.ImageURL = "https://scontent-mia1-1.xx.fbcdn.net/v/t1.0-9/15822710_1524559334224164_5506603032917984727_n.jpg?oh=3f94a4590fc6cc488f676309a3d1b815&oe=594FE56B";
            vendor11.Bands.Add(band19);

            band20.Name = "Michael Martin Band";
          //  band20.Owner = user;
            band20.Genre = "Country";
            band20.Rating = 4;
            band20.CoverCharge = 10;
            band20.Showtime = "4/9/2017 9:00 PM";
            band20.ImageURL = "http://michaelmartinband.com/wp-content/uploads/2015/10/11228024_10153631258691912_7916167733158990162_n-1.jpg";
            vendor11.Bands.Add(band20);



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
