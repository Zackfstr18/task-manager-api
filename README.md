# Task Manager API

API REST desarrollada con **ASP.NET Core (.NET 8)** para la gestión de tareas.  
Permite crear, consultar, actualizar y eliminar tareas utilizando persistencia real en base de datos, DTOs y validaciones de entrada.

---

## ¿Qué problema resuelve?
Este proyecto permite llevar un control simple de tareas pendientes,  
facilitando su gestión desde cualquier cliente que consuma la API,  
manteniendo los datos incluso después de reiniciar la aplicación.

---

## Funciones principales
- Listar todas las tareas
- Obtener una tarea por ID
- Crear una tarea con validaciones
- Marcar una tarea como completada
- Eliminar una tarea

---

## Tecnologías
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

---

## Visión general de la arquitectura
El proyecto sigue una arquitectura simple y ordenada por capas:

- **Controllers**: Manejan las peticiones y respuestas HTTP
- **Services**: Contienen la lógica de negocio
- **DTOs**: Definen el contrato de la API (entrada y salida)
- **Models (Entidades)**: Representan la estructura de la base de datos
- **DbContext**: Gestiona el acceso a datos mediante EF Core

Las entidades **no se exponen directamente** a través de la API.

---

## Persistencia de datos
- Se utiliza **SQLite** como base de datos local
- Se gestiona mediante **Entity Framework Core**
- La estructura de la base de datos se mantiene con **migraciones**
- Los datos persisten au
