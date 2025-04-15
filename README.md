# Papara x Patika Bootcamp - RESTful API Assignment

This is a basic RESTful API project developed as part of the Papara & Patika.dev Bootcamp. The project follows REST standards and implements common HTTP methods with proper status codes and error handling.

##  Features

✅ Follows REST standards  
✅ Supports CRUD operations using HTTP methods:  
  - `GET`  
  - `POST`  
  - `PUT`  
  - `DELETE`  
  - `PATCH`  

✅ Uses proper HTTP status codes:  
  - 200 OK  
  - 201 Created  
  - 400 Bad Request  
  - 404 Not Found  
  - 500 Internal Server Error  

✅ Model validation using Data Annotations  
✅ Routing and Model Binding (from both body and query)  
✅ Error handling with standardized error responses  
✅ Supports filtering and sorting via query parameters (Bonus)

##  Example Endpoints

- `GET /api/products` – Get all products  
- `GET /api/products/{id}` – Get product by ID  
- `POST /api/products` – Create a new product  
- `PUT /api/products/{id}` – Update a product  
- `DELETE /api/products/{id}` – Delete a product  
- `PATCH /api/products/{id}` – Partial update  
- `GET /api/products/list?name=abc` – Filter products by name (bonus)


