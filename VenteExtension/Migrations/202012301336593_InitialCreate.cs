namespace VenteExtension.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        clientID = c.Int(nullable: false, identity: true),
                        nomCl = c.String(),
                        prenomCl = c.String(),
                        tel = c.String(),
                        mail = c.String(),
                    })
                .PrimaryKey(t => t.clientID);
            
            CreateTable(
                "dbo.Commande",
                c => new
                    {
                        commandeID = c.Int(nullable: false, identity: true),
                        produitID = c.Int(nullable: false),
                        clientID = c.Int(nullable: false),
                        quantCom = c.Int(nullable: false),
                        prixTot = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dateCom = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.commandeID)
                .ForeignKey("dbo.Client", t => t.clientID, cascadeDelete: true)
                .ForeignKey("dbo.Produit", t => t.produitID, cascadeDelete: true)
                .Index(t => t.produitID)
                .Index(t => t.clientID);
            
            CreateTable(
                "dbo.Produit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomExt = c.String(),
                        Prix_u = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commande", "produitID", "dbo.Produit");
            DropForeignKey("dbo.Commande", "clientID", "dbo.Client");
            DropIndex("dbo.Commande", new[] { "clientID" });
            DropIndex("dbo.Commande", new[] { "produitID" });
            DropTable("dbo.Produit");
            DropTable("dbo.Commande");
            DropTable("dbo.Client");
        }
    }
}
