using System.Collections.Generic;

namespace Vacunacion.Models  // ← Vacunacion
{
    public class ResultadoVacunacion
    {
        public HashSet<Ciudadano> NoVacunados { get; set; }
        public HashSet<Ciudadano> AmbasDosis { get; set; }
        public HashSet<Ciudadano> SoloPfizer { get; set; }
        public HashSet<Ciudadano> SoloAstraZeneca { get; set; }

        public ResultadoVacunacion()
        {
            NoVacunados = new HashSet<Ciudadano>();
            AmbasDosis = new HashSet<Ciudadano>();
            SoloPfizer = new HashSet<Ciudadano>();
            SoloAstraZeneca = new HashSet<Ciudadano>();
        }
    }
}
