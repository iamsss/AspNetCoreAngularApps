using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resource;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{


    [Route("api/[controller]")]
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
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
        public async Task<IEnumerable<MakeResource>> GetAll()
        {
           var makes = await context.Makes.Include(m => m.Models).ToListAsync();

           return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

    }
}