using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{


    [Route("api/[controller]")]
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        public MakesController(VegaDbContext context)
        {
            this.context = context;

        }

        [HttpGet("{id}", Name = "GetMakes")]
        public IActionResult GetById(int id)
        {
            var item = context.Makes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        public List<Make> GetAll()
        {
            return context.Makes.ToList();
        }

    }
}