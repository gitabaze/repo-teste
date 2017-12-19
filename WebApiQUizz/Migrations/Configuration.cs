namespace WebApiQUizz.Migrations
{
    using global::Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuizzContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuizzContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Langues.AddOrUpdate(
              new Langue {Id=1, Libelle="Fransai ", Sigle ="Fr-fr" },
              new Langue { Id = 2, Libelle = "Anglais", Sigle = "En-en" },
             new Langue { Id = 3, Libelle = "Allema,de", Sigle = "AL-al" }
            );
            context.SaveChanges();

            context.Niveaus.AddOrUpdate(
           new Niveau { Id = 1, Libelle = "Maetrnelle ", LangueID=1 },
           new Niveau { Id = 2, Libelle = "Secondaire premier sicle", LangueID=1 },
           new Niveau { Id = 3, Libelle = "Terminale", LangueID=1 },
           new Niveau { Id = 4, Libelle = "Nursery", LangueID = 2 }
         );
            context.SaveChanges();

        }
    }
}
