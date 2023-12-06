namespace DBAutoLotDaL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CustId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CarId", "dbo.Inventory");
            RenameColumn(table: "dbo.Orders", name: "CustId", newName: "CustomerId");
            RenameIndex(table: "dbo.Orders", name: "IX_CustId", newName: "IX_CustomerId");
            DropPrimaryKey("dbo.CreditsRisks");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Inventory");
            DropColumn("dbo.CreditsRisks", "CustId");
            DropColumn("dbo.Customers", "CustID");
            DropColumn("dbo.Orders", "OrderId");
            DropColumn("dbo.Inventory", "CarId");
            AddColumn("dbo.CreditsRisks", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditsRisks", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Inventory", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Inventory", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddPrimaryKey("dbo.CreditsRisks", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            AddPrimaryKey("dbo.Inventory", "Id");
            CreateIndex("dbo.CreditsRisks", new[] { "LastName", "FirstName" }, unique: true, name: "IDX_CreditsRisks_Name");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CarId", "dbo.Inventory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarId", "dbo.Inventory");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropPrimaryKey("dbo.Inventory");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.CreditsRisks");
            DropColumn("dbo.CreditsRisks", "Id");
            DropColumn("dbo.Inventory", "Id");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.Customers", "Id");
            AddColumn("dbo.Inventory", "CarId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "CustID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditsRisks", "CustId", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.CreditsRisks", "IDX_CreditsRisks_Name");
            DropColumn("dbo.Inventory", "Timestamp");
            DropColumn("dbo.Orders", "Timestamp");
            DropColumn("dbo.Customers", "Timestamp");
            DropColumn("dbo.CreditsRisks", "Timestamp");
            AddPrimaryKey("dbo.Inventory", "CarId");
            AddPrimaryKey("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.Customers", "CustID");
            AddPrimaryKey("dbo.CreditsRisks", "CustId");
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerId", newName: "IX_CustId");
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "CustId");
            AddForeignKey("dbo.Orders", "CarId", "dbo.Inventory", "CarId");
            AddForeignKey("dbo.Orders", "CustId", "dbo.Customers", "CustID", cascadeDelete: true);
        }
    }
}
