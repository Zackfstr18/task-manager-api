# Task Manager API

Esta es una API REST desarrollada con ASP.NET Core (.NET 8) para gestionar tareas personales.
Permite crear, consultar, actualizar y eliminar tareas.

## ¿Qué problema resuelve?
Este proyecto permite llevar un control simple de tareas pendientes,
facilitando su gestión desde cualquier cliente que consuma la API.

## Funciones principales
- Listar todas las tareas
- Ver una tarea por ID
- Crear una tarea
- Marcar una tarea como completada
- Eliminar una tarea

## Tecnologías
- ASP.NET Core Web API
- .NET 8
- Swagger / OpenAPI

## Endpoints disponibles

| Método | Ruta | Descripción |
|------|------|-------------|
| GET | /api/tasks | Obtiene todas las tareas |
| GET | /api/tasks/{id} | Obtiene una tarea por ID |
| POST | /api/tasks | Crea una nueva tarea |
| PUT | /api/tasks/{id}/complete | Marca una tarea como completada |
| DELETE | /api/tasks/{id} | Elimina una tarea |

##Cómo ejecutar el proyecto

1. Clonar el repositorio
2. Abrir el proyecto en Visual Studio
3. Ejecutar la aplicación
4. Usar Swagger para probar los endpoints

## Aprendizajes

- Funcionamiento básico de una API REST
- Uso de Controllers y Models en ASP.NET Core
- Manejo de peticiones HTTP (GET, POST, PUT, DELETE)
- Manejo de respuestas correctas (200, 204, 404)
- Flujo completo de una API backend

## Mejoras futuras pendientes

- Persistencia con base de datos
- Autenticación y usuarios
- Validaciones más avanzadas
- Deploy en la nube
