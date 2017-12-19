using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class ChapitreDisplay
    {
        public int ChapitreID { get; set; }
        public string Libelle { get; set; }
        public string NiveauLibelle { get; set; }
        public string LangueLibelle { get; set; }
        public string MatiereLibelle { get; set; }

        public int MatiereID { get; set; }
        public int NiveauID { get; set; }
        public int LangueID { get; set; }
    }
}