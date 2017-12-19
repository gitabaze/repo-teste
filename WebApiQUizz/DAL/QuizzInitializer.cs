using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class QuizzInitializer : System.Data.Entity.CreateDatabaseIfNotExists<QuizzContext>
    {
        protected override void Seed(QuizzContext context)
        {
            var profiles = new List<Profile>
            {
                new Profile { Libelle="Administrateur" },
                  new Profile { Libelle="SUperAdmin" },
                    new Profile { Libelle="Utilisateur" },
            };


            //profiles.ForEach(p => context.Profiles.Add(p));
            //context.SaveChanges();

            base.Seed(context);
        }
    }

    //enable-migrations
    //Add-Migration AddBlogUrl
    // Update-Database -verbose
    //Update-Database –TargetMigration: AddBlogUrl 
}