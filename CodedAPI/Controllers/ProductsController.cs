using CodedAPI.Data;
using CodedAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private ApplicationDbContext db;
        public ProductsController(ApplicationDbContext _db)
        {
           db = _db;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product model) 
        {
            if (ModelState.IsValid) 
            {
              db.Products.Add(model);
              await  db.SaveChangesAsync();
                return NoContent();
            }
            return Ok("Invalid");
        }



        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() 
        {
            return Ok(await db.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int? id) 
        {
            if (id==null)
            {
                return NotFound();
            }
            var data=db.Products.FindAsync(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int? id,Product product)
        {
           
            var data = db.Products.FindAsync(id);
            return Ok(data);
        }

    }
}
