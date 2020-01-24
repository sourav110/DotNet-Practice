namespace WebApiCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Infoes", "Address", c => c.String());
            DropColumn("dbo.Infoes", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Infoes", "FirstName", c => c.String());
            DropColumn("dbo.Infoes", "Address");
        }
    }
}
