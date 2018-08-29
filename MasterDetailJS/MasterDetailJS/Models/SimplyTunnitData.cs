using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDetailJS.Models
{
    public class SimplyTunnitData
    {
        public int Tunti_id { get; set; }
        public int Henkilo_id { get; set; }
        public int Projekti_id { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:HH\\:mm}", ApplyFormatInEditMode = true)]
        public string Pvm { get; set; }
        public double Projekti_tunnit { get; set; }
        public string ProjektiNimi { get; set; }
    
    }
}