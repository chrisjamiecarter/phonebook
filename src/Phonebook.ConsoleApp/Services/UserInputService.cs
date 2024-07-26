using System.ComponentModel.DataAnnotations;
using Spectre.Console;

namespace Phonebook.ConsoleApp.Services;

/// <summary>
/// Helper service for getting valid user inputs of different types.
/// </summary>
internal static class UserInputService
{
    #region Constants

    private readonly static string EmailValidationErrorMessage = "[red]Invalid email address![/] Expected format: [blue]user@domain.tld[/]";
    
    private readonly static string PhoneValidationErrorMessage = "[red]Invalid phone number[/] Expected format: [blue]01234567890[/]";

    #endregion
    #region Methods

    internal static string GetString(string prompt)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            );
    }

    internal static string GetString(string prompt, string defaultValue)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .DefaultValue(defaultValue)
            );
    }

    internal static string GetEmailAddress(string prompt)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .ValidationErrorMessage(EmailValidationErrorMessage)
            .Validate(input =>
            {
                return (input == "0" || new EmailAddressAttribute().IsValid(input))
                ? Spectre.Console.ValidationResult.Success()
                : Spectre.Console.ValidationResult.Error();
            }));
    }

    internal static string GetEmailAddress(string prompt, string defaultValue)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .DefaultValue(defaultValue)
            .ValidationErrorMessage(EmailValidationErrorMessage)
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
            .ValidationErrorMessage(PhoneValidationErrorMessage)
            .Validate(input =>
            {
                return (input == "0" || new PhoneAttribute().IsValid(input))
                ? Spectre.Console.ValidationResult.Success()
                : Spectre.Console.ValidationResult.Error();
            }));
    }

    internal static string GetPhoneNumber(string prompt, string defaultValue)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .DefaultValue(defaultValue)
            .ValidationErrorMessage(PhoneValidationErrorMessage)
            .Validate(input =>
            {
                return (input == "0" || new PhoneAttribute().IsValid(input))
                ? Spectre.Console.ValidationResult.Success()
                : Spectre.Console.ValidationResult.Error();
            }));
    }

    #endregion
}

