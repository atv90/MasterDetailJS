using System;
using System.Collections.Generic;

namespace MasterDetailReact.Models.DB
{
    public partial class AssetLocation
    {
        public AssetLocation()
        {
            AssetLocations = new HashSet<AssetLocations>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<AssetLocations> AssetLocations { get; set; }
    }
}
