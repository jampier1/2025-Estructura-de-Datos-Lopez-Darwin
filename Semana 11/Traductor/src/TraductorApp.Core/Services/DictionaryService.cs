using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraductorApp.Core.Interfaces;
using TraductorApp.Core.Models;

namespace TraductorApp.Core.Services
{
    /// <summary>
    /// Servicio de negocio para gestionar el diccionario.
    /// </summary>
    public class DictionaryService : IDictionaryService
    {
        private readonly IDictionaryRepository _repository;

        public DictionaryService(IDictionaryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <inheritdoc />
        public async Task<List<TranslationEntry>> GetAllEntriesAsync()
        {
            return await _repository.GetAllAsync();
        }

        /// <inheritdoc />
        public async Task<bool> AddWordAsync(string englishWord, List<string> spanishTranslations)
        {
            if (string.IsNullOrWhiteSpace(englishWord))
                throw new ArgumentException("La palabra en inglés no puede estar vacía", nameof(englishWord));
            if (spanishTranslations == null || spanishTranslations.Count == 0)
                throw new ArgumentException("Debe proporcionar al menos una traducción", nameof(spanishTranslations));

            var entries = await _repository.GetAllAsync();
            
            // Verificar si la palabra ya existe (ignorando mayúsculas/minúsculas)
            if (entries.Any(e => e.EnglishWord.Equals(englishWord, StringComparison.OrdinalIgnoreCase)))
                return false;

            var newEntry = new TranslationEntry
            {
                EnglishWord = englishWord,
                SpanishTranslations = spanishTranslations
            };

            await _repository.AddAsync(newEntry);
            return true;
        }

        /// <inheritdoc />
        public async Task<TranslationEntry?> FindByEnglishWordAsync(string englishWord)
        {
            if (string.IsNullOrWhiteSpace(englishWord))
                return null;

            var entries = await _repository.GetAllAsync();
            return entries.FirstOrDefault(e => e.EnglishWord.Equals(englishWord, StringComparison.OrdinalIgnoreCase));
        }
    }
}