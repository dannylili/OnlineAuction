namespace OnlineAuction.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
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
                    })
                .PrimaryKey(t => t.ID);

            Sql("ALTER TABLE [BlogType] ADD CONSTRAINT [BlogType_AK__Token] UNIQUE (ID)");
        }
        
        public override void Down()
        {
            DropTable("BlogType");
        }
    }
}
