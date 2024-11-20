# ECommerceApi
Purpose: The E-Commerce API is a RESTful web service designed to facilitate online shopping, including product management, category management, customer management, order processing, and order item tracking. It is built using C# with LiteDB as the database.


Key Features:
1. Manage Products, including their details and associated categories.
2. Organize Categories to group products effectively.
3. Handle Customer data for a streamlined shopping experience.
4. Process Orders, including customer details and order date.
5. Track Order Items, which link products to specific orders with quantities.


Entities and Relationships:
1. Product:
Associated with a Category (via CategoryId).
2. Category:
Groups multiple Products.
3. Customer:
Places Orders.
4. Order:
Belongs to a Customer and contains multiple Order Items.
5. OrderItem:
Represents a product with a specific quantity in an Order.


API Endpoints:
Below is the complete list of endpoints categorized by controller:

I. CategoryController

1. GET /api/category
> Retrieves all categories.
> Response:
200 OK - List of all categories.
Example:
[
  { "id": "1", "name": "Electronics" },
  { "id": "2", "name": "Books" }
]

2. GET /api/category/{id}
> Retrieves a specific category by its ID.
> Response:
200 OK - Category details.
404 Not Found - If the category doesn't exist.

3. POST /api/category
> Creates a new category.
> Request Body:
{ "name": "New Category" }
> Response:
201 Created - The created category.

4. PUT /api/category/{id}
> Updates an existing category.
> Request Body:
{ "id": "1", "name": "Updated Category" }
> Response:
204 No Content.

5. DELETE /api/category/{id}
> Deletes a category by ID.
> Response:
204 No Content.


II. ProductController

1. GET /api/product
> Retrieves all products, including their categories.
> Response:
200 OK - List of all products.

2. GET /api/product/{id}
> Retrieves a specific product by its ID.
> Response:
200 OK - Product details.
404 Not Found - If the product doesn't exist.

3. POST /api/product
> Creates a new product.
> Request Body:
{
  "name": "Product Name",
  "description": "Product Description",
  "price": 99.99,
  "categoryId": "1"
}
> Response:
201 Created - The created product.

4. PUT /api/product/{id}
> Updates an existing product.
> Request Body:
{
  "id": "1",
  "name": "Updated Name",
  "description": "Updated Description",
  "price": 89.99,
  "categoryId": "2"
}
> Response:
204 No Content.

5. DELETE /api/product/{id}
> Deletes a product by ID.
> Response:
204 No Content.


III. CustomerController

1. GET /api/customer
> Retrieves all customers.
> Response:
200 OK - List of all customers.

2. GET /api/customer/{id}
> Retrieves a specific customer by their ID.
> Response:
200 OK - Customer details.
404 Not Found - If the customer doesn't exist.

3. POST /api/customer
> Creates a new customer.
> Request Body:
{
  "name": "Customer Name",
  "email": "email@example.com",
  "address": "Customer Address"
}
> Response:
201 Created - The created customer.

4. PUT /api/customer/{id}
> Updates an existing customer.
> Request Body:
{
  "id": "1",
  "name": "Updated Name",
  "email": "newemail@example.com",
  "address": "New Address"
}
> Response:
204 No Content.

5. DELETE /api/customer/{id}
> Deletes a customer by ID.
> Response:
204 No Content.


IV. OrderController

1. GET /api/order
> Retrieves all orders.
> Response:
200 OK - List of all orders.

2. GET /api/order/{id}
> Retrieves a specific order by its ID.
> Response:
200 OK - Order details.
404 Not Found - If the order doesn't exist.

3. POST /api/order
> Creates a new order.
> Request Body:
{
  "customerId": "1",
  "orderDate": "2023-11-20T00:00:00Z"
}
> Response:
201 Created - The created order.

4. PUT /api/order/{id}
> Updates an existing order.
> Request Body:
{
  "id": "1",
  "customerId": "2",
  "orderDate": "2023-12-01T00:00:00Z"
}
> Response:
204 No Content.

5. DELETE /api/order/{id}
> Deletes an order by ID.
> Response:
204 No Content.


V. OrderItemController

1. GET /api/orderitem
> Retrieves all order items.
> Response:
200 OK - List of all order items.

2. GET /api/orderitem/{id}
> Retrieves a specific order item by its ID.
> Response:
200 OK - Order item details.
404 Not Found - If the order item doesn't exist.

3. POST /api/orderitem
> Creates a new order item.
> Request Body:
{
  "orderId": "1",
  "productId": "1",
  "quantity": 3
}
> Response:
201 Created - The created order item.

4. PUT /api/orderitem/{id}
> Updates an existing order item.
> Request Body:
{
  "id": "1",
  "orderId": "1",
  "productId": "2",
  "quantity": 5
}
> Response:
204 No Content.

5. DELETE /api/orderitem/{id}
> Deletes an order item by ID.
> Response:
204 No Content.


Tools and Frameworks:
1. ASP.NET Core: For building the RESTful web service.
2. LiteDB: A lightweight NoSQL database for data storage.
3. Swagger UI: For API documentation and testing.


Setup Instructions:
1. Clone/Download the project repository from GitHub.
2. Open the project in Visual Studio.
3. Run the project, and navigate to /swagger to access the API documentation.
4. Use tools like Postman or Swagger to test the endpoints.
