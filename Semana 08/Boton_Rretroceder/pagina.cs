using System;

namespace NavegadorWeb
{
    class Pagina
    {
        public string Url { get; }
        public string Titulo { get; }
        public DateTime Visitada { get; }

        public Pagina(string url, string titulo)
        {
            Url = url;
            Titulo = titulo;
            Visitada = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Titulo} ({Url}) - {Visitada:HH:mm:ss}";
        }
    }
}
