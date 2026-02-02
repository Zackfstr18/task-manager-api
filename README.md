# Task Manager API

API REST desarrollada con ASP.NET Core (.NET 8) para la gestión de tareas.
Permite crear, consultar, actualizar y eliminar tareas, utilizando persistencia real en base de datos.

## ¿Qué problema resuelve?
Este proyecto permite llevar un control simple de tareas pendientes,
facilitando su gestión desde cualquier cliente que consuma la API,
manteniendo los datos incluso después de reiniciar la aplicación.

## Funciones principales
- Listar todas las tareas
- Ver una tarea por ID
- Crear una tarea
- Marcar una tarea como completada
- Eliminar una tarea

## Tecnologías
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Endpoints disponibles

| Método | Ruta | Descripción |
|------|------|-------------|
| GET | /api/tasks | Obtiene todas las tareas |
| GET | /api/tasks/{id} | Obtiene una tarea por ID |
| POST | /api/tasks | Crea una nueva tarea |
| PUT | /api/tasks/{id}/complete | Marca una tarea como completada |
| DELETE | /api/tasks/{id} | Elimina una tarea |

## Flujo básico del proyecto
1. El cliente realiza una petición HTTP
2. El Controller recibe la solicitud
3. El Service ejecuta la lógica de negocio
4. El DbContext interactúa con la base de datos
5. Se devuelve una respuesta HTTP adecuada

## Cómo ejecutar el proyecto

1. Clonar el repositorio
2. Abrir el proyecto en Visual Studio
3. Restaurar dependencias
4. Ejecutar la aplicación
5. Usar Swagger para probar los endpoints

## Aprendizajes
- Arquitectura básica de una API REST
- Uso de Controllers, Services y Models
- Entity Framework Core y DbContext
- Uso de SQLite como base de datos
- Migraciones y persistencia de datos
- Inyección de dependencias (Scoped)
- Uso correcto de async / await
- Manejo de respuestas HTTP (200, 201, 204, 404)

## Estado actual del proyecto
- CRUD completo
- Persistencia con SQLite
- Migraciones aplicadas
- Swagger operativo

## Mejoras futuras pendientes
- Autenticación y usuarios
- Validaciones más avanzadas
- Deploy en la nube
