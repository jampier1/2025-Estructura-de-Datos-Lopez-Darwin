/*
Invertir una lista 
Invertir una lista enlazada: 
Implementar un método dentro de la Implementar un método dentro de la lista 
enlazada q lista enlazada que permita invertir los datos ue permita invertir los datos
almacenados en una lista enlazada, es decir que almacenados en una lista enlazada, es decir 
que el primer elemento pase a ser el último y el primer elemento pase a ser el último y el
último pase a ser el primero, que el segundo sea el penúltimo y el penúltimo pase a ser el
segundo y así segundo y así sucesivamente.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        lista.Insertar(1);
        lista.Insertar(2);
        lista.Insertar(3);
        lista.Insertar(4);
        lista.Insertar(5);

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        lista.Invertir();

        Console.WriteLine("Lista invertida:");
        lista.Mostrar();
    }
}
