# Minimal API - .NET 8

Proyecto de ejemplo desarrollado con ASP.NET Core Minimal API utilizando Entity Framework Core, SQL Server y Output Caching con Redis.

## Tecnologías

- .NET 8
- ASP.NET Core Minimal API
- Entity Framework Core 8
- SQL Server
- Redis
- Output Cache

## Funcionalidades

- CRUD de Personas
- Persistencia en SQL Server mediante Entity Framework Core
- Cacheo de respuestas utilizando Output Cache
- Redis como proveedor de caché distribuida
- Invalidación automática de caché al crear, actualizar o eliminar registros

## Configuración

### Connection Strings

Configurar las cadenas de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=...;Database=...;Trusted_Connection=True;",
    "redis": "localhost:6379"
  }
}
```

## Endpoints

### Obtener todas las personas

```http
GET /personas
```

Respuesta:

```json
[
  {
    "id": 1,
    "nombre": "Juan"
  }
]
```

### Obtener persona por ID

```http
GET /personas/{id}
```

### Crear persona

```http
POST /personas
```

Body:

```json
{
  "nombre": "Juan"
}
```

### Actualizar persona

```http
PUT /personas/{id}
```

Body:

```json
{
  "id": 1,
  "nombre": "Juan Actualizado"
}
```

### Eliminar persona

```http
DELETE /personas/{id}
```

## Caché

El endpoint:

```http
GET /personas
```

se almacena en caché durante 60 segundos.

```csharp
.CacheOutput(c => c
    .Expire(TimeSpan.FromSeconds(60))
    .Tag("personas-get"));
```

Cuando se crea, modifica o elimina una persona, la caché se invalida automáticamente:

```csharp
await outputCacheStore.EvictByTagAsync("personas-get", default);
```

## Ejecución

Restaurar paquetes:

```bash
dotnet restore
```

Ejecutar la aplicación:

```bash
dotnet run
```
