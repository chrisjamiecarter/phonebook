using Phonebook.ConsoleApp.Enums;
using Phonebook.ConsoleApp.Extensions;
using Phonebook.Data.Entities;
using Spectre.Console;

namespace Phonebook.ConsoleApp.Views;

/// <summary>
/// A page to displays a list of contacts for selection.
/// </summary>
internal class SelectContactPage : BasePage
{
    #region Constants

    private const string PageTitle = "Select Contact";

    #endregion
    #region Methods - Internal

    /// <summary>
    /// Gets a list of categories from the drinks controller displays for user selection.
    /// </summary>
    /// <returns>The name of the category selected, or null if user wants to close the page.</returns>
    internal static Contact? Show(IReadOnlyList<Contact> contacts)
    {
        WriteHeader(PageTitle);

        var option = GetOption(contacts);

        return option == 0 ? null : contacts.First(x => x.Id == option);
    }

    #endregion
    #region Methods - Private

    private static int GetOption(IReadOnlyList<Contact> contacts)
    {
        // Concatenates contacts (as an ID, Name KVP) with a "Close page" choice.
        IEnumerable<KeyValuePair<int, string>> pageChoices = 
        [
            .. contacts.Select(x => new KeyValuePair<int, string>(x.Id, x.Name)), 
            new KeyValuePair<int, string>(0, PageChoices.ClosePage.GetDescription()) 
        ];

        return AnsiConsole.Prompt(
                new SelectionPrompt<KeyValuePair<int, string>>()
                .Title(PromptTitle)
                .EnableSearch()
                .AddChoices(pageChoices)
                .UseConverter(c => c.Value)
                ).Key;
    }

    #endregion
}
