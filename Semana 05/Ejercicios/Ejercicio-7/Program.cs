/*
Escribir un programa que almacene el abecedario 
en una lista, elimine de la lista las letras que 
ocupen posiciones múltiplos de 3, y muestre por pantalla la lista resultante.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<char> abecedario = new List<char>();

        // Llenar la lista con el abecedario (A-Z)
        for (char letra = 'A'; letra <= 'Z'; letra++)
        {
            abecedario.Add(letra);
        }

        // Eliminar letras en posiciones múltiplos de 3 (desde el final)
        for (int i = abecedario.Count; i >= 1; i--)
        {
            if (i % 3 == 0)
            {
                abecedario.RemoveAt(i - 1);
            }
        }

        // Mostrar resultado
        Console.WriteLine("Abecedario resultante:");
        foreach (char letra in abecedario)
        {
            Console.Write(letra + " ");
        }
    }
}
