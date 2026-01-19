using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("VERIFICACIÓN DE PARÉNTESIS BALANCEADOS\n");

        string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";

        bool resultado = BalanceoParentesis.Verificar(expresion);

        if (resultado)
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula NO balanceada.");
    }
}

