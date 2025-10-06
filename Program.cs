
using System;
using System.Collections.Generic;

// === MODELO DE MASCOTAS ===
abstract class MascotaBase : ICloneable
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public abstract string Tipo { get; }
    public abstract object Clone();
}

class Perro : MascotaBase
{
    public override string Tipo => "Perro";
    public override object Clone() => (Perro)this.MemberwiseClone();
}

class Gato : MascotaBase
{
    public override string Tipo => "Gato";
    public override object Clone() => (Gato)this.MemberwiseClone();
}

class Ave : MascotaBase
{
    public override string Tipo => "Ave";
    public override object Clone() => (Ave)this.MemberwiseClone();
}

// === ABSTRACT FACTORY ===
interface IMascotaFactory
{
    MascotaBase CrearMascota(string nombre, int edad);
}

class PerroFactory : IMascotaFactory
{
    public MascotaBase CrearMascota(string nombre, int edad) => new Perro { Nombre = nombre, Edad = edad };
}

class GatoFactory : IMascotaFactory
{
    public MascotaBase CrearMascota(string nombre, int edad) => new Gato { Nombre = nombre, Edad = edad };
}

class AveFactory : IMascotaFactory
{
    public MascotaBase CrearMascota(string nombre, int edad) => new Ave { Nombre = nombre, Edad = edad };
}

// === SINGLETON HOTEL ===
class HotelMascotas
{
    private static readonly Lazy<HotelMascotas> _instance = new Lazy<HotelMascotas>(() => new HotelMascotas());
    public static HotelMascotas Instancia => _instance.Value;
    private List<MascotaBase> mascotas = new List<MascotaBase>();
    private HotelMascotas() { }
    public void RegistrarMascota(MascotaBase mascota)
    {
        mascotas.Add(mascota);
        Console.WriteLine($"[Hotel] Mascota registrada: {mascota.Nombre} ({mascota.Tipo})");
    }
    public void AsignarHabitacion(MascotaBase mascota)
    {
        string habitacion = mascota.Tipo switch
        {
            "Perro" => "P-101 (Premium)",
            "Gato" => "G-201 (Simple)",
            "Ave" => "A-301 (Aislada)",
            _ => "H-999 (Genérica)"
        };
        Console.WriteLine($"[Hotel] {mascota.Nombre} asignada a la habitación {habitacion}"); 
    }
}

// === SERVICIO VETERINARIO ===
class ServicioVeterinario
{
    public void RegistrarConsulta(MascotaBase mascota, string motivo)
    {
        Console.WriteLine($"[Vet] Consulta registrada para {mascota.Nombre}: {motivo}"); 
    }
    public void RegistrarVacuna(MascotaBase mascota, string vacuna)
    {
        Console.WriteLine($"[Vet] Vacuna '{vacuna}' aplicada a {mascota.Nombre}"); 
    }
}

// === BUILDER FACTURA ===
class Factura
{
    public string Cliente { get; set; } = "";
    public DateTime Fecha { get; set; }
    public List<string> Lineas { get; set; } = new List<string>();
    public decimal Total { get; set; }
    public void Mostrar()
    {
        Console.WriteLine("----- FACTURA -----");
        Console.WriteLine($"Cliente: {Cliente}"); 
        Console.WriteLine($"Fecha: {Fecha:d}"); 
        foreach(var linea in Lineas) Console.WriteLine(linea);
        Console.WriteLine($"Total: ${Total:0.00}"); 
        Console.WriteLine("-------------------");
    }
}

class FacturaBuilder
{
    private Factura factura = new Factura();
    public FacturaBuilder ConCliente(string nombre) { factura.Cliente = nombre; return this; }
    public FacturaBuilder ConFecha(DateTime fecha) { factura.Fecha = fecha; return this; }
    public FacturaBuilder AgregarLinea(string descripcion, decimal precio) 
    { 
        factura.Lineas.Add($"- {descripcion} : ${precio:0.00}"); 
        factura.Total += precio;
        return this; 
    }
    public Factura Build() => factura;
}

// === PROGRAMA INTERACTIVO ===
class Program
{
    static void Main()
    {
        var hotel = HotelMascotas.Instancia;
        var vet = new ServicioVeterinario();
        List<MascotaBase> mascotas = new List<MascotaBase>();

        while(true)
        {
            Console.WriteLine("\n=== CLÍNICA Y HOTEL DE MASCOTAS ===");
            Console.WriteLine("1. Registrar mascota");
            Console.WriteLine("2. Asignar habitación");
            Console.WriteLine("3. Registrar consulta veterinaria");
            Console.WriteLine("4. Registrar vacuna");
            Console.WriteLine("5. Generar factura demo");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione opción: ");
            string opcion = Console.ReadLine();

            switch(opcion)
            {
                case "1":
                    Console.Write("Nombre de la mascota: ");
                    string nombre = Console.ReadLine() ?? "SinNombre";
                    Console.Write("Edad: ");
                    int edad = int.TryParse(Console.ReadLine(), out int e) ? e : 0;
                    Console.Write("Tipo (Perro/Gato/Ave): ");
                    string tipo = Console.ReadLine()?.ToLower() ?? "perro";

                    IMascotaFactory factory = tipo switch
                    {
                        "perro" => new PerroFactory(),
                        "gato" => new GatoFactory(),
                        "ave" => new AveFactory(),
                        _ => new PerroFactory()
                    };
                    MascotaBase mascota = factory.CrearMascota(nombre, edad);
                    mascotas.Add(mascota);
                    hotel.RegistrarMascota(mascota);
                    break;

                case "2":
                    Console.Write("Ingrese nombre de la mascota: ");
                    string nombreHab = Console.ReadLine() ?? "";
                    var mascotaHab = mascotas.Find(m => m.Nombre == nombreHab);
                    if(mascotaHab != null) hotel.AsignarHabitacion(mascotaHab);
                    else Console.WriteLine("Mascota no encontrada.");
                    break;

                case "3":
                    Console.Write("Nombre de la mascota: ");
                    string nombreCon = Console.ReadLine() ?? "";
                    var mascotaCon = mascotas.Find(m => m.Nombre == nombreCon);
                    if(mascotaCon != null)
                    {
                        Console.Write("Motivo de la consulta: ");
                        string motivo = Console.ReadLine() ?? "General";
                        vet.RegistrarConsulta(mascotaCon, motivo);
                    }
                    else Console.WriteLine("Mascota no encontrada.");
                    break;

                case "4":
                    Console.Write("Nombre de la mascota: ");
                    string nombreVac = Console.ReadLine() ?? "";
                    var mascotaVac = mascotas.Find(m => m.Nombre == nombreVac);
                    if(mascotaVac != null)
                    {
                        Console.Write("Nombre de la vacuna: ");
                        string vacuna = Console.ReadLine() ?? "VacunaX";
                        vet.RegistrarVacuna(mascotaVac, vacuna);
                    }
                    else Console.WriteLine("Mascota no encontrada.");
                    break;

                case "5":
                    var factura = new FacturaBuilder()
                        .ConCliente("Jassiel")
                        .ConFecha(DateTime.Now)
                        .AgregarLinea("Consulta veterinaria - Firulais", 200m)
                        .AgregarLinea("Habitación premium (2 noches)", 800m)
                        .AgregarLinea("Baño y estética", 150m)
                        .Build();
                    factura.Mostrar();
                    break;

                case "6": return;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
    }
}
