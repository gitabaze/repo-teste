using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
       
        [StringLength(150, ErrorMessage = "La logueur ne doit pas exceder 150 caracteres")]
        [Display(Name = "Nom")]
        [Required]
        public string Nom { get; set; }

        [Display(Name = "Pre Nom")]
        [Required]
        [StringLength(150, ErrorMessage = "La longueur ne doit pas exceder 150 caracteres")]
        public string Prenom { get; set; }

        [Display(Name = "Adresse")]
        [Required]
        [StringLength(200, ErrorMessage = "La longueur ne doit pas exceder 200 caracteres")]
        public string Adresse { get; set; }

        [Display(Name = "Telephone")]
        [Required]
        [StringLength(100, ErrorMessage = "La longueur ne doit pas exceder 100 caracteres")]
        public string Telephone { get; set; }

        [Display(Name = "Mobile")]
       
        [StringLength(100, ErrorMessage = "La longueur ne doit pas exceder 50 caracteres")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "La longueur ne doit pas exceder 100 caracteres")]
        public string Email { get; set; }

        [Display(Name = "SiteWeb")]
        [Required]
        [StringLength(200, ErrorMessage = "La longueur ne doit pas exceder 50 caracteres")]
        public string SiteWeb { get; set; }

        [Display(Name = "Adresse")]
        [Required]
        [StringLength(100, ErrorMessage = "La longueur ne doit pas exceder 50 caracteres")]
        public string Login { get; set; }

        [Display(Name = "MotPasse")]
        [Required]
        [StringLength(100, ErrorMessage = "La longueur ne doit pas exceder 50 caracteres")]
        public string MotPasse { get; set; }

        [Display(Name = "Compte Actif")]
        [Required]
        public bool EstActif { get; set; }
    }
}