namespace DogWalkerAgain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DogWalkerAgain.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DogWalkerAgain.Models.ApplicationDbContext context)
        {
            //context.Dogs.AddOrUpdate(d => d.Id, new Models.Dog[] {
            //    new Models.Dog() {Name = "Charley", Age=4, Breed="Small", Rating=7, Size="Xtra Large", SpayedNeutered=false}
            //});

            context.Users.AddOrUpdate(u => u.Id, new Models.ApplicationUser[] {
                new Models.ApplicationUser() { Email="test", UserName="super test" }
            });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
