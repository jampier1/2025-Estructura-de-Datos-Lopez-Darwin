using TraductorApp.Core.Interfaces;
using TraductorApp.Core.Services;
using TraductorApp.Data.Repositories;
using TraductorApp.Console.Menus;

namespace TraductorApp.Console;

public static class Program
{
    public static async Task Main()
    {
        // Configurar dependencias
        var repository = new JsonDictionaryRepository("dictionary.json");
        IDictionaryService dictionaryService = new DictionaryService(repository);
        ITranslationService translationService = new TranslationService(dictionaryService);

        // Ejecutar menú principal
        var menu = new MainMenu(dictionaryService, translationService);
        await menu.ShowAsync();
    }
}
