using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaSimpleDos
{
    public class Libro
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public HashSet<string> Categorias { get; set; } = new HashSet<string>();

        public override string ToString()
        {
            return $"{Codigo} | {Titulo} | {Autor} | {Anio} | {string.Join(", ", Categorias)}";
        }
    }

    public class Biblioteca
    {
        // Diccionario: clave = código del libro, valor = objeto Libro
        private Dictionary<string, Libro> libros = new Dictionary<string, Libro>();
        
        // Conjunto: almacena todas las categorías sin duplicados
        private HashSet<string> categorias = new HashSet<string>();

        // Agregar un libro
        public string AgregarLibro(string codigo, string titulo, string autor, int anio, string[] categoriasIngresadas)
        {
            if (libros.ContainsKey(codigo))
                return "Error: Ya existe un libro con ese código.";

            var libro = new Libro
            {
                Codigo = codigo,
                Titulo = titulo,
                Autor = autor,
                Anio = anio
            };

            foreach (var cat in categoriasIngresadas)
            {
                string catTrim = cat.Trim();
                if (!string.IsNullOrEmpty(catTrim))
                {
                    libro.Categorias.Add(catTrim);
                    categorias.Add(catTrim); // al conjunto global
                }
            }

            libros[codigo] = libro;
            return "Libro agregado correctamente.";
        }

        // Buscar libro por código (retorna el libro o null)
        public Libro BuscarPorCodigo(string codigo)
        {
            libros.TryGetValue(codigo, out Libro libro);
            return libro;
        }

        // Listar todos los libros
        public List<Libro> ListarTodos()
        {
            return libros.Values.ToList();
        }

        // Buscar libros por categoría
        public List<Libro> BuscarPorCategoria(string categoria)
        {
            return libros.Values.Where(l => l.Categorias.Contains(categoria)).ToList();
        }

        // Obtener todas las categorías (ordenadas)
        public List<string> ObtenerCategorias()
        {
            return categorias.OrderBy(c => c).ToList();
        }
    }
}