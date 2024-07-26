using System.Reflection;
using Phonebook.Data.Entities;
using Spectre.Console;

namespace Phonebook.ConsoleApp.Engines;

/// <summary>
/// Engine for Spectre.Table generation.
/// </summary>
internal class TableEngine
{
    #region Methods

    internal static Table GetContactsTable(IReadOnlyList<Contact> data)
    {
        var table = new Table
        {
            Caption = new TableTitle($"{data.Count} contacts found."),
            Expand = true,
        };
        
        table.AddColumn("ID");
        table.AddColumn("Name");
        table.AddColumn("Email Address");
        table.AddColumn("Phone Number");
        
        foreach (var x in data)
        {
            table.AddRow(x.Id.ToString(), x.Name, x.Email, x.PhoneNumber);
        }

        return table;
    }

    #endregion
}
