using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly LiteDbContext _db;

    public CustomerController(LiteDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetAll() => Ok(_db.Customers.FindAll());

    [HttpGet("{id}")]
    public ActionResult<Customer> Get(Guid id)
    {
        var customer = _db.Customers.FindById(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public ActionResult<Customer> Create(Customer customer)
    {
        _db.Customers.Insert(customer);
        return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Customer updatedCustomer)
    {
        if (id != updatedCustomer.Id) return BadRequest();
        if (!_db.Customers.Update(updatedCustomer)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        if (!_db.Customers.Delete(id)) return NotFound();
        return NoContent();
    }
}
