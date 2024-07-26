using Spectre.Console;

namespace Phonebook.ConsoleApp.Utilities;

internal static class LongRunningProcess
{
    internal static void Start(string message, Action method)
    {
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start(message, ctx =>
            {
                method();
            });
    }
}
