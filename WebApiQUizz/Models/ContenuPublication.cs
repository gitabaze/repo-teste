using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class ContenuPublication
    {
        [Key]
        public int PaysID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Titre")]
        public string Titre { get; set; }
        [Display(Name = "Libelle")]
        public string Libelle { get; set; }
        [StringLength(50)]
        public string LienPhoto { get; set; }
        public bool  EstActif { get; set; }
        public DateTime  DateCreation { get; set; }
        public int TypePublicationID { get; set; }
        public virtual TypePublication TypePublication { get; set; }
        
    }
}