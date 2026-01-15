using System;

/*
Ejercicio 09:
Crear un programa que maneje N° cantidad de datos de tipo entero en dos listas por el inicio.
Debe existir un ciclo de carga para la primera lista y otro ciclo de carga para la a y otro
ciclo de carga para la segunda lista. segunda lista.
Una vez cargados los datos en las listas, el programa debe comparar las dos listas para
verificar si ambas listas son iguales en verificar si ambas listas son iguales en 
tamaño y c tamaño y contenido, es decir que si tienen la misma ontenido, es decir que si tienen la misma
cantidad de datos y si los datos están cargados en el mismo orden. Una vez realizada, la
verificación. El programa debe mostrar:
a. Si las listas son Si las listas son iguales en tamaño y en iguales en tamaño y en contenido. contenido.
b. Si las listas son Si las listas son iguales en tamaño pero no en iguales en tamaño pero no en contenido. contenido.
c. No tienen el mismo tamaño ni No tienen el mismo tamaño ni contenido. contenido.
*/

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista1 = new ListaEnlazada();
        ListaEnlazada lista2 = new ListaEnlazada();

        // Carga de datos (puedes cambiar valores)
        lista1.InsertarInicio(3);
        lista1.InsertarInicio(2);
        lista1.InsertarInicio(1);

        lista2.InsertarInicio(3);
        lista2.InsertarInicio(5);
        lista2.InsertarInicio(1);

        Console.WriteLine("Lista 1:");
        lista1.Mostrar();

        Console.WriteLine("Lista 2:");
        lista2.Mostrar();

        int tam1 = lista1.Contar();
        int tam2 = lista2.Contar();

        if (tam1 == tam2 && lista1.EsIgual(lista2))
        {
            Console.WriteLine("Las listas son iguales en tamaño y contenido.");
        }
        else if (tam1 == tam2)
        {
            Console.WriteLine("Las listas son iguales en tamaño pero no en contenido.");
        }
        else
        {
            Console.WriteLine("Las listas no tienen el mismo tamaño ni contenido.");
        }
    }
}
