namespace WebApiQUizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContenuPublication", "TypePublicationID", "dbo.TypePublication");
            DropIndex("dbo.ContenuPublication", new[] { "TypePublicationID" });
            CreateTable(
                "dbo.Chapitre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatiereID = c.Int(nullable: false),
                        LangueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Langue", t => t.LangueID, cascadeDelete: true)
                .ForeignKey("dbo.Matiere", t => t.MatiereID, cascadeDelete: true)
                .Index(t => t.MatiereID)
                .Index(t => t.LangueID);
            
            CreateTable(
                "dbo.Matiere",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false, maxLength: 50, unicode: false),
                        NiveauID = c.Int(nullable: false),
                        LangueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Langue", t => t.LangueID, cascadeDelete: false)
                .ForeignKey("dbo.Niveau", t => t.NiveauID)
                .Index(t => t.NiveauID)
                .Index(t => t.LangueID);
            
            CreateTable(
                "dbo.Niveau",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false, maxLength: 50, unicode: false),
                        LangueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Langue", t => t.LangueID, cascadeDelete: false)
                .Index(t => t.LangueID);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleID = c.Int(nullable: false),
                        Libelle = c.String(nullable: false, maxLength: 50, unicode: false),
                        ChapitreID = c.Int(nullable: false),
                        LangueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chapitre", t => t.ChapitreID, cascadeDelete: true)
                .ForeignKey("dbo.Langue", t => t.LangueID, cascadeDelete: false)
                .Index(t => t.ChapitreID)
                .Index(t => t.LangueID);
            
            DropTable("dbo.Contact");
            DropTable("dbo.ContenuPublication");
            DropTable("dbo.TypePublication");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TypePublication",
                c => new
                    {
                        TypePublicationID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TypePublicationID);
            
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
                .PrimaryKey(t => t.PaysID);
            
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
            
            DropForeignKey("dbo.Module", "LangueID", "dbo.Langue");
            DropForeignKey("dbo.Module", "ChapitreID", "dbo.Chapitre");
            DropForeignKey("dbo.Chapitre", "MatiereID", "dbo.Matiere");
            DropForeignKey("dbo.Matiere", "NiveauID", "dbo.Niveau");
            DropForeignKey("dbo.Niveau", "LangueID", "dbo.Langue");
            DropForeignKey("dbo.Matiere", "LangueID", "dbo.Langue");
            DropForeignKey("dbo.Chapitre", "LangueID", "dbo.Langue");
            DropIndex("dbo.Module", new[] { "LangueID" });
            DropIndex("dbo.Module", new[] { "ChapitreID" });
            DropIndex("dbo.Niveau", new[] { "LangueID" });
            DropIndex("dbo.Matiere", new[] { "LangueID" });
            DropIndex("dbo.Matiere", new[] { "NiveauID" });
            DropIndex("dbo.Chapitre", new[] { "LangueID" });
            DropIndex("dbo.Chapitre", new[] { "MatiereID" });
            DropTable("dbo.Module");
            DropTable("dbo.Niveau");
            DropTable("dbo.Matiere");
            DropTable("dbo.Chapitre");
            CreateIndex("dbo.ContenuPublication", "TypePublicationID");
            AddForeignKey("dbo.ContenuPublication", "TypePublicationID", "dbo.TypePublication", "TypePublicationID", cascadeDelete: true);
        }
    }
}
