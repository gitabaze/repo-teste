using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiQUizz.Models
{
    public class Token
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string key { get; set; }
        public string IssueOn { get; set; }
        public string ExpireOn { get; set; }
        public string CreateOn { get; set; }

    }
}