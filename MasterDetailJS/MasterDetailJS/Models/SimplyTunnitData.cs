using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDetailJS.Models
{
    public class SimplyTunnitData
    {
        public int TuntiId { get; set; }
        public int HenkiloId { get; set; }
        public int ProjektiId { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:HH\\:mm}", ApplyFormatInEditMode = true)]
        public string Pvm { get; set; }
        public double Tunnit1 { get; set; }
        public string ProjektiNimi { get; set; }
    
    }
}