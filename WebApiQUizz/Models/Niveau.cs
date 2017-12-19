namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 
    using WebApiQUizz.Service;

    [Table("Niveau")]
    public partial class Niveau : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Niveau()
        {
            Matiere = new HashSet<Matiere>();
        }

       

        [Required(ErrorMessage = "Le libelle niveau est un champs requis")]
        [StringLength(50)]
        public string Libelle { get; set; }

        [Display(Name = "Langue")]
        [Required(ErrorMessage = "Le champ langue est un champs requis !")]
        [Range(1, 1000, ErrorMessage = "Le champ Langue est un champ requis !")]
        public int LangueID { get; set; }

        public virtual Langue Langue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matiere> Matiere { get; set; }
    }
}
