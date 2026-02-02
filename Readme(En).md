# Task Manager API

REST API developed with **ASP.NET Core (.NET 8)** for task management.  
It allows creating, retrieving, updating, and deleting tasks using real database persistence.

## What problem does it solve?
This project provides a simple way to manage pending tasks,  
making them accessible from any client that consumes the API,  
while keeping the data even after restarting the application.

## Main features
- List all tasks
- Get a task by ID
- Create a task
- Mark a task as completed
- Delete a task

## Technologies
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Available endpoints

| Method | Route | Description |
|------|------|-------------|
| GET | /api/tasks | Gets all tasks |
| GET | /api/tasks/{id} | Gets a task by ID |
| POST | /api/tasks | Creates a new task |
| PUT | /api/tasks/{id}/complete | Marks a task as completed |
| DELETE | /api/tasks/{id} | Deletes a task |

## Project flow
1. The client sends an HTTP request
2. The Controller receives the request
3. The Service executes the business logic
4. The DbContext interacts with the database
5. An appropriate HTTP response is returned

## How to run the project
1. Clone the repository
2. Open the project in Visual Studio
3. Restore dependencies
4. Run the application
5. Use Swagger to test the endpoints

## What I learned
- REST API architecture
- Controllers, Services, and Models separation
- Entity Framework Core and DbContext
- SQLite database integration
- Migrations and data persistence
- Dependency Injection (Scoped services)
- Proper use of async / await
- HTTP response handling (200, 201, 204, 404)

## Current project status
- Full CRUD implemented
- SQLite persistence
- Migrations applied
- Swagger fully operational

## Future improvements
- DTOs and input validations
- Authentication and users
- Unit testing
- Cloud deployment
