namespace WebApiQUizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chapitre", "LangueID", "dbo.Langue");
            DropForeignKey("dbo.Matiere", "LangueID", "dbo.Langue");
            DropForeignKey("dbo.Module", "LangueID", "dbo.Langue");
            DropIndex("dbo.Chapitre", new[] { "LangueID" });
            DropIndex("dbo.Matiere", new[] { "LangueID" });
            DropIndex("dbo.Module", new[] { "LangueID" });
            DropColumn("dbo.Chapitre", "LangueID");
            DropColumn("dbo.Matiere", "LangueID");
            DropColumn("dbo.Module", "LangueID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Module", "LangueID", c => c.Int(nullable: false));
            AddColumn("dbo.Matiere", "LangueID", c => c.Int(nullable: false));
            AddColumn("dbo.Chapitre", "LangueID", c => c.Int(nullable: false));
            CreateIndex("dbo.Module", "LangueID");
            CreateIndex("dbo.Matiere", "LangueID");
            CreateIndex("dbo.Chapitre", "LangueID");
            AddForeignKey("dbo.Module", "LangueID", "dbo.Langue", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matiere", "LangueID", "dbo.Langue", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Chapitre", "LangueID", "dbo.Langue", "Id", cascadeDelete: true);
        }
    }
}
