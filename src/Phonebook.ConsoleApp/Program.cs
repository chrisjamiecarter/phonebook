using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Phonebook.ConsoleApp.Extensions;
using Phonebook.ConsoleApp.Utilities;
using Phonebook.ConsoleApp.Views;
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
            //string databaseConnectionString = ConfigurationManager.AppSettings.GetString("DatabaseConnectionString");
            
            // Create the SQL Server database context.
            var databaseContext = new DatabaseContext();
            
            // Perform any database migrations.
            // NOTE: this does not generate migrations. It only actions them.
            LongRunningProcess.Start("Performing database migrations. Please wait...", databaseContext.Database.Migrate);
            
            // Create the required services.
            var phonebookController = new PhonebookController(databaseContext);

            //var mainMenu = new MainMenuPage();
            MainMenuPage.Show();
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
