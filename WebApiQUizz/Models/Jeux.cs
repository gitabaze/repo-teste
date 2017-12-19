namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jeux")]
    public partial class Jeux
    {
        public int JeuxID { get; set; }

        public int QuestionaireID { get; set; }

        public int ReponseID { get; set; }

        public bool EstResultat { get; set; }

        public double Point { get; set; }
     

        public int UtilisateurID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateJeux { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateMiseAjour { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }

        public virtual Reponses Reponses { get; set; }

        public virtual Utilisateur Utilisateur { get; set; }
    }
}
