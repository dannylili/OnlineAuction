namespace OnlineAuction.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Student : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Age = c.Int(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
        }

        public override void Down()
        {
            DropTable("Students");
        }
    }
}
