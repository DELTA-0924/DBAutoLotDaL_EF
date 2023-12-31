﻿namespace DBAutoLotDaL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditsRisks",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CustId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CustID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustId, cascadeDelete: true)
                .ForeignKey("dbo.Inventory", t => t.CarId)
                .Index(t => t.CustId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Model = c.String(maxLength: 50),
                        Color = c.String(maxLength: 50),
                        PetName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarId", "dbo.Inventory");
            DropForeignKey("dbo.Orders", "CustId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CarId" });
            DropIndex("dbo.Orders", new[] { "CustId" });
            DropTable("dbo.Inventory");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditsRisks");
        }
    }
}
