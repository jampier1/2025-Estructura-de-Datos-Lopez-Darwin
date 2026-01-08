/*
Escribir un programa que almacene las asignaturas de un curso 
(por ejemplo Matemáticas, Física, Química, Historia y Lengua) 
en una lista, pregunte al usuario la nota que ha sacado en 
cada asignatura, y después las muestre por pantalla 
con el mensaje En <asignatura> has sacado <nota> donde <asignatura> 
es cada una des las asignaturas de la lista y <nota> cada una de 
las correspondientes notas introducidas por el usuario.
*/

using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    class Asignatura
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }

        public Asignatura(string nombre)
        {
            Nombre = nombre;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Asignatura> asignaturas = new List<Asignatura>
            {
                new Asignatura("Estructura de Datos"),
                new Asignatura("Fundamentos de Sistemas Digitales"),
                new Asignatura("Instalaciones Electricas y Cableado Estructurado"),
                new Asignatura("Metodologia de la Investigacion"),
                new Asignatura("Administracion de Sistemas Operativos")
            };

            foreach (Asignatura a in asignaturas)
            {
                double nota;
                bool valido;

                do
                {
                    Console.Write($"Ingresa la nota de {a.Nombre}: ");
                    valido = double.TryParse(Console.ReadLine(), out nota);

                    if (!valido)
                    {
                        Console.WriteLine("Entrada no válida. Ingresa un número.");
                    }

                } while (!valido);

                a.Nota = nota;
            }

            Console.WriteLine("\nResultados:");

            foreach (Asignatura a in asignaturas)
            {
                Console.WriteLine($"En {a.Nombre} has sacado {a.Nota}");
            }
        }
    }
}
