namespace WebApiCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ctr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Infoes");
        }
    }
}
