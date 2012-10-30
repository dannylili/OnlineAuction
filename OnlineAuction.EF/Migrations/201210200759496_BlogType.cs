using System.Data.Entity.Migrations;

namespace OnlineAuction.EF.Migrations
{ 
    public partial class BlogType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "BlogType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BlogShortName = c.String(nullable: false, maxLength: 200, unicode: false),
                        BlogBrief = c.String(),
                        BlogUsreID = c.Int(nullable: false),
                        SystemStatus = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.SystemStatus);

            Sql("ALTER TABLE [BlogType] ADD CONSTRAINT [BlogType_AK__Token] UNIQUE (ID)");
        }

        public override void Down()
        {
            DropIndex("BlogType", new[] { "SystemStatus" });
            DropTable("BlogType");
        }
    }
}
