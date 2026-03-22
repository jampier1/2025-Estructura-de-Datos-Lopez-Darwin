// ============================================================
//  ARBOL BINARIO DE BUSQUEDA (BST) - C#
//
//  Que hace este programa?
//  Permite guardar numeros en una estructura llamada arbol.
//  Cada numero se coloca automaticamente en el lugar correcto:
//  los menores van a la izquierda y los mayores a la derecha.
//  Esto hace que buscar, insertar o eliminar numeros sea rapido
//  y ordenado. Es una herramienta para aprender estructuras
//  de datos desde consola.
// ============================================================

using System;

// ----------------------------------------------------------
// CLASE NODO
// Es la pieza basica del arbol. Cada nodo guarda un numero
// y dos referencias: una al hijo izquierdo (valores menores)
// y otra al hijo derecho (valores mayores).
// ----------------------------------------------------------
class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor     = valor;
        Izquierdo = null;
        Derecho   = null;
    }
}

// ----------------------------------------------------------
// CLASE BST (Arbol Binario de Busqueda)
// Contiene todas las operaciones del arbol.
// Regla fundamental:
//   - Valores menores van al subarbol izquierdo
//   - Valores mayores van al subarbol derecho
//   - No se permiten duplicados
// ----------------------------------------------------------
class BST
{
    // La raiz es el nodo principal desde donde empieza todo.
    // Si es null significa que el arbol esta vacio.
    private Nodo raiz;

    public BST()
    {
        raiz = null;
    }

    // -------------------------------------------------------
    // INSERTAR
    // Busca la posicion correcta y coloca el nuevo numero.
    // Si el numero ya existe, simplemente lo ignora.
    // -------------------------------------------------------
    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        // Si llegamos a un espacio vacio, aqui va el nuevo nodo
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);
        else
            Console.WriteLine("  [!] El valor " + valor + " ya existe en el arbol.");

        return nodo;
    }

    // -------------------------------------------------------
    // BUSCAR
    // Recorre el arbol comparando en cada paso para decidir
    // si bajar por la izquierda o la derecha. Es rapido
    // porque descarta la mitad del arbol en cada decision.
    // -------------------------------------------------------
    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private bool BuscarRec(Nodo nodo, int valor)
    {
        if (nodo == null)        return false;  // No lo encontro
        if (valor == nodo.Valor) return true;   // Lo encontro
        if (valor < nodo.Valor)  return BuscarRec(nodo.Izquierdo, valor);
        return BuscarRec(nodo.Derecho, valor);
    }

    // -------------------------------------------------------
    // ELIMINAR
    // Hay tres situaciones posibles al borrar un nodo:
    //   1. El nodo no tiene hijos: se elimina directamente
    //   2. El nodo tiene un hijo:  el hijo ocupa su lugar
    //   3. El nodo tiene dos hijos: se reemplaza con el
    //      numero mas pequeno del lado derecho (sucesor)
    // -------------------------------------------------------
    public void Eliminar(int valor)
    {
        if (raiz == null)
        {
            Console.WriteLine("  [!] El arbol esta vacio.");
            return;
        }
        raiz = EliminarRec(raiz, valor);
    }

    private Nodo EliminarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
        {
            Console.WriteLine("  [!] El valor " + valor + " no se encontro.");
            return null;
        }

        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRec(nodo.Derecho, valor);
        else
        {
            // Caso 1 y 2a: no tiene hijo izquierdo
            if (nodo.Izquierdo == null) return nodo.Derecho;

            // Caso 2b: no tiene hijo derecho
            if (nodo.Derecho == null) return nodo.Izquierdo;

            // Caso 3: tiene dos hijos, se busca el sucesor (minimo del lado derecho)
            int sucesor  = MinimoValor(nodo.Derecho);
            nodo.Valor   = sucesor;
            nodo.Derecho = EliminarRec(nodo.Derecho, sucesor);
        }

        return nodo;
    }

    // -------------------------------------------------------
    // RECORRIDOS
    // Son tres formas distintas de visitar todos los nodos:
    //
    // Pre-Order  -> Raiz, Izquierda, Derecha
    //              Util para copiar o guardar el arbol.
    //
    // In-Order   -> Izquierda, Raiz, Derecha
    //              Produce los numeros en orden ascendente.
    //
    // Post-Order -> Izquierda, Derecha, Raiz
    //              Util para eliminar el arbol completamente.
    // -------------------------------------------------------
    public void Preorden()
    {
        Console.Write("  Preorden   (Raiz -> Izq -> Der): ");
        PreordenRec(raiz);
        Console.WriteLine();
    }

    private void PreordenRec(Nodo nodo)
    {
        if (nodo == null) return;
        Console.Write(nodo.Valor + " ");
        PreordenRec(nodo.Izquierdo);
        PreordenRec(nodo.Derecho);
    }

    public void Inorden()
    {
        Console.Write("  Inorden    (ascendente):         ");
        InordenRec(raiz);
        Console.WriteLine();
    }

    private void InordenRec(Nodo nodo)
    {
        if (nodo == null) return;
        InordenRec(nodo.Izquierdo);
        Console.Write(nodo.Valor + " ");
        InordenRec(nodo.Derecho);
    }

    public void Postorden()
    {
        Console.Write("  Postorden  (Izq -> Der -> Raiz): ");
        PostordenRec(raiz);
        Console.WriteLine();
    }

    private void PostordenRec(Nodo nodo)
    {
        if (nodo == null) return;
        PostordenRec(nodo.Izquierdo);
        PostordenRec(nodo.Derecho);
        Console.Write(nodo.Valor + " ");
    }

    // -------------------------------------------------------
    // MINIMO Y MAXIMO
    // En un BST el numero mas pequeno siempre esta en el
    // extremo izquierdo y el mas grande en el extremo derecho.
    // -------------------------------------------------------
    public void MostrarMinimo()
    {
        if (raiz == null) { Console.WriteLine("  [!] El arbol esta vacio."); return; }
        Console.WriteLine("  Minimo: " + MinimoValor(raiz));
    }

    private int MinimoValor(Nodo nodo)
    {
        // Bajar siempre por la izquierda hasta no poder mas
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;
        return nodo.Valor;
    }

    public void MostrarMaximo()
    {
        if (raiz == null) { Console.WriteLine("  [!] El arbol esta vacio."); return; }
        Nodo actual = raiz;
        // Bajar siempre por la derecha hasta no poder mas
        while (actual.Derecho != null)
            actual = actual.Derecho;
        Console.WriteLine("  Maximo: " + actual.Valor);
    }

    // -------------------------------------------------------
    // ALTURA
    // La altura indica cuantos niveles tiene el arbol.
    // Se calcula bajando por ambos lados y tomando el mayor.
    // Un arbol vacio tiene altura 0, un solo nodo altura 1.
    // -------------------------------------------------------
    public void MostrarAltura()
    {
        Console.WriteLine("  Altura del arbol: " + AlturaRec(raiz));
    }

    private int AlturaRec(Nodo nodo)
    {
        if (nodo == null) return 0;
        return 1 + Math.Max(AlturaRec(nodo.Izquierdo), AlturaRec(nodo.Derecho));
    }

    // -------------------------------------------------------
    // LIMPIAR
    // Elimina todos los nodos del arbol de una sola vez
    // dejando la raiz en null. C# libera la memoria solo.
    // -------------------------------------------------------
    public void Limpiar()
    {
        raiz = null;
        Console.WriteLine("  Arbol limpiado exitosamente.");
    }

    public bool EstaVacio => raiz == null;
}

