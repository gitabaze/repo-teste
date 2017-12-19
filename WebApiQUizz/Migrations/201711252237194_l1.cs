namespace WebApiQUizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 100),
                        Titre = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.ContenuPublication",
                c => new
                    {
                        PaysID = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false, maxLength: 50),
                        Libelle = c.String(),
                        LienPhoto = c.String(maxLength: 50),
                        EstActif = c.Boolean(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        TypePublicationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaysID)
                .ForeignKey("dbo.TypePublication", t => t.TypePublicationID, cascadeDelete: true)
                .Index(t => t.TypePublicationID);
            
            CreateTable(
                "dbo.TypePublication",
                c => new
                    {
                        TypePublicationID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TypePublicationID);
            
            CreateTable(
                "dbo.Langue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sigle = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContenuPublication", "TypePublicationID", "dbo.TypePublication");
            DropIndex("dbo.ContenuPublication", new[] { "TypePublicationID" });
            DropTable("dbo.Langue");
            DropTable("dbo.TypePublication");
            DropTable("dbo.ContenuPublication");
            DropTable("dbo.Contact");
        }
    }
}
