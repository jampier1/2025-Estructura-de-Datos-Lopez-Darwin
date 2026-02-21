using System;
using System.Collections.Generic;
using System.Linq;
using Vacunacion.Models;  // ← Vacunacion.Models

namespace Vacunacion.Utils  // ← Vacunacion.Utils
{
    public class GeneradorReportes
    {
        public static void MostrarEncabezado()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("SISTEMA DE GESTIÓN DE VACUNACIÓN COVID-19");
            Console.WriteLine("Ministerio de Salud - Gobierno Nacional");
            Console.WriteLine("==============================================\n");
        }

        public static void MostrarInformacionInicial(
            int totalCiudadanos,
            int totalPfizer,
            int totalAstraZeneca)
        {
            Console.WriteLine($"Total de ciudadanos registrados: {totalCiudadanos}");
            Console.WriteLine($"Ciudadanos vacunados con Pfizer: {totalPfizer}");
            Console.WriteLine($"Ciudadanos vacunados con AstraZeneca: {totalAstraZeneca}\n");
        }

        public static void MostrarResultados(ResultadoVacunacion resultado)
        {
            MostrarListado("LISTADO 1: CIUDADANOS NO VACUNADOS", resultado.NoVacunados, 20);
            MostrarListado("LISTADO 2: CIUDADANOS CON AMBAS DOSIS", resultado.AmbasDosis, 20);
            MostrarListado("LISTADO 3: CIUDADANOS SOLO CON PFIZER", resultado.SoloPfizer, 20);
            MostrarListado("LISTADO 4: CIUDADANOS SOLO CON ASTRAZENECA", resultado.SoloAstraZeneca, 20);
        }

        private static void MostrarListado(string titulo, HashSet<Ciudadano> ciudadanos, int limite)
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine(titulo);
            Console.WriteLine($"Total: {ciudadanos.Count} ciudadanos");
            Console.WriteLine("==============================================");

            if (ciudadanos.Count == 0)
            {
                Console.WriteLine("  (Ninguno)");
                return;
            }

            var ordenados = ciudadanos.OrderBy(c => c.Id).ToList();
            int mostrar = limite > 0 && ordenados.Count > limite ? limite : ordenados.Count;

            for (int i = 0; i < mostrar; i++)
            {
                Console.WriteLine($"  • {ordenados[i].Nombre}");
            }

            if (ordenados.Count > mostrar)
            {
                Console.WriteLine($"  ... y {ordenados.Count - mostrar} más");
            }
        }

        public static void MostrarEstadisticas(int totalCiudadanos, ResultadoVacunacion resultado)
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("ESTADÍSTICAS DE LA CAMPAÑA");
            Console.WriteLine("==============================================");

            int noVacunados = resultado.NoVacunados.Count;
            int ambasDosis = resultado.AmbasDosis.Count;
            int soloPfizer = resultado.SoloPfizer.Count;
            int soloAstra = resultado.SoloAstraZeneca.Count;

            Console.WriteLine($"Total de ciudadanos:           {totalCiudadanos}");
            Console.WriteLine($"No vacunados:                  {noVacunados} ({noVacunados * 100.0 / totalCiudadanos:F2}%)");
            Console.WriteLine($"Con ambas dosis:               {ambasDosis} ({ambasDosis * 100.0 / totalCiudadanos:F2}%)");
            Console.WriteLine($"Solo Pfizer:                   {soloPfizer} ({soloPfizer * 100.0 / totalCiudadanos:F2}%)");
            Console.WriteLine($"Solo AstraZeneca:              {soloAstra} ({soloAstra * 100.0 / totalCiudadanos:F2}%)");

            int vacunados = totalCiudadanos - noVacunados;
            Console.WriteLine($"\nTotal vacunados (al menos 1): {vacunados} ({vacunados * 100.0 / totalCiudadanos:F2}%)");
            Console.WriteLine("==============================================");

            VerificarParticion(totalCiudadanos, noVacunados, ambasDosis, soloPfizer, soloAstra);
        }

        private static void VerificarParticion(int total, int noVacunados, int ambasDosis, int soloPfizer, int soloAstraZeneca)
        {
            Console.WriteLine("\n[VERIFICACIÓN DE TEORÍA DE CONJUNTOS]");
            int suma = noVacunados + soloPfizer + soloAstraZeneca + ambasDosis;
            Console.WriteLine($"No vacunados + Solo Pfizer + Solo AstraZeneca + Ambas dosis = {suma}");
            Console.WriteLine($"Total de ciudadanos = {total}");

            if (suma == total)
            {
                Console.WriteLine("✓ Los conjuntos son disjuntos y completos (partición correcta)");
            }
            else
            {
                Console.WriteLine("✗ Error en la partición de conjuntos");
            }
        }

        public static void MostrarPieDePagina()
        {
            Console.WriteLine("\n\nPresione cualquier tecla para salir...");
        }
    }
}
