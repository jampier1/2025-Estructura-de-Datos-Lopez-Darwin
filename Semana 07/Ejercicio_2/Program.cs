using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("RESOLUCIÓN DEL PROBLEMA DE LAS TORRES DE HANOI\n");

        int discos = 3;

        Stack<int> torreA = new Stack<int>();
        Stack<int> torreB = new Stack<int>();
        Stack<int> torreC = new Stack<int>();

        // Inicializar la torre A
        for (int i = discos; i >= 1; i--)
        {
            torreA.Push(i);
        }

        TorresDeHanoi.Resolver(discos, torreA, torreB, torreC, 'A', 'B', 'C');
    }
}
