/*
Escribir un programa que pregunte al usuario los números
ganadores de la lotería primitiva, los almacene en una 
lista y los muestre por pantalla ordenados de menor a mayor.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();

        Console.WriteLine("Introduce los 6 números ganadores de la lotería primitiva:");

        while (numeros.Count < 6)
        {
            Console.Write($"Número {numeros.Count + 1}: ");
            bool valido = int.TryParse(Console.ReadLine(), out int numero);

            if (!valido)
            {
                Console.WriteLine("❌ Entrada no válida. Debes ingresar un número entero.");
                continue;
            }

            numeros.Add(numero);
        }

        // Ordenar de menor a mayor
        numeros.Sort();

        Console.WriteLine("\nNúmeros ordenados de menor a mayor:");
        foreach (int n in numeros)
        {
            Console.Write(n + " ");
        }
    }
}
