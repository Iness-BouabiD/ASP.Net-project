using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationadmin2.Models
{
    public class Eleve
    {
        public int ID_Eleve { get; set; }
        public string CNE { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string Tel { get; set; }
    }
}