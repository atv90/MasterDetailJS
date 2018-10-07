using System;
using System.Collections.Generic;

namespace MasterDetailReact.Models.DB
{
    public partial class Tunnit
    {
        public int TuntiId { get; set; }
        public DateTime? Pvm { get; set; }
        public decimal? Tunnit1 { get; set; }
        public int? ProjektiId { get; set; }
        public int? HenkiloId { get; set; }
    }
}
