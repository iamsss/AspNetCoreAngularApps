using System.ComponentModel.DataAnnotations;

namespace vega.Controllers.Resource
{
    public class ContactResource
    {
       [Required]
       public string ContactName { get; set; }
       public string ContactEmail { get; set; }
       public string ContactPhone { get; set; }
    }
}