using System.ComponentModel;

namespace Phonebook.ConsoleApp.Enums;

/// <summary>
/// Supported choices for all pages in the application.
/// </summary>
internal enum PageChoices
{
    [Description("Default")]
    Default,
    [Description("Close application")]
    CloseApplication,
    [Description("Close page")]
    ClosePage,
    [Description("Create contact")]
    CreateContact,
    [Description("Delete contact")]
    DeleteContact,
    [Description("View contacts")]
    ViewContacts
}

