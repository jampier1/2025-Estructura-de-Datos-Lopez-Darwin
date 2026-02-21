using System;
using System.Collections.Generic;
using Vacunacion.Models;  // ← Vacunacion.Models

namespace Vacunacion.Utils  // ← Vacunacion.Utils
{
    public class GeneradorCiudadanos
    {
        public static HashSet<Ciudadano> Generar(int cantidad)
        {
            HashSet<Ciudadano> ciudadanos = new HashSet<Ciudadano>();
            
            for (int i = 1; i <= cantidad; i++)
            {
                string id = i.ToString("D3");
                string nombre = $"Ciudadano {id}";
                ciudadanos.Add(new Ciudadano(id, nombre));
            }
            
            return ciudadanos;
        }

        public static HashSet<Ciudadano> GenerarSubconjuntoAleatorio(
            HashSet<Ciudadano> conjuntoOriginal, 
            int cantidad)
        {
            if (cantidad > conjuntoOriginal.Count)
            {
                throw new ArgumentException(
                    "La cantidad solicitada excede el tamaño del conjunto original");
            }

            Random random = new Random(Guid.NewGuid().GetHashCode());
            List<Ciudadano> lista = new List<Ciudadano>(conjuntoOriginal);
            HashSet<Ciudadano> subconjunto = new HashSet<Ciudadano>();

            while (subconjunto.Count < cantidad && lista.Count > 0)
            {
                int indice = random.Next(lista.Count);
                subconjunto.Add(lista[indice]);
                lista.RemoveAt(indice);
            }

            return subconjunto;
        }
    }
}
