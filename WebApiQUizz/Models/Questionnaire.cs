namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Questionnaire")]
    public partial class Questionnaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questionnaire()
        {
            Jeux = new HashSet<Jeux>();
            Reponses = new HashSet<Reponses>();
        }

        public int QuestionnaireID { get; set; }

        [Required]
        [StringLength(100)]
        public string Libelle { get; set; }

        public int ModuleID { get; set; }

        public int MatiereID { get; set; }

        [StringLength(200)]
        public string   PhotoUrl { get; set; }
        [StringLength(50)]
        public string PhotoExtension { get; set; }
        [StringLength(100)]
        public string PhotoFileName { get; set; }
       
        public Nullable<DateTime> DateDebut { get; set; }

        public Nullable<DateTime> DateFin { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }

        public Nullable<DateTime> DateMiseAJour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jeux> Jeux { get; set; }

        public virtual Matiere Matiere { get; set; }

        public virtual Module Module { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reponses> Reponses { get; set; }
    }
}
