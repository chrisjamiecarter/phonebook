using System.Text;
using Spectre.Console;

namespace Phonebook.ConsoleApp.Views;

/// <summary>
/// The base class for any page view.
/// </summary>
internal abstract class BasePage
{
    #region Constants

    protected static readonly string ApplicationTitle = "Phonebook";

    protected static readonly string PromptTitle = "Select an [blue]option[/]...";

    private static readonly string DividerLine = "[cyan2]----------------------------------------[/]";

    #endregion
    #region Methods - Protected

    protected static void WriteFooter()
    {
        AnsiConsole.Write(new Rule().RuleStyle("grey").LeftJustified());
        AnsiConsole.Markup($"{Environment.NewLine}Press any [blue]key[/] to continue...");
        AnsiConsole.Write(new Rule().RuleStyle("grey").RightJustified());
        AnsiConsole.Write(new Rule().RuleStyle("grey").Centered());
        AnsiConsole.Write(new Rule().RuleStyle("grey"));
        Console.ReadKey();
    }

    protected static void WriteHeader(string title)
    {
        AnsiConsole.Clear();
        AnsiConsole.Markup(GetHeaderText(title));
    }

    #endregion
    #region Methods - Private

    private static string GetHeaderText(string pageTitle)
    {
        var sb = new StringBuilder();
        sb.AppendLine(DividerLine);
        sb.AppendLine($"[bold cyan2]{ApplicationTitle}[/]: [honeydew2]{pageTitle}[/]");
        sb.AppendLine(DividerLine);
        sb.AppendLine();
        return sb.ToString();
    }

    #endregion
}
