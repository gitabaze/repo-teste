using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Models
{
    public class QuizzContext : DbContext
    {
        public QuizzContext()
            : base("name=DefaultConnection")
        {
        }
        public virtual DbSet<Langue> Langues { get; set; }
        public virtual DbSet<Niveau> Niveaus { get; set; }
        public virtual DbSet<Matiere> Matieres { get; set; }
        public virtual DbSet<Chapitre> Chapitres { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        //public virtual DbSet<Jeux> Jeuxs { get; set; }
        //public virtual DbSet<Questionnaire> Questionnaires { get; set; }
        //public virtual DbSet<Reponses> Reponses { get; set; }

        //public virtual DbSet<Profile> Profiles { get; set; }
        //public virtual DbSet<Pays> Pays { get; set; }
        //public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        //public virtual DbSet<TypePublication> TypePublications { get; set; }
        //public virtual DbSet<ContenuPublication> ContenuPublications { get; set; }

        //public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

           

            modelBuilder.Entity<Langue>()
                .Property(e => e.Libelle)
                .IsUnicode(false);
            modelBuilder.Entity<Langue>()
            .Property(e => e.Sigle)
            .IsUnicode(false);

            modelBuilder.Entity<Chapitre>()
               .Property(e => e.Libelle)
               .IsUnicode(false);

            //modelBuilder.Entity<Chapitre>()
            //    .HasMany(e => e.Module)
            //    .WithRequired(e => e.Chapitre)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matiere>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
             .Property(e => e.Libelle)
             .IsUnicode(false);

            //  modelBuilder.Entity<Module>()
            //      .HasMany(e => e.Questionnaire)
            //      .WithRequired(e => e.Module)
            //      .WillCascadeOnDelete(false);

            modelBuilder.Entity<Niveau>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Niveau>()
                .HasMany(e => e.Matiere)
                .WithRequired(e => e.Niveau)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Matiere>()
            //    .HasMany(e => e.Questionnaire)
            //    .WithRequired(e => e.Matiere)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<TypePublication>()
            //    .Property(e => e.Libelle)
            //    .IsUnicode(false);



            //  modelBuilder.Entity<Pays>()
            //    .Property(e => e.Libelle)
            //    .IsUnicode(false);

            //  modelBuilder.Entity<Contact>()
            // .Property(e => e.Email)
            // .IsUnicode(false);


            //  modelBuilder.Entity<Contact>()
            // .Property(e => e.Message)
            // .IsUnicode(false);


            //  modelBuilder.Entity<Contact>()
            // .Property(e => e.Titre)
            // .IsUnicode(false);





            //  modelBuilder.Entity<Profile>()
            //      .Property(e => e.Libelle)
            //      .IsUnicode(false);


            //  modelBuilder.Entity<Questionnaire>()
            //      .Property(e => e.Libelle)
            //      .IsUnicode(false);


            //  modelBuilder.Entity<Questionnaire>()
            //      .Property(e => e.PhotoUrl)
            //      .IsUnicode(false);


            //  modelBuilder.Entity<Questionnaire>()
            //      .Property(e => e.PhotoFileName)
            //      .IsUnicode(false);

            //  modelBuilder.Entity<Questionnaire>()
            //      .Property(e => e.PhotoExtension)
            //      .IsUnicode(false);



            //  modelBuilder.Entity<Questionnaire>()
            //      .HasMany(e => e.Jeux)
            //      .WithRequired(e => e.Questionnaire)
            //      .HasForeignKey(e => e.QuestionaireID)
            //      .WillCascadeOnDelete(false);

            //  modelBuilder.Entity<Questionnaire>()
            //      .HasMany(e => e.Reponses)
            //      .WithRequired(e => e.Questionnaire)
            //      .WillCascadeOnDelete(false);

            //  modelBuilder.Entity<Reponses>()
            //      .Property(e => e.Libelle)
            //      .IsUnicode(false);

            //  modelBuilder.Entity<Reponses>()
            //      .HasMany(e => e.Jeux)
            //      .WithRequired(e => e.Reponses)
            //      .WillCascadeOnDelete(false);

            //  modelBuilder.Entity<Utilisateur>()
            //      .Property(e => e.Nom)
            //      .IsUnicode(false);

            //  modelBuilder.Entity<Utilisateur>()
            //      .Property(e => e.MotdePasse)
            //      .IsUnicode(false);
            //  modelBuilder.Entity<Utilisateur>()
            //    .Property(e => e.Nom)
            //    .IsUnicode(false);
            //  modelBuilder.Entity<Utilisateur>()
            //    .Property(e => e.Prenom)
            //    .IsUnicode(false);
            //  modelBuilder.Entity<Utilisateur>()
            //    .Property(e => e.Email)
            //    .IsUnicode(false);

            //  modelBuilder.Entity<Utilisateur>()
            //    .Property(e => e.Region)
            //    .IsUnicode(false);

            //  modelBuilder.Entity<Utilisateur>()
            //    .Ignore(e => e.ConfirmPassword)
            //   ;

            //  modelBuilder.Entity<Utilisateur>()
            //      .HasMany(e => e.Jeux)
            //      .WithRequired(e => e.Utilisateur)
            //      .WillCascadeOnDelete(false);

            //  modelBuilder.Entity<ContenuPublication>()
            //   .Property(e => e.Libelle)
            //   .IsUnicode(false);

            //  modelBuilder.Entity<ContenuPublication>()
            //.Property(e => e.Titre)
            //.IsUnicode(false);
            //  modelBuilder.Entity<ContenuPublication>()
            //.Property(e => e.LienPhoto)
            //.IsUnicode(false);
        }
    }
}