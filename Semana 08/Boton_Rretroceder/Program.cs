using System;
using NavegadorWeb;

class Program
{
    static void Main()
    {
        var navegador = new Navegador();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("1. Visitar página");
            Console.WriteLine("2. Retroceder ◄");
            Console.WriteLine("3. Ver historial");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("URL: ");
                    string url = Console.ReadLine();
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();

                    navegador.VisitarPagina(url, titulo);
                    Console.WriteLine($"Página actual: {navegador.PaginaActual.Titulo}\n");
                    break;

                case "2":
                    if (navegador.Retroceder())
                        Console.WriteLine($"Página actual: {navegador.PaginaActual.Titulo}\n");
                    else
                        Console.WriteLine("No hay páginas anteriores\n");
                    break;

                case "3":
                    Console.WriteLine("Historial:");
                    foreach (var pagina in navegador.ObtenerHistorial())
                        Console.WriteLine($"- {pagina}");
                    Console.WriteLine();
                    break;

                case "0":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción inválida\n");
                    break;
            }
        }
    }
}

