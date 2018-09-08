using System.Threading.Tasks;
using CoreOdata.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;

namespace CoreOdata.Controllers
{
    public class ItemsController : ODataController
    {
        private readonly MyContext _context;

        public ItemsController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(ODataQueryOptions<Item> options)
        {
            var results = options.ApplyTo(_context.Items);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            _context.Add(item);
            _context.SaveChanges();

            return Created(item);
        }

        [HttpPut]
        [Route("api/items/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Item entity)
        {
            var original = _context.Items.Find(id);
            _context.Entry(original).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return Ok();
        }
    }
}