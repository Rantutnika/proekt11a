namespace proekt22.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourierContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parcels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Number = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        ParcelTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParcelTypes", t => t.ParcelTypeId, cascadeDelete: true)
                .Index(t => t.ParcelTypeId);
            
            CreateTable(
                "dbo.ParcelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parcels", "ParcelTypeId", "dbo.ParcelTypes");
            DropIndex("dbo.Parcels", new[] { "ParcelTypeId" });
            DropTable("dbo.ParcelTypes");
            DropTable("dbo.Parcels");
        }
    }
}
