using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "La longueur ne doit pas exceder 50 caracteres")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La longueur ne doit pas exceder 50 caracteres")]
        [Display(Name = "Titre")]
        public string Titre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La longueur ne doit pas exceder 50 caracteres")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}