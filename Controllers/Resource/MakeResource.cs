using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Controllers.Resource
{
    public class MakeResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Models { get; set;}

        public MakeResource() {
        Models = new Collection<KeyValuePairResource>(); // Here we can use List as well as Collection
    }

    }
}