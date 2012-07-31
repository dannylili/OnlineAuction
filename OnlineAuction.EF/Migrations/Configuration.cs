namespace OnlineAuction.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineAuctionDbContent>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineAuctionDbContent context)
        {
            // ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = 600;
            context.Configuration.LazyLoadingEnabled = true;
            context.Configuration.AutoDetectChangesEnabled = true;
            //context.Database.ExecuteSqlCommand("EXEC zMetaUpdateEffectiveLocalizations");
            //context.Database.ExecuteSqlCommand("EXEC zSecurityCalculateEffectivePermissions");
            //context.Database.ExecuteSqlCommand("EXEC zSecurityCalculateEffectivePermissionsDetail");
        }
    }
}
