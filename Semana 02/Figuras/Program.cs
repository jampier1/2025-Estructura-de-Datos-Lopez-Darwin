using System;

class Program
{
    static void Main(string[] args)
    {
        Circulo c = new Circulo(5);
        Console.WriteLine("Área del círculo: " + c.CalcularArea());

        Cuadrado q = new Cuadrado(4);
        Console.WriteLine("Área del cuadrado: " + q.CalcularArea());
    }
}
