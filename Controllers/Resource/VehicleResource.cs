using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Controllers.Resource
{
    public class VehicleResource
    {
       public int Id { get; set; }
       public bool IsRegistered { get; set; }

        public KeyValuePairResource Model { get; set; }
        
        public MakeResource Make { get; set; }
        public ContactResource contact { get; set; }
      
        public DateTime LastUpdate { get; set; }
        public ICollection<KeyValuePairResource> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<KeyValuePairResource>();
        }
    }
}