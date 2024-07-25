using Microsoft.EntityFrameworkCore;
using Phonebook.Data.Contexts;
using Phonebook.Data.Entities;

namespace Phonebook.Data.Services;

public class PhonebookService
{
    #region Fields

    private readonly DatabaseContext _context;

    #endregion
    #region Constructors

    public PhonebookService(DatabaseContext context)
    {
        _context = context;
    }

    #endregion
    #region Methods

    public bool AddContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public bool DeleteContact(Contact contact)
    {
        _context.Contacts.Remove(contact);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public Contact GetContact(int id)
    {
        return _context.Contacts.Single(x => x.Id == id);
    }

    public IReadOnlyList<Contact> GetContacts()
    {
        return _context.Contacts.ToList();
    }

    public bool SetContact(Contact contact)
    {
        _context.Contacts.Update(contact);
        var result = _context.SaveChanges();
        return result > 0;
    }

    #endregion
}
