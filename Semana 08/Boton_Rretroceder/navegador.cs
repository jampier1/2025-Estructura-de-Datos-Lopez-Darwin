using System.Collections.Generic;

namespace NavegadorWeb
{
    class Navegador
    {
        private Stack<Pagina> historial = new Stack<Pagina>();
        public Pagina PaginaActual { get; private set; }

        public void VisitarPagina(string url, string titulo)
        {
            if (PaginaActual != null)
                historial.Push(PaginaActual);

            PaginaActual = new Pagina(url, titulo);
        }

        public bool PuedeRetroceder()
        {
            return historial.Count > 0;
        }

        public bool Retroceder()
        {
            if (!PuedeRetroceder())
                return false;

            PaginaActual = historial.Pop();
            return true;
        }

        public IEnumerable<Pagina> ObtenerHistorial()
        {
            return historial;
        }

        public int CantidadHistorial => historial.Count;
    }
}
