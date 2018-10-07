using System;
using System.Collections.Generic;

namespace MasterDetailReact.Models.DB
{
    public partial class AssetLocations
    {
        public int Id { get; set; }
        public int? LocationId { get; set; }
        public int? AssetId { get; set; }
        public DateTime? LastSeen { get; set; }

        public Assets Asset { get; set; }
        public AssetLocation Location { get; set; }
    }
}
