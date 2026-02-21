using System;
using System.Collections.Generic;
using Vacunacion.Models;     // ← Vacunacion.Models
using Vacunacion.Services;   // ← Vacunacion.Services
using Vacunacion.Utils;      // ← Vacunacion.Utils

namespace Vacunacion  // ← Vacunacion
{
    class Program
    {
        private const int TOTAL_CIUDADANOS = 500;
        private const int TOTAL_VACUNADOS_PFIZER = 75;
        private const int TOTAL_VACUNADOS_ASTRAZENECA = 75;

        static void Main(string[] args)
        {
            try
            {
                GeneradorReportes.MostrarEncabezado();

                var conjuntos = GenerarDatosFicticios();

                GeneradorReportes.MostrarInformacionInicial(
                    conjuntos.TodosLosCiudadanos.Count,
                    conjuntos.VacunadosPfizer.Count,
                    conjuntos.VacunadosAstraZeneca.Count);

                ResultadoVacunacion resultado = AnalizarDatos(conjuntos);

                GeneradorReportes.MostrarResultados(resultado);

                GeneradorReportes.MostrarEstadisticas(
                    conjuntos.TodosLosCiudadanos.Count,
                    resultado);

                GeneradorReportes.MostrarPieDePagina();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error: {ex.Message}");
                Console.WriteLine($"Detalles: {ex.StackTrace}");
                Console.ReadKey();
            }
        }

        private static ConjuntosDatos GenerarDatosFicticios()
        {
            HashSet<Ciudadano> todosLosCiudadanos = GeneradorCiudadanos.Generar(TOTAL_CIUDADANOS);
            HashSet<Ciudadano> vacunadosPfizer = GeneradorCiudadanos.GenerarSubconjuntoAleatorio(todosLosCiudadanos, TOTAL_VACUNADOS_PFIZER);
            HashSet<Ciudadano> vacunadosAstraZeneca = GeneradorCiudadanos.GenerarSubconjuntoAleatorio(todosLosCiudadanos, TOTAL_VACUNADOS_ASTRAZENECA);

            return new ConjuntosDatos
            {
                TodosLosCiudadanos = todosLosCiudadanos,
                VacunadosPfizer = vacunadosPfizer,
                VacunadosAstraZeneca = vacunadosAstraZeneca
            };
        }

        private static ResultadoVacunacion AnalizarDatos(ConjuntosDatos conjuntos)
        {
            ServicioAnalisisVacunacion servicio = new ServicioAnalisisVacunacion();
            return servicio.Analizar(conjuntos.TodosLosCiudadanos, conjuntos.VacunadosPfizer, conjuntos.VacunadosAstraZeneca);
        }

        private class ConjuntosDatos
        {
            public HashSet<Ciudadano> TodosLosCiudadanos { get; set; }
            public HashSet<Ciudadano> VacunadosPfizer { get; set; }
            public HashSet<Ciudadano> VacunadosAstraZeneca { get; set; }
        }
    }
}