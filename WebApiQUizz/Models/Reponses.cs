namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reponses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reponses()
        {
            Jeux = new HashSet<Jeux>();
        }

        [Key]
        public int ReponseID { get; set; }

        [Required]
        [StringLength(100)]
        public string Libelle { get; set; }

        public int QuestionnaireID { get; set; }

        public bool EstVrai { get; set; }

        public double Point { get; set; }

        [Required]
        public byte[] Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jeux> Jeux { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
    }
}
