using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreMVC.Models.EFCore;

namespace NetCoreMVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EFCoreContext _context;

        public ProductsController(EFCoreContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetProducts1()
        {
            return _context.Products.ToList();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Products> GetProducts(int id)
        {
            var products = _context.Products.Find(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        //// POST: api/Products
        [HttpPost]
        public ActionResult UpdateProducts()
        {
            try {
                var ID = Convert.ToInt32(Request.Form["ID"].ToString());
                var Price = Convert.ToInt32(Request.Form["Price"].ToString());
                var products = _context.Products.Find(ID);
                products.Price = Price;
                _context.SaveChanges();
                return Ok();
            }
            catch (DbUpdateConcurrencyException) {
                //if (!ProductsExists(id)) {
                //    return NotFound();
                //}
                //else {
                //    throw;
                //}
                return BadRequest();
            }

            return NoContent();
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
