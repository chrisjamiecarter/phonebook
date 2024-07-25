using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data.Entities;

namespace Phonebook.Data.Contexts;

public class DatabaseContext : DbContext
{
    #region Properties

    public DbSet<Contact> Contacts { get; set; }

    #endregion
    #region Methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = ConfigurationManager.AppSettings.Get("DatabaseConnectionString") ?? throw new InvalidOperationException("Database connection string not found.");

        optionsBuilder.UseSqlServer(connectionString);
    }

    #endregion
}
