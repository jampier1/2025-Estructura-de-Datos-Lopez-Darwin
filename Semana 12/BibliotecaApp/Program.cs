using System;
using System.Linq;

namespace BibliotecaSimpleDos
{
    class Program
    {
        static Biblioteca biblioteca = new Biblioteca();

        static void Main()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== BIBLIOTECA ===\n");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Buscar por código");
                Console.WriteLine("3. Listar todos los libros");
                Console.WriteLine("4. Buscar por categoría");
                Console.WriteLine("5. Ver todas las categorías");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": AgregarLibro(); break;
                    case "2": BuscarPorCodigo(); break;
                    case "3": ListarTodos(); break;
                    case "4": BuscarPorCategoria(); break;
                    case "5": VerCategorias(); break;
                    case "6": salir = true; break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausa();
                        break;
                }
            }
        }

        static void AgregarLibro()
        {
            Console.Clear();
            Console.WriteLine("--- NUEVO LIBRO ---\n");
            Console.Write("Código: ");
            string codigo = Console.ReadLine();
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Año: ");
            if (!int.TryParse(Console.ReadLine(), out int anio))
            {
                Console.WriteLine("Año inválido.");
                Pausa();
                return;
            }
            Console.Write("Categorías (separadas por coma): ");
            string catInput = Console.ReadLine();
            string[] categorias = catInput.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                          .Select(c => c.Trim()).ToArray();

            string resultado = biblioteca.AgregarLibro(codigo, titulo, autor, anio, categorias);
            Console.WriteLine(resultado);
            Pausa();
        }

        static void BuscarPorCodigo()
        {
            Console.Clear();
            Console.Write("Ingrese el código del libro: ");
            string codigo = Console.ReadLine();
            var libro = biblioteca.BuscarPorCodigo(codigo);
            if (libro != null)
                Console.WriteLine("\n" + libro);
            else
                Console.WriteLine("No se encontró el libro.");
            Pausa();
        }

        static void ListarTodos()
        {
            Console.Clear();
            var libros = biblioteca.ListarTodos();
            if (libros.Any())
            {
                Console.WriteLine("--- LISTADO COMPLETO ---\n");
                foreach (var l in libros)
                    Console.WriteLine(l);
            }
            else
            {
                Console.WriteLine("No hay libros registrados.");
            }
            Pausa();
        }

        static void BuscarPorCategoria()
        {
            Console.Clear();
            Console.Write("Ingrese la categoría: ");
            string cat = Console.ReadLine();
            var libros = biblioteca.BuscarPorCategoria(cat);
            if (libros.Any())
            {
                Console.WriteLine($"\nLibros en '{cat}':");
                foreach (var l in libros)
                    Console.WriteLine($"- {l.Titulo} (Código: {l.Codigo})");
            }
            else
            {
                Console.WriteLine("No hay libros en esa categoría.");
            }
            Pausa();
        }

        static void VerCategorias()
        {
            Console.Clear();
            var cats = biblioteca.ObtenerCategorias();
            if (cats.Any())
            {
                Console.WriteLine("--- CATEGORÍAS ---\n");
                foreach (var c in cats)
                    Console.WriteLine($"- {c}");
            }
            else
            {
                Console.WriteLine("No hay categorías registradas.");
            }
            Pausa();
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
