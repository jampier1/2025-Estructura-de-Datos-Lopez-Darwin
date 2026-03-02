using System.Collections.Generic;
using System.Threading.Tasks;
using TraductorApp.Core.Models;

namespace TraductorApp.Core.Interfaces
{
    /// <summary>
    /// Define las operaciones de acceso a datos para el diccionario de traducciones.
    /// </summary>
    public interface IDictionaryRepository
    {
        /// <summary>
        /// Obtiene todas las entradas del diccionario de forma asíncrona.
        /// </summary>
        /// <returns>Lista de todas las entradas.</returns>
        Task<List<TranslationEntry>> GetAllAsync();

        /// <summary>
        /// Agrega una nueva entrada al diccionario de forma asíncrona.
        /// </summary>
        /// <param name="entry">La entrada a agregar.</param>
        Task AddAsync(TranslationEntry entry);

        /// <summary>
        /// Guarda los cambios realizados en la lista completa de entradas.
        /// Útil para operaciones que modifican múltiples entradas.
        /// </summary>
        /// <param name="entries">La lista actualizada de entradas.</param>
        Task SaveChangesAsync(List<TranslationEntry> entries);
    }
}

