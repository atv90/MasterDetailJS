using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetailJS.Models
{
    public class SimplyHenkilotData
    {
        public SimplyHenkilotData()
        {
            this.Tunnit = new HashSet<Tunnit>();
        }

        public int Henkilo_id { get; set; }
        public string Osoite { get; set; }
        public int? Esimies { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }

        public virtual ICollection<Tunnit> Tunnit { get; set; }
    }
}