using Phonebook.ConsoleApp.Enums;
using Phonebook.Extensions;
using Phonebook.Data.Entities;
using Spectre.Console;
using Phonebook.ConsoleApp.Models;
using Phonebook.ConsoleApp.Services;

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

        return option.Id == 0 ? null : contacts.First(x => x.Id == option.Id);
    }

    #endregion
    #region Methods - Private

    private static PageChoice GetOption(IReadOnlyList<Contact> contacts)
    {
        // Concatenates contacts (as an ID, Name KVP) with a "0, Close page" choice.
        IEnumerable<PageChoice> pageChoices = 
        [
            .. contacts.Select(x => new PageChoice { Id = x.Id, Name = x.Name }), 
            new PageChoice { Id = 0, Name = PageChoices.ClosePage.GetDescription() }
        ];

        return UserInputService.GetPageChoice(PromptTitle, pageChoices);
    }

    #endregion
}
