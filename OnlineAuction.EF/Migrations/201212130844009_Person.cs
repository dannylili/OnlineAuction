namespace OnlineAuction.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Person : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Age = c.Int(),
                        Sex = c.Int(),
                        Nickname = c.String(),
                        SystemStatus = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserType = c.Int(nullable: false),
                        PersonID = c.Int(),
                        EntryName = c.String(),
                        EntryVeryPwd = c.String(),
                        Email = c.String(nullable: false),
                        SystemStatus = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("People", t => t.PersonID)
                .Index(t => t.PersonID);

        }

        public override void Down()
        {
            DropIndex("Users", new[] { "PersonID" });
            DropForeignKey("Users", "PersonID", "People");
            DropTable("Users");
            DropTable("People");
        }
    }
}
