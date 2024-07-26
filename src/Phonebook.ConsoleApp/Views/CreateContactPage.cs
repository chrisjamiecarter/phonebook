using Phonebook.ConsoleApp.Services;
using Phonebook.Models;

namespace Phonebook.ConsoleApp.Views;

/// <summary>
/// Page which allows users to create a contact.
/// </summary>
internal class CreateContactPage : BasePage
{
    #region Constants

    private const string PageTitle = "Create Contact";

    #endregion
    #region Methods - Internal

    internal static CreateContactRequest? Show()
    {
        WriteHeader(PageTitle);

        var name = UserInputService.GetString($"Enter the contact's [blue]name[/], or [blue]0[/] to cancel: ");
        if (name == "0")
        {
            return null;
        }

        var email = UserInputService.GetEmailAddress($"Enter the contact's [blue]email address[/], or [blue]0[/] to cancel: ");
        if (email == "0")
        {
            return null;
        }

        var phone = UserInputService.GetPhoneNumber($"Enter the contact's [blue]phone number[/], or [blue]0[/] to cancel: ");
        if (phone == "0")
        {
            return null;
        }

        return new CreateContactRequest
        {
            Name = name,
            Email = email,
            PhoneNumber = phone
        };
    }

    #endregion
}
