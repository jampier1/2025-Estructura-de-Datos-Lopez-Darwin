using System;
using System.Collections.Generic;

namespace VuelosBaratos
{
    // Representa una conexión entre dos ciudades (arista del grafo)
    public class Vuelo
    {
        public string Destino { get; set; }
        public double Precio    { get; set; }

        public Vuelo(string destino, double precio)
        {
            Destino = destino;
            Precio  = precio;
        }
    }

    // Grafo dirigido y ponderado que modela la red de vuelos
    public class GrafoVuelos
    {
        // Lista de adyacencia: ciudad → lista de vuelos disponibles
        private Dictionary<string, List<Vuelo>> _adyacencia = new();

        // ─── Operaciones básicas ────────────────────────────────────────────

        // Agrega una ciudad como nodo del grafo
        public void AgregarCiudad(string ciudad)
        {
            if (!_adyacencia.ContainsKey(ciudad))
                _adyacencia[ciudad] = new List<Vuelo>();
        }

        // Agrega un vuelo directo (arista dirigida con peso = precio)
        public void AgregarVuelo(string origen, string destino, double precio)
        {
            AgregarCiudad(origen);
            AgregarCiudad(destino);
            _adyacencia[origen].Add(new Vuelo(destino, precio));
        }

        // ─── Reportería ────────────────────────────────────────────────────

        // Muestra todos los vuelos disponibles en la red
        public void MostrarTodosLosVuelos()
        {

            Console.WriteLine("         RED COMPLETA DE VUELOS           ");


            foreach (var ciudad in _adyacencia)
            {
                if (ciudad.Value.Count == 0) continue;
                foreach (var vuelo in ciudad.Value)
                    Console.WriteLine($"  {ciudad.Key,-15} → {vuelo.Destino,-15}  ${vuelo.Precio:F2}");
            }
        }

        // Muestra los vuelos directos que salen de una ciudad
        public void MostrarVuelosDesde(string origen)
        {
            if (!_adyacencia.ContainsKey(origen))
            {
                Console.WriteLine($"  Ciudad '{origen}' no existe en la red.");
                return;
            }

            Console.WriteLine($"\n  Vuelos directos desde {origen}:");
            if (_adyacencia[origen].Count == 0)
                Console.WriteLine("  (Sin vuelos directos disponibles)");
            else
                foreach (var v in _adyacencia[origen])
                    Console.WriteLine($"    → {v.Destino,-15}  ${v.Precio:F2}");
        }

        // Lista todas las ciudades registradas
        public void MostrarCiudades()
        {
            Console.WriteLine("\n  Ciudades en la red:");
            foreach (var ciudad in _adyacencia.Keys)
                Console.WriteLine($"    • {ciudad}");
        }

        // ─── Algoritmo de Dijkstra ──────────────────────────────────────────

        // Encuentra la ruta más barata entre origen y destino
        // Retorna (costo total, lista de ciudades en el camino)
        public (double costo, List<string>? ruta) VueloMasBarato(string? origen, string? destino)
        {
            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino) ||
                !_adyacencia.ContainsKey(origen) || !_adyacencia.ContainsKey(destino))
                return (-1, null);

            // Distancias mínimas conocidas desde el origen
            var distancia  = new Dictionary<string, double>();
            // Nodo anterior en el camino óptimo (nullable porque el origen no tiene predecesor)
            var predecesor = new Dictionary<string, string?>();
            // Nodos ya procesados
            var visitados  = new HashSet<string>();

            // Inicializar todas las distancias en infinito
            foreach (var ciudad in _adyacencia.Keys)
                distancia[ciudad] = double.MaxValue;

            distancia[origen] = 0;

            // Cola de prioridad simple (lista ordenada)
            var pendientes = new List<string>(_adyacencia.Keys);

            while (pendientes.Count > 0)
            {
                // Tomar el nodo no visitado con menor distancia
                pendientes.Sort((a, b) => distancia[a].CompareTo(distancia[b]));
                string actual = pendientes[0];
                pendientes.RemoveAt(0);

                if (actual == destino) break;
                if (distancia[actual] == double.MaxValue) break; // resto inalcanzable

                // Relajar aristas vecinas
                foreach (var vuelo in _adyacencia[actual])
                {
                    double nuevoCosto = distancia[actual] + vuelo.Precio;
                    if (nuevoCosto < distancia[vuelo.Destino])
                    {
                        distancia[vuelo.Destino]  = nuevoCosto;
                        predecesor[vuelo.Destino] = actual;
                    }
                }
            }

            // Si el destino no fue alcanzado
            if (distancia[destino] == double.MaxValue)
                return (-1, null);

            // Reconstruir la ruta desde destino hacia origen
            var ruta = new List<string>();
            string? paso = destino;
            while (paso != null)
            {
                ruta.Insert(0, paso);
                predecesor.TryGetValue(paso, out paso);
            }

            return (distancia[destino], ruta);
        }
    }
}