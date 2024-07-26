using System.ComponentModel.DataAnnotations;
using Spectre.Console;

namespace Phonebook.ConsoleApp.Services;

/// <summary>
/// Helper service for getting valid user inputs of different types.
/// </summary>
internal static class UserInputService
{
    #region Methods

    internal static string GetString(string prompt)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            );
    }

    internal static string GetEmailAddress(string prompt)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .ValidationErrorMessage("[red]Invalid email address![/] Expected format: [blue]user@domain.tld[/]")
            .Validate(input =>
            {
                return (input == "0" || new EmailAddressAttribute().IsValid(input))
                ? Spectre.Console.ValidationResult.Success()
                : Spectre.Console.ValidationResult.Error();
            }));
    }

    internal static string GetPhoneNumber(string prompt)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .ValidationErrorMessage("[red]Invalid phone number[/] Expected format: [blue]01234567890[/]")
            .Validate(input =>
            {
                return (input == "0" || new PhoneAttribute().IsValid(input))
                ? Spectre.Console.ValidationResult.Success()
                : Spectre.Console.ValidationResult.Error();
            }));
    }

    #endregion
}

