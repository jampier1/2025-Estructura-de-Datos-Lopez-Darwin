using System.Collections.Generic;
using Vacunacion.Models;  // ← Vacunacion.Models

namespace Vacunacion.Services  // ← Vacunacion.Services
{
    public class ServicioAnalisisVacunacion
    {
        public ResultadoVacunacion Analizar(
            HashSet<Ciudadano> todosLosCiudadanos,
            HashSet<Ciudadano> vacunadosPfizer,
            HashSet<Ciudadano> vacunadosAstraZeneca)
        {
            ResultadoVacunacion resultado = new ResultadoVacunacion();

            resultado.NoVacunados = CalcularNoVacunados(
                todosLosCiudadanos, vacunadosPfizer, vacunadosAstraZeneca);

            resultado.AmbasDosis = CalcularAmbasDosis(
                vacunadosPfizer, vacunadosAstraZeneca);

            resultado.SoloPfizer = CalcularSoloPfizer(
                vacunadosPfizer, vacunadosAstraZeneca);

            resultado.SoloAstraZeneca = CalcularSoloAstraZeneca(
                vacunadosPfizer, vacunadosAstraZeneca);

            return resultado;
        }

        private HashSet<Ciudadano> CalcularNoVacunados(
            HashSet<Ciudadano> universo,
            HashSet<Ciudadano> pfizer,
            HashSet<Ciudadano> astraZeneca)
        {
            HashSet<Ciudadano> vacunadosTotal = new HashSet<Ciudadano>(pfizer);
            vacunadosTotal.UnionWith(astraZeneca);
            HashSet<Ciudadano> noVacunados = new HashSet<Ciudadano>(universo);
            noVacunados.ExceptWith(vacunadosTotal);
            return noVacunados;
        }

        private HashSet<Ciudadano> CalcularAmbasDosis(
            HashSet<Ciudadano> pfizer,
            HashSet<Ciudadano> astraZeneca)
        {
            HashSet<Ciudadano> ambasDosis = new HashSet<Ciudadano>(pfizer);
            ambasDosis.IntersectWith(astraZeneca);
            return ambasDosis;
        }

        private HashSet<Ciudadano> CalcularSoloPfizer(
            HashSet<Ciudadano> pfizer,
            HashSet<Ciudadano> astraZeneca)
        {
            HashSet<Ciudadano> soloPfizer = new HashSet<Ciudadano>(pfizer);
            soloPfizer.ExceptWith(astraZeneca);
            return soloPfizer;
        }

        private HashSet<Ciudadano> CalcularSoloAstraZeneca(
            HashSet<Ciudadano> pfizer,
            HashSet<Ciudadano> astraZeneca)
        {
            HashSet<Ciudadano> soloAstraZeneca = new HashSet<Ciudadano>(astraZeneca);
            soloAstraZeneca.ExceptWith(pfizer);
            return soloAstraZeneca;
        }
    }
}
