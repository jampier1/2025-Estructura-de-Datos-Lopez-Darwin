using TraductorApp.Core.Interfaces;
using TraductorApp.Console.Helpers;

namespace TraductorApp.Console.Menus;

public class MainMenu
{
    private readonly IDictionaryService _dictionaryService;
    private readonly ITranslationService _translationService;

    public MainMenu(IDictionaryService dictionaryService, ITranslationService translationService)
    {
        _dictionaryService = dictionaryService;
        _translationService = translationService;
    }

    public async Task ShowAsync()
    {
        bool exit = false;
        while (!exit)
        {
            ConsoleHelper.ClearAndShowTitle();
            System.Console.WriteLine("1. Traducir una frase");
            System.Console.WriteLine("2. Agregar palabras al diccionario");
            System.Console.WriteLine("0. Salir");
            System.Console.Write("Seleccione una opción: ");

            string? option = System.Console.ReadLine();

            switch (option)
            {
                case "1":
                    await TranslatePhraseAsync();
                    break;
                case "2":
                    await AddWordAsync();
                    break;
                case "0":
                    exit = true;
                    ConsoleHelper.ShowMessage("¡Hasta luego!", ConsoleColor.Green);
                    break;
                default:
                    ConsoleHelper.ShowMessage("Opción no válida. Intente de nuevo.", ConsoleColor.Red);
                    break;
            }

            if (!exit)
                ConsoleHelper.Pause();
        }
    }

    private async Task TranslatePhraseAsync()
    {
        // Lógica de traducción (similar a la que tenías en Program.cs)
        System.Console.Write("\nIngrese la frase a traducir: ");
        string? phrase = System.Console.ReadLine();

        if (string.IsNullOrWhiteSpace(phrase))
        {
            ConsoleHelper.ShowMessage("Frase vacía. No se puede traducir.", ConsoleColor.Yellow);
            return;
        }

        try
        {
            string translated = await _translationService.TranslatePhraseAsync(phrase);
            ConsoleHelper.ShowMessage($"\nTraducción: {translated}", ConsoleColor.Green);
        }
        catch (Exception ex)
        {
            ConsoleHelper.ShowMessage($"Error al traducir: {ex.Message}", ConsoleColor.Red);
        }
    }

    private async Task AddWordAsync()
    {
        // Lógica para agregar palabra (similar a la que tenías)
        System.Console.Write("\nIngrese la palabra en inglés: ");
        string? englishWord = System.Console.ReadLine();

        if (string.IsNullOrWhiteSpace(englishWord))
        {
            ConsoleHelper.ShowMessage("Palabra inválida.", ConsoleColor.Yellow);
            return;
        }

        System.Console.Write("\nIngrese la frase en español a traducir al inglés: ");
        string? spanishInput = System.Console.ReadLine();

        if (string.IsNullOrWhiteSpace(spanishInput))
        {
            ConsoleHelper.ShowMessage("Debe ingresar al menos una traducción.", ConsoleColor.Yellow);
            return;
        }

        var spanishTranslations = spanishInput
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToList();

        try
        {
            bool added = await _dictionaryService.AddWordAsync(englishWord, spanishTranslations);
            if (added)
                ConsoleHelper.ShowMessage($"Palabra '{englishWord}' agregada correctamente.", ConsoleColor.Green);
            else
                ConsoleHelper.ShowMessage($"La palabra '{englishWord}' ya existe en el diccionario.", ConsoleColor.Yellow);
        }
        catch (Exception ex)
        {
            ConsoleHelper.ShowMessage($"Error al agregar la palabra: {ex.Message}", ConsoleColor.Red);
        }
    }
}
