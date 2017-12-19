namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class Utilisateur    {
        public Utilisateur()
        {
            //Jeux = new HashSet<Jeux>();
        }

        public int UtilisateurID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [MaxLength(50)]
        public string  Prenom { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Ton Pseudo")]
        public string Login { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string MotdePasse { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public DateTime DateNaissance { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Region")]
        public string Region { get; set; }
        [Required]
        [Display(Name = "Sexe")]
        public bool Sexe { get; set; }

        public int PaysID { get; set; }
        public int ProfileID { get; set; }

      
        public virtual ICollection<Jeux> Jeux { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual Pays Pays { get; set; }
    }
}
