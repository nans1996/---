namespace CompStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Patronymic", c => c.String());
            AddColumn("dbo.AspNetUsers", "n_per_file", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Salary");
            DropColumn("dbo.AspNetUsers", "n_per_file");
            DropColumn("dbo.AspNetUsers", "Patronymic");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
