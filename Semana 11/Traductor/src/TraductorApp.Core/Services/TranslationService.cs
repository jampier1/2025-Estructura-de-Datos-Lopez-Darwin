using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraductorApp.Core.Interfaces;
using TraductorApp.Core.Models;

namespace TraductorApp.Core.Services
{
    /// <summary>
    /// Servicio de negocio para traducir frases de español a inglés.
    /// </summary>
    public class TranslationService : ITranslationService
    {
        private readonly IDictionaryService _dictionaryService;

        public TranslationService(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService ?? throw new ArgumentNullException(nameof(dictionaryService));
        }

        /// <inheritdoc />
        public async Task<string> TranslatePhraseAsync(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return phrase;

            // Separar la frase en palabras (considerando espacios)
            var words = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var dictionary = await _dictionaryService.GetAllEntriesAsync();
            var result = new StringBuilder();

            foreach (var word in words)
            {
                // Limpiar la palabra de signos de puntuación para buscar
                var cleanWord = new string(word.Where(char.IsLetter).ToArray()).ToLower();
                var punctuation = word.Where(c => !char.IsLetter(c)).ToArray();

                // Buscar la palabra en español en todas las entradas del diccionario
                var entry = dictionary.FirstOrDefault(e => 
                    e.SpanishTranslations.Any(t => t.Equals(cleanWord, StringComparison.OrdinalIgnoreCase)));

                if (entry != null)
                {
                    // Devolver la palabra en inglés
                    result.Append(entry.EnglishWord);
                }
                else
                {
                    // Mantener la palabra original si no está en el diccionario
                    result.Append(word);
                }

                // Agregar los signos de puntuación que tenía la palabra original
                if (punctuation.Length > 0)
                {
                    result.Append(new string(punctuation));
                }

                result.Append(' ');
            }

            return result.ToString().Trim();
        }
    }
}
