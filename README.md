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
- Los datos persisten aunque la API se reinicie

---

## Endpoints disponibles

| Método | Ruta | Descripción |
|------|------|-------------|
| GET | /api/tasks | Obtiene todas las tareas |
| GET | /api/tasks/{id} | Obtiene una tarea por ID |
| POST | /api/tasks | Crea una nueva tarea |
| PUT | /api/tasks/{id}/complete | Marca una tarea como completada |
| DELETE | /api/tasks/{id} | Elimina una tarea |

---

## Modelo de solicitudes y respuestas
- La API utiliza **DTOs** en lugar de exponer entidades directamente
- Las entradas se validan mediante **Data Annotations**
- Las solicitudes inválidas retornan **400 Bad Request** con mensajes claros
- La creación exitosa retorna **201 Created** usando `CreatedAtAction`

---

## Flujo del proyecto
1. El cliente realiza una petición HTTP
2. El Controller recibe y valida el DTO
3. El Service ejecuta la lógica de negocio
4. El DbContext interactúa con la base de datos
5. La API devuelve una respuesta HTTP basada en DTOs

---

## Cómo ejecutar el proyecto
1. Clonar el repositorio
2. Abrir el proyecto en Visual Studio
3. Restaurar dependencias
4. Ejecutar la aplicación
5. Usar Swagger para probar los endpoints

---

## Aprendizajes
- Arquitectura y buenas prácticas en APIs REST
- Separación entre Controllers, Services y DTOs
- Entity Framework Core y DbContext
- Integración de SQLite como base de datos
- Migraciones y persistencia de datos
- Inyección de dependencias (Scoped)
- Uso correcto de async / await
- Validaciones de entrada y contratos de API
- Manejo de respuestas HTTP (200, 201, 204, 400, 404)

---

## Estado actual del proyecto
- CRUD completo
- Persistencia con SQLite
- Migraciones aplicadas
- DTOs de entrada y salida
- Validaciones implementadas
- Swagger completamente funcional

---

## Próximos pasos
- Paginación, filtrado y ordenamiento
- Autenticación y autorización
- Logging y manejo global de errores
- Pruebas unitarias
- Deploy en la nube
