using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Fonction
    {
        [Key]
        public int FonctionID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "La loguer ne doit pas exceder 50 caracteres")]
        [Display(Name = "Libelle")]
        public string Libelle { get; set; }
    }
}