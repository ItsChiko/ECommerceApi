using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly LiteDbContext _db;

    public CategoryController(LiteDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> GetAll() => Ok(_db.Categories.FindAll());

    [HttpGet("{id}")]
    public ActionResult<Category> Get(Guid id)
    {
        var category = _db.Categories.FindById(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public ActionResult<Category> Create(Category category)
    {
        _db.Categories.Insert(category);
        return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Category updatedCategory)
    {
        if (id != updatedCategory.Id) return BadRequest();
        if (!_db.Categories.Update(updatedCategory)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        if (!_db.Categories.Delete(id)) return NotFound();
        return NoContent();
    }
}
