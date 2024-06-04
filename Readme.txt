# Product API

## Descripción

Este proyecto es una API de productos construida con ASP.NET Core que utiliza varias tecnologías y patrones de arquitectura(mencionados posteriormente) para garantizar una aplicación robusta y escalable. Entre los patrones y tecnologías implementadas se incluyen CQRS (Command Query Responsibility Segregation), caching en memoria, un repositorio genérico, logging, y documentación con Swagger.

### Características Principales

1. CQRS (Command Query Responsibility Segregation): La API implementa el patrón CQRS para separar claramente las operaciones de lectura y escritura, mejorando la escalabilidad y la mantenibilidad del código.
2. Caching en Memoria: Utiliza IMemoryCache para cachear ciertos datos (como los estados de los productos) durante 5 minutos, mejorando el rendimiento de la API.
3. Repositorio Genérico: Implementa un patrón de repositorio genérico para proporcionar una abstracción sobre los datos, lo que facilita el acceso y la manipulación de datos.
4. Logging: Utiliza ILogger para registrar información de los request.
5. Documentación con Swagger**: Utiliza Swagger como interfaz interactiva para explorar y probar los endpoints de la API.

## Tecnologías Utilizadas

- ASP.NET Core
- Entity Framework Core
- CQRS Pattern
- In-Memory Caching
- Generic Repository Pattern
- Swagger / Swashbuckle