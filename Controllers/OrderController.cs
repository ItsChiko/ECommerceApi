using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly LiteDbContext _db;

    public OrderController(LiteDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetAll() => Ok(_db.Orders.FindAll());

    [HttpGet("{id}")]
    public ActionResult<Order> Get(Guid id)
    {
        var order = _db.Orders.FindById(id);
        if (order == null) return NotFound();
        return Ok(order);
    }

    [HttpPost]
    public ActionResult<Order> Create(Order order)
    {
        _db.Orders.Insert(order);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Order updatedOrder)
    {
        if (id != updatedOrder.Id) return BadRequest();
        if (!_db.Orders.Update(updatedOrder)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        if (!_db.Orders.Delete(id)) return NotFound();
        return NoContent();
    }
}
