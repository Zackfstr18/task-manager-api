# Task Manager API

REST API developed with **ASP.NET Core (.NET 8)** for task management.  
It allows creating, retrieving, updating, and deleting tasks using real database persistence, DTOs, and input validation.

---

## What problem does it solve?
This project provides a simple way to manage pending tasks,  
making them accessible from any client that consumes the API,  
while keeping data persisted even after restarting the application.

---

## Main Features
- List all tasks
- Get a task by ID
- Create a task with validations
- Mark a task as completed
- Delete a task
- Advanced query capabilities for task listing:
  - Pagination
  - Title search
  - Status filtering
  - Dynamic sorting

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
| GET | /api/tasks | Get all tasks (supports pagination, search, filtering and sorting) |
| GET | /api/tasks/{id} | Gets a task by ID |
| POST | /api/tasks | Creates a new task |
| PUT | /api/tasks/{id}/complete | Marks a task as completed |
| DELETE | /api/tasks/{id} | Deletes a task |

---

## Advanced Queries (Phase 6)

The `GET /api/tasks` endpoint allows controlling the results using query parameters.

### Pagination

Split results into pages.

GET /api/tasks?page=1&pageSize=10

Parameters:

| Parameter | Description |
|----------|-------------|
| page | Page number |
| pageSize | Number of items per page |

The API limits the maximum page size to prevent excessive queries.

---

### Title Search

Allows searching tasks by text contained in the title.

GET /api/tasks?search=api

Returns tasks whose title contains the specified text.

---

### Status Filter

Allows filtering completed or pending tasks.

GET /api/tasks?isCompleted=true

or

GET /api/tasks?isCompleted=false

---

### Sorting

Allows dynamically sorting the results.

GET /api/tasks?sortBy=title

Descending order:

GET /api/tasks?sortBy=createdAt&descending=true

Currently supported fields:

- title
- createdAt
- status

---

### Full Query Example

GET /api/tasks?search=api&isCompleted=false&sortBy=createdAt&descending=true&page=2&pageSize=5

This query:

- searches tasks containing "api"
- filters incomplete tasks
- sorts by creation date descending
- returns page 2 with 5 results
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

## Current Project Status
- Full CRUD
- SQLite persistence
- Migrations applied
- Input and Output DTOs
- Validations implemented
- Swagger fully operational
- Advanced query capabilities (pagination, search, filtering and sorting)

---

## Next Steps
- Authentication and authorization
- Logging and global error handling
- Unit testing
- Cloud deployment
