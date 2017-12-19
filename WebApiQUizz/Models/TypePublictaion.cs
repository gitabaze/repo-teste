using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class TypePublication
    {
        [Key]
        public int TypePublicationID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Libelle")]
        public string Libelle { get; set; }

       
    }
}