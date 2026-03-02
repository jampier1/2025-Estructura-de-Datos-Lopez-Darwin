using System.Collections.Generic;
using System.Threading.Tasks;
using TraductorApp.Core.Models;

namespace TraductorApp.Core.Interfaces
{
    /// <summary>
    /// Define las operaciones de negocio para la gestión del diccionario.
    /// </summary>
    public interface IDictionaryService
    {
        /// <summary>
        /// Obtiene todas las entradas del diccionario.
        /// </summary>
        Task<List<TranslationEntry>> GetAllEntriesAsync();

        /// <summary>
        /// Agrega una nueva palabra al diccionario.
        /// </summary>
        /// <param name="englishWord">Palabra en inglés.</param>
        /// <param name="spanishTranslations">Lista de traducciones al español.</param>
        /// <returns>True si se agregó correctamente, False si ya existía.</returns>
        Task<bool> AddWordAsync(string englishWord, List<string> spanishTranslations);

        /// <summary>
        /// Busca una entrada por su palabra en inglés.
        /// </summary>
        /// <param name="englishWord">Palabra a buscar.</param>
        /// <returns>La entrada si existe, null en caso contrario.</returns>
        Task<TranslationEntry?> FindByEnglishWordAsync(string englishWord);
    }
}
