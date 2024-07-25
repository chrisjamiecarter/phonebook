using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Phonebook.ConsoleApp.Extensions;
using Phonebook.Controllers;
using Phonebook.Data.Contexts;

namespace Phonebook.ConsoleApp;

/// <summary>
/// Main insertion point for the console application.
/// Configures the required application settings and launches the main menu view.
/// </summary>
internal class Program
{
    private static void Main()
    {
        try
        {
            // Read required configuration settings.
            string databaseConnectionString = ConfigurationManager.AppSettings.GetString("DatabaseConnectionString");
            
            // Create the SQL Server database context.
            // TODO: This may take some time so wrap in a status spinner.
            Console.WriteLine("Creating database.");
            //var databaseContext = new DatabaseContext(databaseConnectionString);
            var databaseContext = new DatabaseContext();
            // Perform any database migrations.
            // NOTE: this does not generate migrations. It only actions them.
            databaseContext.Database.Migrate();
            Console.WriteLine("- done.");

            // Create the required services.
            var phonebookController = new PhonebookController(databaseContext);

            Console.WriteLine($"Testing '{nameof(phonebookController.AddContact)}'.");
            Console.WriteLine(phonebookController.AddContact("test-name", "test-email@emailaddress.com", "12345678910"));
            Console.WriteLine(phonebookController.AddContact("test-name2", "test-email2@emailaddress.com", "98765432101"));
            Console.WriteLine("- done.");

            Console.WriteLine($"Testing '{nameof(phonebookController.GetContacts)}'.");
            var contacts = phonebookController.GetContacts();
            Console.WriteLine("- done.");

            Console.WriteLine($"Testing '{nameof(phonebookController.GetContact)}'.");
            foreach (var contact in contacts)
            {
                var x = phonebookController.GetContact(contact.Id);
                Console.WriteLine($"{x.Id}, {x.Name}, {x.Email}, {x.PhoneNumber}");
            }
            Console.WriteLine("- done.");

            Console.WriteLine($"Testing '{nameof(phonebookController.SetContact)}'.");
            foreach (var contact in contacts)
            {
                Console.WriteLine(phonebookController.SetContact(contact.Id, $"new-{contact.Name}", $"new-{contact.Email}", contact.PhoneNumber));
                var x = phonebookController.GetContact(contact.Id);
                Console.WriteLine($"{x.Id}, {x.Name}, {x.Email}, {x.PhoneNumber}");
            }
            Console.WriteLine("- done.");

            Console.WriteLine($"Testing '{nameof(phonebookController.DeleteContact)}'.");
            foreach (var contact in contacts)
            {
                Console.WriteLine(phonebookController.DeleteContact(contact.Id));
            }
            Console.WriteLine("- done.");

            Console.ReadKey();
        }
        catch (Exception exception)
        {
            //MessagePage.Show("Error", exception);
            Console.WriteLine(exception.Message);
        }
        finally
        {
            Environment.Exit(0);
        }
    }
}
