using System;

namespace Vacunacion.Models  // ← Debe ser Vacunacion, NO CampanaVacunacion
{
    public class Ciudadano
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public Ciudadano(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object? obj)  // ← Agrega el ? para evitar el warning
        {
            if (obj is Ciudadano otro)
            {
                return Id == otro.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}