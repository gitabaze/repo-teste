namespace Models
{
  
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WebApiQUizz.Service;

    [Table("Chapitre")]
    public partial class Chapitre : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chapitre()
        {
           // Module = new HashSet<Module>();
        }



        [Required(ErrorMessage = "Le champ chapitre est un champs requis !")]
        [StringLength(50)]
        [Display(Name = "Chapitre")]
        public string Libelle { get; set; }

        [Display(Name = "Matiere")]
        [Range(1, 10000)]
        [Required(ErrorMessage = "Le champ matiere est un champs requis !")]
        public int MatiereID { get; set; }
        public virtual Matiere Matiere { get; set; }

       

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Module> Module { get; set; }
    }
}
