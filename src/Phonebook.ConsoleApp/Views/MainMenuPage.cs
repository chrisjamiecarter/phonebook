using Phonebook.ConsoleApp.Enums;
using Phonebook.ConsoleApp.Extensions;
using Spectre.Console;

namespace Phonebook.ConsoleApp.Views;

/// <summary>
/// The main menu page of the application.
/// </summary>
internal class MainMenuPage : BasePage
{
    #region Constants

    private const string PageTitle = "Main Menu";

    #endregion
    #region Methods - Internal

    internal static void Show()
    {
        var choice = PageChoices.Default;

        while (choice != PageChoices.CloseApplication)
        {
            WriteHeader(PageTitle);

            choice = AnsiConsole.Prompt(
                new SelectionPrompt<PageChoices>()
                .Title(PromptTitle)
                .AddChoices(PageChoices.CloseApplication)
                .UseConverter(c => c.GetDescription())
                );

            //switch (choice)
            //{
            //}
        }
    }

    #endregion
    #region Methods - Private
        
    #endregion
}
