using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class ChapitreViewModel
    {
        public int ChapitreID { get; set; }
        [Required(ErrorMessage ="lenom du chapitre est un champ requis")]
        [StringLength(50)]
        [Display(Name = "Chapitre")]
        public string Libelle { get; set; }
        [Required(ErrorMessage = "La langue est un champ requis")]
        [Display(Name = "Langue")]
        [Range(1, 10000)]
        public int LangueID { get; set; }
        [Display(Name = "Niveau")]
        [Required(ErrorMessage = "Le niveau est un champ requis")]
        [Range(1, 10000)]
        public int NiveauID { get; set; }
        [Required(ErrorMessage = "la matiere est un champ requis")]
        [Display(Name = "Matière")]
        [Range(1,10000)]
        public int MatiereID { get; set; }
    }
}