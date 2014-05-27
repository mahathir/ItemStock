namespace ItemStock.Persistence.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ItemStock.Persistence.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<ItemStockContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ItemStockContext context)
        {
            TestData.AppUsers.ForEach(u => context.Users.AddOrUpdate(p => p.Username, u));
            context.SaveChanges();
        }
    }
}
