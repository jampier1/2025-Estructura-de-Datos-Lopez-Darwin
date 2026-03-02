using System.Collections.Generic;

namespace TraductorApp.Core.Models
{
    /// <summary>
    /// Representa una entrada del diccionario con la palabra en inglés
    /// y sus posibles traducciones al español.
    /// </summary>
    public class TranslationEntry
    {
        /// <summary>
        /// Palabra en inglés.
        /// </summary>
        public string EnglishWord { get; set; } = string.Empty;

        /// <summary>
        /// Lista de traducciones al español.
        /// Puede contener una o más variantes.
        /// </summary>
        public List<string> SpanishTranslations { get; set; } = new();
    }
}

