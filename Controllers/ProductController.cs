using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly LiteDbContext _db;

    public ProductController(LiteDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll() => Ok(_db.Products.FindAll());

    [HttpGet("{id}")]
    public ActionResult<Product> Get(Guid id)
    {
        var product = _db.Products.FindById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        _db.Products.Insert(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Product updatedProduct)
    {
        if (id != updatedProduct.Id) return BadRequest();
        if (!_db.Products.Update(updatedProduct)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        if (!_db.Products.Delete(id)) return NotFound();
        return NoContent();
    }
}
