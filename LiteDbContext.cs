using LiteDB;

public class LiteDbContext
{
    private readonly LiteDatabase _database;

    public LiteDbContext(string databasePath)
    {
        _database = new LiteDatabase(databasePath);

        // Collections
        Customers = _database.GetCollection<Customer>("Customers");
        Products = _database.GetCollection<Product>("Products");
        Categories = _database.GetCollection<Category>("Categories");
        Orders = _database.GetCollection<Order>("Orders");

        // Seed data
        SeedData();
    }

    public ILiteCollection<Customer> Customers { get; }
    public ILiteCollection<Product> Products { get; }
    public ILiteCollection<Category> Categories { get; }
    public ILiteCollection<Order> Orders { get; }

    private void SeedData()
    {
        // Seed Customers
        if (Customers.Count() == 0)
        {
            Customers.Insert(new Customer { Id = Guid.NewGuid(), Name = "John Doe", Email = "john@example.com" });
            Customers.Insert(new Customer { Id = Guid.NewGuid(), Name = "Jane Smith", Email = "jane@example.com" });
        }

        // Seed Categories
        if (Categories.Count() == 0)
        {
            var electronicsId = Guid.NewGuid();
            var clothingId = Guid.NewGuid();

            Categories.Insert(new Category { Id = electronicsId, Name = "Electronics" });
            Categories.Insert(new Category { Id = clothingId, Name = "Clothing" });

            // Seed Products
            if (Products.Count() == 0)
            {
                Products.Insert(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone",
                    Price = 699.99M,
                    CategoryId = electronicsId
                });
                Products.Insert(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop",
                    Price = 1199.99M,
                    CategoryId = electronicsId
                });
                Products.Insert(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "T-shirt",
                    Price = 19.99M,
                    CategoryId = clothingId
                });
            }
        }

        // Seed Orders
        if (Orders.Count() == 0)
        {
            var customer = Customers.FindAll().First();
            var product = Products.FindAll().First();

            Orders.Insert(new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                OrderDate = DateTime.UtcNow,
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductId = product.Id, Quantity = 2, Price = product.Price }
                }
            });
        }
    }
}
