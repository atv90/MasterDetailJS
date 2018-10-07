using System;
using System.Collections.Generic;

namespace MasterDetailReact.Models.DB
{
    public partial class Assets
    {
        public Assets()
        {
            AssetLocations = new HashSet<AssetLocations>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        public ICollection<AssetLocations> AssetLocations { get; set; }
    }
}
