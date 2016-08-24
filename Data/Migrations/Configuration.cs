using System;
using Models;

namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ClientsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.ClientsContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Clients.AddOrUpdate(new Client
            {
                FirstName = "John",
                LastName = "Smith",
                Birthday = new DateTime(1992, 1, 1),
            }, new Client
            {
                FirstName = "Sarah",
                LastName = "Conor",
                Birthday = new DateTime(1990, 2, 2)
            });
        }
    }
}
