﻿using Phonebook.ConsoleApp.Engines;
using Phonebook.ConsoleApp.Enums;
using Phonebook.ConsoleApp.Extensions;
using Phonebook.Controllers;
using Phonebook.Models;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                .AddChoices(PageChoices.ViewContacts)
                .AddChoices(PageChoices.CreateContact)
                .AddChoices(PageChoices.UpdateContact)
                .AddChoices(PageChoices.RemoveContact)
                .AddChoices(PageChoices.CloseApplication)
                .UseConverter(c => c.GetDescription())
                );

            switch (choice)
            {
                case PageChoices.CreateContact:
                    CreateContact();
                    break;
                case PageChoices.RemoveContact:
                    RemoveContact();
                    break;
                case PageChoices.UpdateContact:
                    UpdateContact();
                    break;
                case PageChoices.ViewContacts:
                    ViewContacts();
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

    private void RemoveContact()
    {
        var contacts = _phonebookController.GetContacts();

        var contact = SelectContactPage.Show(contacts);
        if (contact == null)
        {
            return;
        }

        _phonebookController.DeleteContact(contact.Id);

        MessagePage.Show("Remove Contact", "Contact removed successfully");
    }

    private void UpdateContact()
    {
        var contacts = _phonebookController.GetContacts();

        var contact = SelectContactPage.Show(contacts);
        if (contact == null)
        {
            return;
        }

        var request = UpdateContactPage.Show(contact);
        if (request == null)
        {
            return;
        }

        _phonebookController.SetContact(request.Id, request.Name, request.Email, request.PhoneNumber);

        MessagePage.Show("Update Contact", "Contact updated successfully");
    }

    private void ViewContacts()
    {
        var data = _phonebookController.GetContacts();
        var table = TableEngine.GetContactsTable(data);
        MessagePage.Show("View Contacts", table);
    }

    #endregion
}
