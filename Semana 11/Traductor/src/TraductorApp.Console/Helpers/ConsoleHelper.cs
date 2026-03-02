namespace TraductorApp.Console.Helpers;

/// <summary>
/// Proporciona métodos auxiliares para la interacción con la consola.
/// </summary>
public static class ConsoleHelper
{
    public static void ShowMessage(string message, ConsoleColor color)
    {
        var previousColor = System.Console.ForegroundColor;
        System.Console.ForegroundColor = color;
        System.Console.WriteLine(message);
        System.Console.ForegroundColor = previousColor;
    }

    public static void Pause()
    {
        ShowMessage("\nPresione cualquier tecla para continuar...", ConsoleColor.DarkGray);
        System.Console.ReadKey();
    }

    public static void ClearAndShowTitle()
    {
        System.Console.Clear();
        System.Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine("==================== MENÚ ====================");
        System.Console.ResetColor();
    }
}
