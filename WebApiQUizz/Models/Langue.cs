namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WebApiQUizz.Service;

    public partial class Langue : BaseEntity
    {
      
        public Langue()
        {
           
        }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [Required]
        [StringLength(10)]
        public string Sigle { get; set; }
       
      
    }
}
