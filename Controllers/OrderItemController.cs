using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController : ControllerBase
{
    private readonly LiteDbContext _db;

    public OrderItemController(LiteDbContext db)
    {
        _db = db;
    }

    [HttpGet("{orderId}")]
    public ActionResult<IEnumerable<OrderItem>> GetAll(Guid orderId)
    {
        var order = _db.Orders.FindById(orderId);
        if (order == null) return NotFound();
        return Ok(order.Items);
    }

    [HttpPost("{orderId}")]
    public IActionResult AddItem(Guid orderId, OrderItem item)
    {
        var order = _db.Orders.FindById(orderId);
        if (order == null) return NotFound();

        order.Items.Add(item);
        _db.Orders.Update(order);
        return NoContent();
    }

    [HttpDelete("{orderId}/{productId}")]
    public IActionResult DeleteItem(Guid orderId, Guid productId)
    {
        var order = _db.Orders.FindById(orderId);
        if (order == null) return NotFound();

        var item = order.Items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null) return NotFound();

        order.Items.Remove(item);
        _db.Orders.Update(order);
        return NoContent();
    }
}
