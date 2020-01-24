namespace CRUDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CrudOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Country = c.String(),
                        Pin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CrudOperations");
        }
    }
}
