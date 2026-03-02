using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TraductorApp.Core.Interfaces;
using TraductorApp.Core.Models;

namespace TraductorApp.Data.Repositories
{
    /// <summary>
    /// Repositorio de diccionario que utiliza un archivo JSON como almacenamiento persistente.
    /// </summary>
    public class JsonDictionaryRepository : IDictionaryRepository
    {
        private readonly string _filePath;
        private List<TranslationEntry> _entries;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly object _lock = new object();

        /// <summary>
        /// Inicializa una nueva instancia del repositorio JSON.
        /// </summary>
        /// <param name="filePath">Ruta del archivo JSON. Si no se especifica, usa "dictionary.json".</param>
        public JsonDictionaryRepository(string filePath = "dictionary.json")
        {
            _filePath = filePath;
            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            _entries = new List<TranslationEntry>();
            LoadFromFileAsync().GetAwaiter().GetResult(); // Carga sincrónica en el constructor
        }

        /// <summary>
        /// Carga los datos desde el archivo JSON de forma asíncrona.
        /// </summary>
        private async Task LoadFromFileAsync()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    _entries = GetDefaultEntries();
                    await SaveToFileAsync();
                    return;
                }

                string json = await File.ReadAllTextAsync(_filePath);
                if (string.IsNullOrWhiteSpace(json))
                {
                    _entries = GetDefaultEntries();
                    await SaveToFileAsync();
                    return;
                }

                var entries = JsonSerializer.Deserialize<List<TranslationEntry>>(json, _jsonOptions);
                _entries = entries ?? GetDefaultEntries();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando el diccionario: {ex.Message}");
                _entries = GetDefaultEntries();
            }
        }

        /// <summary>
        /// Guarda los datos en el archivo JSON de forma asíncrona.
        /// </summary>
        private async Task SaveToFileAsync()
        {
            try
            {
                string json = JsonSerializer.Serialize(_entries, _jsonOptions);
                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error guardando el diccionario: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las entradas del diccionario.
        /// </summary>
        public Task<List<TranslationEntry>> GetAllAsync()
        {
            return Task.FromResult(new List<TranslationEntry>(_entries));
        }

        /// <summary>
        /// Agrega una nueva entrada al diccionario.
        /// </summary>
        public async Task AddAsync(TranslationEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            lock (_lock)
            {
                _entries.Add(entry);
            }
            await SaveToFileAsync();
        }

        /// <summary>
        /// Reemplaza toda la lista de entradas por una nueva y guarda los cambios.
        /// </summary>
        public async Task SaveChangesAsync(List<TranslationEntry> entries)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));

            lock (_lock)
            {
                _entries = new List<TranslationEntry>(entries);
            }
            await SaveToFileAsync();
        }

        /// <summary>
        /// Obtiene la lista predeterminada de palabras iniciales.
        /// </summary>
        private static List<TranslationEntry> GetDefaultEntries()
        {
            return new List<TranslationEntry>
            {
                new() { EnglishWord = "time", SpanishTranslations = new() { "tiempo" } },
                new() { EnglishWord = "person", SpanishTranslations = new() { "persona" } },
                new() { EnglishWord = "year", SpanishTranslations = new() { "año" } },
                new() { EnglishWord = "way", SpanishTranslations = new() { "camino", "forma" } },
                new() { EnglishWord = "day", SpanishTranslations = new() { "día" } },
                new() { EnglishWord = "thing", SpanishTranslations = new() { "cosa" } },
                new() { EnglishWord = "man", SpanishTranslations = new() { "hombre" } },
                new() { EnglishWord = "world", SpanishTranslations = new() { "mundo" } },
                new() { EnglishWord = "life", SpanishTranslations = new() { "vida" } },
                new() { EnglishWord = "hand", SpanishTranslations = new() { "mano" } },
                new() { EnglishWord = "part", SpanishTranslations = new() { "parte" } },
                new() { EnglishWord = "child", SpanishTranslations = new() { "niño", "niña" } },
                new() { EnglishWord = "eye", SpanishTranslations = new() { "ojo" } },
                new() { EnglishWord = "woman", SpanishTranslations = new() { "mujer" } },
                new() { EnglishWord = "place", SpanishTranslations = new() { "lugar" } },
                new() { EnglishWord = "work", SpanishTranslations = new() { "trabajo" } },
                new() { EnglishWord = "week", SpanishTranslations = new() { "semana" } },
                new() { EnglishWord = "case", SpanishTranslations = new() { "caso" } },
                new() { EnglishWord = "point", SpanishTranslations = new() { "punto", "tema" } },
                new() { EnglishWord = "government", SpanishTranslations = new() { "gobierno" } },
                new() { EnglishWord = "company", SpanishTranslations = new() { "empresa", "compañía" } }
            };
        }
    }
}
