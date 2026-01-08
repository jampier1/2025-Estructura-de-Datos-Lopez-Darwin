/*
Escribir un programa que almacene en una lista 
los números del 1 al 10 y los muestre por pantalla 
en orden inverso separados por comas.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();

        // Almacenar números del 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }

        // Mostrar en orden inverso separados por comas
        for (int i = numeros.Count - 1; i >= 0; i--)
        {
            Console.Write(numeros[i]);

            if (i > 0)
            {
                Console.Write(", ");
            }
        }
    }
}
