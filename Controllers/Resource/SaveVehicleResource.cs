using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using vega.Models;

namespace vega.Controllers.Resource
{

    public class SaveVehicleResource
    {
       public int Id { get; set; }
       public int ModelId { get; set; }
       public bool IsRegistered { get; set; }

       [Required]
       public ContactResource contact { get; set; }
      
        public ICollection<int> Features { get; set; }

        public SaveVehicleResource()
        {
            Features = new Collection<int>();
        }
    }
} 