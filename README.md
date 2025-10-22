# 🚗 MilesCarRental API

API desarrollada en **.NET 8** para el sistema de alquiler de vehículos **Miles Car Rental**.  
Implementa un motor de búsqueda avanzado de vehículos disponibles según **localidad de recogida**, **localidad de devolución** y **mercado**, usando **PostgreSQL** como base de datos y **Dapper + EF Core** para el acceso a datos.

---

## 📋 Requisitos previos

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

### 🧩 SDKs y herramientas
| Herramienta | Versión mínima | Instalación |
|--------------|----------------|--------------|
| [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) | 8.0 | `dotnet --version` |
| [Entity Framework Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) | 8.0 | `dotnet tool install --global dotnet-ef` |

---

## 🗃️ Base de Datos

El proyecto usa **PostgreSQL** como motor principal.  
Durante el desarrollo, se utiliza un **servidor público de pruebas** para facilitar las migraciones y validaciones del esquema.

> ⚠️ Nota: este servidor público es únicamente para **pruebas académicas o de desarrollo**.  
> No debe usarse en entornos productivos ya que no ofrece garantías de seguridad ni disponibilidad.