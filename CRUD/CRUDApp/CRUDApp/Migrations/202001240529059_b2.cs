namespace CRUDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CrudOperations", newName: "Employees");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Employees", newName: "CrudOperations");
        }
    }
}
