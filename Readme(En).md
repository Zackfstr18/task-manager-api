# Task Manager API

REST API developed with **ASP.NET Core (.NET 8)** for task management.  
It allows creating, retrieving, updating, and deleting tasks using real database persistence, DTOs, and input validation.

---

## What problem does it solve?
This project provides a simple way to manage pending tasks,  
making them accessible from any client that consumes the API,  
while keeping data persisted even after restarting the application.

---

## Main features
- List all tasks
- Get a task by ID
- Create a task with validation
- Mark a task as completed
- Delete a task

---

## Technologies
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

---

## Architecture overview
The project follows a clean and simple layered architecture:

- **Controllers**: Handle HTTP requests and responses
- **Services**: Contain business logic
- **DTOs**: Define the API contract (input and output)
- **Models (Entities)**: Represent database structure
- **DbContext**: Handles database access via EF Core

Entities are never exposed directly through the API.

---

## Data persistence
- Uses **SQLite** as a local database
- Managed with **Entity Framework Core**
- Database schema is maintained through **migrations**
- Data persists across application restarts

---

## Available endpoints

| Method | Route | Description |
|------|------|-------------|
| GET | /api/tasks | Gets all tasks |
| GET | /api/tasks/{id} | Gets a task by ID |
| POST | /api/tasks | Creates a new task |
| PUT | /api/tasks/{id}/complete | Marks a task as completed |
| DELETE | /api/tasks/{id} | Deletes a task |

---

## Request & response model
- The API uses **DTOs** instead of exposing entities directly
- Input is validated using **Data Annotations**
- Invalid requests return **400 Bad Request** with clear messages
- Successful creation returns **201 Created** using `CreatedAtAction`

---

## Project flow
1. The client sends an HTTP request
2. The Controller receives and validates the DTO
3. The Service executes business logic
4. The DbContext interacts with the database
5. The API returns a DTO-based HTTP response

---

## How to run the project
1. Clone the repository
2. Open the project in Visual Studio
3. Restore dependencies
4. Run the application
5. Use Swagger to test the endpoints

---

## What I learned
- REST API architecture and best practices
- Controllers, Services, and DTO separation
- Entity Framework Core and DbContext
- SQLite database integration
- Database migrations and persistence
- Dependency Injection (Scoped services)
- Proper use of async / await
- Input validation and API contracts
- HTTP response handling (200, 201, 204, 400, 404)

---

## Current project status
- Full CRUD implemented
- SQLite persistence
- Migrations applied
- DTOs for input and output
- Input validation in place
- Swagger fully operational

---

## Next steps
- Pagination, filtering, and sorting
- Authentication and authorization
- Logging and error handling
- Unit testing
- Cloud deployment
