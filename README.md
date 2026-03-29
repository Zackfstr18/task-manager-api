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
- Consultas avanzadas en el listado de tareas:
  - Paginación
  - Búsqueda por título
  - Filtro por estado
  - Ordenamiento dinámico
- Manejo global de errores
- Logging estructurado
- Respuestas estándar en toda la API
- Validación automática de datos de entrada
- Autenticación con JWT
- Registro y login de usuarios
- Protección de endpoints con autorización
- Soporte multiusuario (cada usuario gestiona sus propias tareas)
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
| GET | /api/tasks | Obtiene todas las tareas (soporta paginación, búsqueda, filtros y ordenamiento) |
| GET | /api/tasks/{id} | Obtiene una tarea por ID |
| POST | /api/tasks | Crea una nueva tarea |
| PUT | /api/tasks/{id}/complete | Marca una tarea como completada |
| DELETE | /api/tasks/{id} | Elimina una tarea |

---

## Consultas avanzadas

El endpoint `GET /api/tasks` permite controlar los resultados mediante parámetros en la URL.
---

## Formato de respuestas de la API

Todas las respuestas siguen una estructura estándar.

### Respuesta exitosa

json
{
  "success": true,
  "message": "Operación realizada correctamente",
  "data": {}
}

### Respuesta de error

json
{
  "success": false,
  "message": "Ocurrió un error",
  "data": null
}

---

## Autenticación

La API implementa autenticación basada en JSON Web Tokens (JWT).

### Endpoints de autenticación

| Método | Ruta | Descripción |
|------|------|-------------|
| POST | /api/auth/register | Registrar un nuevo usuario |
| POST | /api/auth/login | Iniciar sesión y obtener token |
| GET | /api/auth/me | Obtener usuario autenticado |

---

### Uso del token

Después de hacer login, se obtiene un token JWT:

json
{
  "success": true,
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIs..."
  }
}

---

## Manejo de errores

La API implementa un middleware global para capturar excepciones.

En caso de error interno, se devuelve una respuesta controlada:

json
{
  "statusCode": 500,
  "message": "An unexpected error occurred",
  "traceId": "..."
}

## Logging

La API utiliza Serilog para el registro de eventos y errores.

Los logs se almacenan en:

- Consola
- Archivos locales (`/logs`)

Esto permite:

- Diagnóstico de errores
- Seguimiento de ejecución
- Auditoría básica del sistema
  
---
### Paginación

Permite dividir los resultados en páginas.

GET /api/tasks?page=1&pageSize=10

Parámetros:

| Parámetro | Descripción |
|----------|-------------|
| page | Número de página |
| pageSize | Cantidad de elementos por página |

La API limita el tamaño máximo de página para evitar consultas excesivas.

---

### Búsqueda por título

Permite buscar tareas por texto dentro del título.

GET /api/tasks?search=api

Devuelve todas las tareas cuyo título contenga el texto indicado.

---

### Filtro por estado

Permite filtrar tareas completadas o pendientes.

GET /api/tasks?isCompleted=true

o

GET /api/tasks?isCompleted=false

---

### Ordenamiento

Permite ordenar los resultados dinámicamente.

GET /api/tasks?sortBy=title

Orden descendente:

GET /api/tasks?sortBy=createdAt&descending=true

Campos soportados actualmente:

- title
- createdAt
- status

---

### Ejemplo de consulta completa

GET /api/tasks?search=api&isCompleted=false&sortBy=createdAt&descending=true&page=2&pageSize=5

Esta consulta:

- busca tareas que contengan "api"
- filtra tareas no completadas
- ordena por fecha de creación descendente
- devuelve la página 2 con 5 resultados

---

## Soporte multiusuario

Cada tarea está asociada a un usuario mediante `UserId`.

### Comportamiento

- Al crear una tarea, se asigna automáticamente al usuario autenticado
- Cada usuario solo puede ver sus propias tareas
- Los datos están completamente aislados entre usuarios

Esto simula un sistema real tipo gestor de tareas personal (To-Do app).

---
## Modelo de solicitudes y respuestas
- La API utiliza **DTOs** en lugar de exponer entidades directamente
- Las entradas se validan mediante **Data Annotations**
- Las solicitudes inválidas retornan **400 Bad Request** con mensajes claros
- La creación exitosa retorna **201 Created** usando `CreatedAtAction`

---

## Flujo del proyecto

1. El cliente realiza una petición HTTP
2. El usuario se autentica mediante JWT (si el endpoint lo requiere)
3. El Controller recibe la solicitud
4. El Service ejecuta la lógica de negocio
5. El DbContext interactúa con la base de datos
6. Se devuelve una respuesta estándar (ApiResponse)

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
- Consultas avanzadas en endpoints (paginación, búsqueda, filtros y ordenamiento)
- Manejo global de errores
- Logging con Serilog
- Respuestas estándar (ApiResponse)
- Validación centralizada
- Autenticación con JWT
- Protección de endpoints
- Soporte multiusuario
  
---

## Próximos pasos
- Autenticación y autorización
- Logging y manejo global de errores
- Pruebas unitarias
- Deploy en la nube
