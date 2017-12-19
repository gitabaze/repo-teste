namespace Models
{
   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WebApiQUizz.Service;

    [Table("Matiere")]
    public partial class Matiere : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matiere()
        {
            //Questionnaire = new HashSet<Questionnaire>();
        }

        //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        [Required(ErrorMessage = "Le champ  matiere est un champs requis !")]
        [StringLength(50)]
        [Display(Name = "Matiere")]
        public string Libelle { get; set; }

        [Display(Name = "Niveau")]
        [Range(1, 10000)]
        [Required(ErrorMessage = "Le champ niveau est un champs requis !")]
        public int NiveauID { get; set; }
        public virtual Niveau Niveau { get; set; }
        
      
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Questionnaire> Questionnaire { get; set; }
    }
}
