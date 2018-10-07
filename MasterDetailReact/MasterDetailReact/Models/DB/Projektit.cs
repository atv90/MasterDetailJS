using System;
using System.Collections.Generic;

namespace MasterDetailReact.Models.DB
{
    public partial class Projektit
    {
        public int ProjektiId { get; set; }
        public string Nimi { get; set; }
        public int? Status { get; set; }
    }
}