// ----------------------------------------------------------
// PROGRAMA PRINCIPAL
// Muestra un menu en consola y ejecuta la operacion
// que el usuario elija.
// ----------------------------------------------------------
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        BST arbol = new BST();
        bool salir = false;

        while (!salir)
        {
            MostrarMenu();
            string opcion = Console.ReadLine().Trim();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("  Ingrese valor a insertar: ");
                    if (int.TryParse(Console.ReadLine(), out int valIns))
                    {
                        arbol.Insertar(valIns);
                        Console.WriteLine("  Valor " + valIns + " insertado correctamente.");
                    }
                    else
                        Console.WriteLine("  [!] Valor invalido, ingrese un numero entero.");
                    break;

                case "2":
                    Console.Write("  Ingrese valor a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out int valBus))
                    {
                        bool encontrado = arbol.Buscar(valBus);
                        if (encontrado)
                            Console.WriteLine("  El valor " + valBus + " SI existe en el arbol.");
                        else
                            Console.WriteLine("  El valor " + valBus + " NO existe en el arbol.");
                    }
                    else
                        Console.WriteLine("  [!] Valor invalido, ingrese un numero entero.");
                    break;

                case "3":
                    if (arbol.EstaVacio)
                    {
                        Console.WriteLine("  [!] El arbol esta vacio.");
                        break;
                    }
                    Console.Write("  Ingrese valor a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int valElim))
                        arbol.Eliminar(valElim);
                    else
                        Console.WriteLine("  [!] Valor invalido, ingrese un numero entero.");
                    break;

                case "4":
                    if (arbol.EstaVacio)
                    {
                        Console.WriteLine("  [!] El arbol esta vacio.");
                        break;
                    }
                    arbol.Preorden();
                    arbol.Inorden();
                    arbol.Postorden();
                    break;

                case "5":
                    if (arbol.EstaVacio)
                    {
                        Console.WriteLine("  [!] El arbol esta vacio.");
                        break;
                    }
                    arbol.MostrarMinimo();
                    arbol.MostrarMaximo();
                    arbol.MostrarAltura();
                    break;

                case "6":
                    arbol.Limpiar();
                    break;

                case "0":
                    salir = true;
                    Console.WriteLine("  Hasta luego.");
                    break;

                default:
                    Console.WriteLine("  [!] Opcion no valida, intente de nuevo.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine();
                Console.Write("  Presione ENTER para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("  ARBOL BINARIO DE BUSQUEDA (BST)");
        Console.WriteLine();
        Console.WriteLine("  1. Insertar valor");
        Console.WriteLine("  2. Buscar valor");
        Console.WriteLine("  3. Eliminar valor");
        Console.WriteLine("  4. Recorridos (Preorden / Inorden / Postorden)");
        Console.WriteLine("  5. Minimo, Maximo y Altura");
        Console.WriteLine("  6. Limpiar arbol");
        Console.WriteLine("  0. Salir");
        Console.WriteLine();
        Console.Write("  Seleccione una opcion: ");
    }
}