using System.Threading.Tasks;

namespace TraductorApp.Core.Interfaces
{
    /// <summary>
    /// Define el servicio de traducción de frases.
    /// </summary>
    public interface ITranslationService
    {
        /// <summary>
        /// Traduce una frase del inglés al español utilizando el diccionario disponible.
        /// </summary>
        /// <param name="phrase">Frase a traducir.</param>
        /// <returns>Frase traducida con las palabras conocidas reemplazadas.</returns>
        Task<string> TranslatePhraseAsync(string phrase);
    }
}
