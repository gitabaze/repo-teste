using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Pays
    {
        public Pays()
        {
            
        }
        [Key]
        public int PaysID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "Libelle")]
        public string Libelle { get; set; }
    }
}