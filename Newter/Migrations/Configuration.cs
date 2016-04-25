using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newter.Models;

namespace Newter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Newter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Newter.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var userStore = new UserStore<NewterUser>(context);
            var userManager = new UserManager<NewterUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

           

            if (!context.Users.Any(x => x.UserName == "lsat@gmail.com"))
            {
                var Luke = new NewterUser
                {
                    Handle = "LukeS",
                    Email = "lsat@gmail.com",
                    UserName = "lsat@gmail.com",
                };
                userManager.Create(Luke, "MyP@ssw0rd!");


                var Ann = new NewterUser
                {
                    Handle = "AnnM",
                    Email = "ama@gmail.com",
                    UserName = "ama@gmail.com",
                };
                userManager.Create(Ann, "OmyGoodness3$");


                var Jerry = new NewterUser
                {
                    Handle = "JerryB",
                    Email = "odo@gmail.com",
                    UserName = "odo@gmail.com",
                };
                userManager.Create(Jerry, "comeHome56*");


                var Izzy = new NewterUser
                {
                    Handle = "IzzyS",
                    Email = "izz@gmail.com",
                    UserName = "izz@gmail.com",
                };
                userManager.Create(Izzy, "passwordT90#*");


                Luke.Newts.Add(new Newt()
                {
                    Author = Luke,
                    DateCreated = DateTime.Now,
                    TextBody = "This is hilarious, that the Saints won"
                });
                Luke.Newts.Add(new Newt()
                {
                    Author = Luke,
                    DateCreated = DateTime.Now,
                    TextBody = "I am loving this"
                });
                Luke.Newts.Add(new Newt()
                {
                    Author = Luke,
                    DateCreated = DateTime.Now,
                    TextBody = "Omg my dog ate all my grilled chicken and drunk all my vodka"
                });
                Ann.Newts.Add(new Newt()
                {
                    Author = Ann,
                    DateCreated = DateTime.Now,
                    TextBody = "I love this dress, but the price tag is hefty"
                });
                Ann.Newts.Add(new Newt()
                {
                    Author = Ann,
                    DateCreated = DateTime.Now,
                    TextBody = "I have such an awesome cat, i adore you nickred"
                });
                Ann.Newts.Add(new Newt()
                {
                    Author = Ann,
                    DateCreated = DateTime.Now,
                    TextBody = "Clinton for president, Sander for vice, woman power, got to rule the world"
                });
                Jerry.Newts.Add(new Newt()
                {
                    Author = Jerry,
                    DateCreated = DateTime.Now,
                    TextBody =
                        "How could Barcelona loose this game, they better call Merci to book, cant pay all this money for nothing"
                });
                Jerry.Newts.Add(new Newt()
                {
                    Author = Jerry,
                    DateCreated = DateTime.Now,
                    TextBody = "Ronaldo better bring his game on today, Real Madrib better nail Manchester United bad"
                });
                Jerry.Newts.Add(new Newt()
                {
                    Author = Jerry,
                    DateCreated = DateTime.Now,
                    TextBody = "Footbal state of mind"
                });
                Jerry.Newts.Add(new Newt()
                {
                    Author = Jerry,
                    DateCreated = DateTime.Now,
                    TextBody =
                        "Heading to New York to watch NYC FC vs NY Generals, MAY THE ODDS BE IN THE BEST TEAMS FAVOR "
                });
                Izzy.Newts.Add(new Newt()
                {
                    Author = Izzy,
                    DateCreated = DateTime.Now,
                    TextBody = "bATMAN vs sUPERMAN...EPIC MOVIE..."
                });
                Izzy.Newts.Add(new Newt()
                {
                    Author = Izzy,
                    DateCreated = DateTime.Now,
                    TextBody = "Ironyard Little Rock graduation in 4 weeks, gonna turn up"
                });
                Izzy.Newts.Add(new Newt()
                {
                    Author = Izzy,
                    DateCreated = DateTime.Now,
                    TextBody = "i love me some ice cream, who is with me"
                });

                Izzy.Following.Add(Luke);
                Izzy.Following.Add(Jerry);
                Izzy.Following.Add(Ann);

                Luke.Following.Add(Izzy);
                Luke.Following.Add(Jerry);

                Ann.Following.Add(Luke);
                Ann.Following.Add(Jerry);

                Jerry.Following.Add(Luke);

                context.Newts.AddRange(Luke.Newts);
                context.Newts.AddRange(Ann.Newts);
                context.Newts.AddRange(Jerry.Newts);
                context.Newts.AddRange(Izzy.Newts);

            }
        }
    }
}
