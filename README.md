# 🐾 Clínica Veterinaria y Hotel de Mascotas – Proyecto Refactorizado

## 🎯 Objetivo General
Simular una aplicación para la gestión de una clínica veterinaria y un hotel de mascotas, aplicando **patrones de diseño creacionales GoF**: Factory Method, Abstract Factory, Singleton, Builder y Prototype.  
El proyecto permite registrar mascotas, asignar habitaciones, registrar servicios médicos y generar facturas, demostrando buenas prácticas de programación y refactorización.

---

## 🎯 Objetivos Específicos
- Refactorizar código espagueti aplicando **Factory Method**, **Abstract Factory**, **Singleton**, **Builder** y **Prototype**.  
- Separar responsabilidades de la clínica y del hotel de mascotas (SRP).  
- Documentar cambios realizados y evidencias de funcionamiento.  
- Mejorar la estructura y modularidad del proyecto.

---

## 🧨 Problemas Originales Resueltos
El proyecto inicial presentaba:
1. Código duplicado al crear diferentes tipos de mascotas.  
2. Alta dependencia entre clases concretas.  
3. Mezcla de lógica médica y hotelera.  
4. Ausencia de clase de configuración centralizada.  
5. Método `Main()` con demasiada lógica operativa.  
6. Clases monolíticas sin separación de responsabilidades.  
7. Enumeraciones mal utilizadas para tipos de servicios.  
8. Propiedades públicas sin encapsulación.  
9. Métodos largos y difíciles de probar.  
10. No existía fábrica para instanciar habitaciones personalizadas.  

Todos estos problemas se solucionaron aplicando patrones GoF y refactorizando el código.

---

## 📂 Estructura del Proyecto
clinica_mascotas_app/
│
├── Program.cs # Menú interactivo y ejecución principal
├── Clinica/ # Lógica de servicios veterinarios
│ ├── ServicioVeterinario.cs
│ └── FacturaBuilder.cs
├── Hotel/ # Lógica de hotel de mascotas
│ ├── HotelMascotas.cs
│ └── HabitacionFactory.cs
├── Mascotas/ # Clases y fábricas de mascotas
│ ├── Mascota.cs
│ ├── MascotaFactory.cs
│ └── MascotaPrototype.cs
├── clinica_mascotas_app.csproj
└── README.md

---

## 🧩 Funcionalidades
1. **Registrar mascota**: Perro, Gato o Ave usando Factory Method y Abstract Factory.  
2. **Asignar habitación**: Cada mascota recibe habitación según tipo, controlada por Singleton.  
3. **Registrar consulta veterinaria**: Método para registrar consultas y vacunas.  
4. **Generar factura demo**: Builder crea facturas paso a paso mostrando servicios.  
5. **Clonación de mascotas**: Prototype permite duplicar mascotas si se requiere.  
6. **Salir**: Cierra el programa correctamente.

---

## 📚 Patrones GoF Aplicados
| Patrón | Uso en el proyecto |
|--------|------------------|
| Factory Method | Creación de mascotas según tipo. |
| Abstract Factory | Agrupa familias de servicios veterinarios y de hotel. |
| Singleton | Instancia única del hotel para controlar habitaciones. |
| Builder | Construcción de facturas paso a paso con servicios añadidos. |
| Prototype | Clonación de mascotas para futuras operaciones. |

---

## 💻 Requisitos
- **.NET 8 SDK**  
- Consola para ejecutar el proyecto (Windows, Linux o macOS)  
- Editor recomendado: Visual Studio Code, Rider o Visual Studio 2022+

---

## ▶️ Ejecución del Proyecto
1. Abrir terminal o consola en la carpeta del proyecto:
  cd clinica_mascotas_app

2. Compilar el proyecto:
  dotnet build

3. Ejecutar la aplicación:
   dotnet run

---

## 📌 Ejemplo de Uso
=== CLÍNICA Y HOTEL DE MASCOTAS ===
1. Registrar mascota
2. Asignar habitación
3. Registrar consulta veterinaria
4. Registrar vacuna
5. Generar factura demo
6. Salir

Seleccione opción: 1
Nombre de la mascota: Firulais
Edad: 3
Tipo (Perro/Gato/Ave): Perro
[Hotel] Mascota registrada: Firulais (Perro)

Seleccione opción: 2
[Hotel] Habitación asignada a Firulais

---

## 📝 Evidencia de Funcionamiento
El menú permite registrar mascotas y servicios.
Se asignan habitaciones automáticamente según tipo de mascota.
Se registran consultas y vacunas correctamente.
Se genera una factura demo mostrando servicios y total.
Código modular, limpio y comentado en español.

---

## ✅ Buenas Prácticas Aplicadas
Código refactorizado y modularizado.
Separación de responsabilidades: clínica, hotel y facturación.
Uso correcto de patrones GoF creacionales.
Menú interactivo simple y fácil de usar.
Métodos cortos y probables, propiedades encapsuladas.

---

## 📚 Referencias
Refactoring.Guru – Patrones de Diseño\
Alexander Shvets – Dive Into Design Patterns
Bhuvan Unhelkar – Software Engineering with UML
Narasimha Karumanchi – Peeling Design Patterns
