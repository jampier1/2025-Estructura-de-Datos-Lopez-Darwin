using System;

class ListaEnlazada
{
    private Nodo cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Insertar por el inicio (como pide el enunciado)
    public void InsertarInicio(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        nuevo.Siguiente = cabeza;
        cabeza = nuevo;
    }

    // Contar elementos
    public int Contar()
    {
        int contador = 0;
        Nodo actual = cabeza;

        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }

        return contador;
    }

    // Comparar contenido y orden
    public bool EsIgual(ListaEnlazada otra)
    {
        Nodo actual1 = this.cabeza;
        Nodo actual2 = otra.cabeza;

        while (actual1 != null && actual2 != null)
        {
            if (actual1.Dato != actual2.Dato)
                return false;

            actual1 = actual1.Siguiente;
            actual2 = actual2.Siguiente;
        }

        return actual1 == null && actual2 == null;
    }

    public void Mostrar()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }
}
