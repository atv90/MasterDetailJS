using System;
using System.Collections.Generic;

namespace MasterDetailReact.Models.DB
{
    public partial class HenkilotPaiva2
    {
        public int HenkiloId { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Osoite { get; set; }
        public int? Esimies { get; set; }
    }
}
