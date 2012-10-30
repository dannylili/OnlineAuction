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
            /// each time get data from database instead of get data from chache when set LazyLoadingEnabled is true
            /// if LazyLoadingEnabled is false,each time get databa from cache rather than from database
            // context.Configuration.LazyLoadingEnabled = true;

            ///  DB.ChangeTracker.DetectChanges();
            // context.Configuration.AutoDetectChangesEnabled = true;
            //context.Database.ExecuteSqlCommand("EXEC zMetaUpdateEffectiveLocalizations");
            //context.Database.ExecuteSqlCommand("EXEC zSecurityCalculateEffectivePermissions");
            //context.Database.ExecuteSqlCommand("EXEC zSecurityCalculateEffectivePermissionsDetail");
        }
    }
}
