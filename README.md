# 🐾 Clínica Veterinaria y Hotel de Mascotas – Versión Interactiva Refactorizada

## 🎯 Objetivo
Proyecto refactorizado con **patrones creacionales GoF** y menú interactivo en consola, listo para ejecutar y entregar.

## 📂 Contenido
- Program.cs → Código interactivo con patrones: Factory Method, Abstract Factory, Singleton, Builder y Prototype.
- clinica_mascotas_app.csproj → Proyecto .NET 8
- README.md → Documentación

## ▶️ Ejecución
```bash
cd clinica_mascotas_app
dotnet build
dotnet run
```

## 🧩 Funcionalidades
1. Registrar mascota (Perro, Gato, Ave)
2. Asignar habitación según tipo
3. Registrar consulta veterinaria
4. Registrar vacuna
5. Generar factura demo
6. Salir

## 📚 Patrones GoF Aplicados
- **Factory Method / Abstract Factory** → Creación de mascotas según tipo
- **Singleton** → Instancia única del hotel
- **Builder** → Construcción de factura paso a paso
- **Prototype** → Clonación de mascotas (no demo explícita, pero preparada)

## 💻 Requisitos
- .NET 8 SDK
- Consola para ejecución

