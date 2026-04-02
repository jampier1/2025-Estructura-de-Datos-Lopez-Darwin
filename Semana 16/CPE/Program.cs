using System;
using System.Collections.Generic;

namespace VuelosBaratos
{
    class Program
    {
        static GrafoVuelos grafo = new GrafoVuelos();

        static void Main(string[] args)
        {
            CargarDatos();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n╔══════════════════════════════════════════╗");
                Console.WriteLine("║     SISTEMA DE VUELOS BARATOS            ║");
                Console.WriteLine("╠══════════════════════════════════════════╣");
                Console.WriteLine("║  1. Ver todos los vuelos disponibles     ║");
                Console.WriteLine("║  2. Ver vuelos directos desde una ciudad ║");
                Console.WriteLine("║  3. Ver ciudades disponibles             ║");
                Console.WriteLine("║  4. Buscar vuelo más barato (Dijkstra)   ║");
                Console.WriteLine("║  5. Salir                                ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");
                Console.Write("  Opción: ");

                switch (Console.ReadLine()?.Trim())
                {
                    case "1": grafo.MostrarTodosLosVuelos();       break;
                    case "2": OpcionVuelosDesde();                  break;
                    case "3": grafo.MostrarCiudades();              break;
                    case "4": OpcionVueloMasBarato();               break;
                    case "5": salir = true;                         break;
                    default:  Console.WriteLine("  Opción inválida."); break;
                }
            }

            Console.WriteLine("\n  ¡Hasta luego! Buen viaje. ");
        }

        // ─── Menú: vuelos directos ──────────────────────────────────────────
        static void OpcionVuelosDesde()
        {
            grafo.MostrarCiudades();
            Console.Write("\n  Ingrese ciudad de origen: ");
            string ciudad = Console.ReadLine()?.Trim() ?? "";
            grafo.MostrarVuelosDesde(ciudad);
        }

        // ─── Menú: ruta más barata ──────────────────────────────────────────
        static void OpcionVueloMasBarato()
        {
            grafo.MostrarCiudades();
            Console.Write("\n  Ciudad de origen  : ");
            string origen = Console.ReadLine()?.Trim() ?? "";
            Console.Write("  Ciudad de destino : ");
            string destino = Console.ReadLine()?.Trim() ?? "";

            var (costo, ruta) = grafo.VueloMasBarato(origen, destino);

            Console.WriteLine();
            if (costo < 0)
            {
                Console.WriteLine($"   No existe ruta entre '{origen}' y '{destino}'.");
                return;
            }

            Console.WriteLine($"    Ruta más barata encontrada:");
            Console.WriteLine($"    Camino : {string.Join(" → ", ruta ?? new())}");
            Console.WriteLine($"    Costo  : ${costo:F2}");

            // Mostrar desglose de escalas
            if ((ruta?.Count ?? 0) > 2)
                Console.WriteLine($"    Escalas: {ruta!.Count - 2}");
            else
                Console.WriteLine("    Vuelo directo (sin escalas)");
        }

        // ─── Base de datos ficticia de vuelos ───────────────────────────────
        // Los datos simulan rutas latinoamericanas con precios en USD
        static void CargarDatos()
        {
            // Formato: AgregarVuelo(origen, destino, precio)
            grafo.AgregarVuelo("Quito",        "Bogota",      180.00);
            grafo.AgregarVuelo("Quito",        "Lima",        210.00);
            grafo.AgregarVuelo("Quito",        "Guayaquil",    60.00);
            grafo.AgregarVuelo("Guayaquil",    "Lima",        150.00);
            grafo.AgregarVuelo("Guayaquil",    "Bogota",      200.00);
            grafo.AgregarVuelo("Bogota",       "Ciudad Mexico",320.00);
            grafo.AgregarVuelo("Bogota",       "Miami",       390.00);
            grafo.AgregarVuelo("Bogota",       "Lima",        170.00);
            grafo.AgregarVuelo("Lima",         "Santiago",    230.00);
            grafo.AgregarVuelo("Lima",         "Buenos Aires",310.00);
            grafo.AgregarVuelo("Santiago",     "Buenos Aires", 95.00);
            grafo.AgregarVuelo("Santiago",     "Sao Paulo",   280.00);
            grafo.AgregarVuelo("Buenos Aires", "Sao Paulo",   190.00);
            grafo.AgregarVuelo("Sao Paulo",    "Miami",       450.00);
            grafo.AgregarVuelo("Ciudad Mexico","Miami",       220.00);
            grafo.AgregarVuelo("Miami",        "Nueva York",  180.00);
            grafo.AgregarVuelo("Ciudad Mexico","Nueva York",  310.00);
        }
    }
}