namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class Profile
    {
       
        public Profile()
        {
           // Utilisateur = new HashSet<Utilisateur>();
        }
        [Key]
        public int ProfileID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "Libelle")]
        public string Libelle { get; set; }

      
    }
}
