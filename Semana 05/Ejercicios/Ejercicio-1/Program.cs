/*
Escribir un programa que almacene las asignaturas de un curso 
(por ejemplo Matemáticas, Física, Química, Historia y Lengua) 
en una lista y la muestre por pantalla.
*/

using System;
using System.Collections.Generic;

namespace GestionCurso
{
    // 1. Definimos la Clase que representará el Curso
    public class Curso
    {
        // Propiedad para almacenar la lista de asignaturas
        private List<string> _asignaturas;

        // Constructor: Inicializa la lista y añade las materias
        public Curso()
        {
            _asignaturas = new List<string> 
            { 
                "Metodologia de la investigación", 
                "Fundamentos de Sistemas Digitales", 
                "Estructura de Datos", 
                "Instalaciones electricas y cableado estructurado", 
                "Administraación de Sistemas Operativos " 
            };
        }

        // Método para mostrar las asignaturas por pantalla
        public void MostrarAsignaturas()
        {
            Console.WriteLine("--- Lista de Asignaturas del Curso ---");
            foreach (string materia in _asignaturas)
            {
                Console.WriteLine($"- {materia}");
            }
        }
    }

    // 2. Clase Principal para ejecutar el programa
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos el objeto 'miCurso' de la clase Curso
            Curso miCurso = new Curso();

            // Llamamos al método para mostrar la información
            miCurso.MostrarAsignaturas();

            // Evitar que la consola se cierre inmediatamente
            Console.WriteLine("\nPresione cualquier tecla para salir");
            Console.ReadKey();
        }
    }
}
