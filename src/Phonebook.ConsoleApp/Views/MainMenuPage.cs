using Phonebook.ConsoleApp.Enums;
using Phonebook.ConsoleApp.Extensions;
using Phonebook.Controllers;
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
    #region Fields

    private readonly PhonebookController _phonebookController;

    #endregion
    #region Constructors

    public MainMenuPage(PhonebookController phonebookController)
    {
        _phonebookController = phonebookController;
    }

    #endregion
    #region Methods - Internal

    internal void Show()
    {
        var choice = PageChoices.Default;

        while (choice != PageChoices.CloseApplication)
        {
            WriteHeader(PageTitle);

            choice = AnsiConsole.Prompt(
                new SelectionPrompt<PageChoices>()
                .Title(PromptTitle)
                .AddChoices(PageChoices.CreateContact)
                .AddChoices(PageChoices.CloseApplication)
                .UseConverter(c => c.GetDescription())
                );

            switch (choice)
            {
                case PageChoices.CreateContact:
                    CreateContact();
                    break;
            }
        }
    }

    #endregion
    #region Methods - Private
    
    private void CreateContact()
    {
        var request = CreateContactPage.Show();
        if (request == null)
        {
            return;
        }

        _phonebookController.AddContact(request.Name, request.Email, request.PhoneNumber);

        MessagePage.Show("Create Contact", "Contact created successfully");
    }

    #endregion
}
