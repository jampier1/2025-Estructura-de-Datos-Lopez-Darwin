using System;

class Estudiante
{
    public int Id;
    public string Nombres = "";
    public string Apellidos = "";
    public string Direccion = "";
    public string[] Telefonos = new string[3];

    public void MostrarDatos()
    {
        Console.WriteLine("\n===== DATOS DEL ESTUDIANTE =====");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombres: {Nombres}");
        Console.WriteLine($"Apellidos: {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");
        
        Console.WriteLine("Teléfonos:");
        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        Estudiante estudiante = new Estudiante();

        // Leer ID con validación
        while (true)
        {
            Console.Write("Ingrese el ID del estudiante (número entero): ");
            string? idInput = Console.ReadLine();
            if (int.TryParse(idInput, out int id))
            {
                estudiante.Id = id;
                break;
            }
            Console.WriteLine("ID no válido. Intente de nuevo.");
        }

        Console.Write("Ingrese los nombres del estudiante: ");
        estudiante.Nombres = Console.ReadLine() ?? "";

        Console.Write("Ingrese los apellidos del estudiante: ");
        estudiante.Apellidos = Console.ReadLine() ?? "";

        Console.Write("Ingrese la dirección del estudiante: ");
        estudiante.Direccion = Console.ReadLine() ?? "";

        Console.WriteLine("\nIngrese los 3 números de teléfono:");

        for (int i = 0; i < estudiante.Telefonos.Length; i++)
        {
            Console.Write($"Teléfono {i + 1}: ");
            estudiante.Telefonos[i] = Console.ReadLine() ?? "";
        }

        estudiante.MostrarDatos();
    }
}
