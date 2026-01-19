using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Método que resuelve el problema de las Torres de Hanoi
    public static void Resolver(
        int n,
        Stack<int> origen,
        Stack<int> auxiliar,
        Stack<int> destino,
        char o,
        char a,
        char d)
    {
        if (n > 0)
        {
            // Mover n-1 discos al auxiliar
            Resolver(n - 1, origen, destino, auxiliar, o, d, a);

            // Mover el disco superior
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {o} a {d}");

            // Mover los n-1 discos al destino
            Resolver(n - 1, auxiliar, origen, destino, a, o, d);
        }
    }
}
