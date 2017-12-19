namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WebApiQUizz.Service;

    [Table("Module")]
    public partial class Module : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Module()
        {
           // Questionnaire = new HashSet<Questionnaire>();
        }

        public int ModuleID { get; set; }

        [Required(ErrorMessage = "Le champ Libelle Module est un champ requis")]
        [StringLength(50)]
        [Display(Name ="Module")]
        public string Libelle { get; set; }

        [Display(Name = "Chapitre")]
        [Required]
        [Range(1,1000,ErrorMessage ="Le champ chapitre est un champ requis !")]
        public int ChapitreID { get; set; }
        public virtual Chapitre Chapitre { get; set; }

      

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Questionnaire> Questionnaire { get; set; }
    }
}
