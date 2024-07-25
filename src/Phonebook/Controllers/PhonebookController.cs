using Phonebook.Data.Contexts;
using Phonebook.Data.Entities;
using Phonebook.Data.Services;

namespace Phonebook.Controllers;

public class PhonebookController
{
    #region Fields

    private readonly PhonebookService _service;

    #endregion
    #region Constructors

    public PhonebookController(DatabaseContext context)
    {
        _service = new PhonebookService(context);
    }

    #endregion
    #region Methods

    public bool AddContact(string name, string email, string phoneNumber)
    {
        var contact = new Contact
        {
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber
        };

        return _service.AddContact(contact);
    }

    public bool DeleteContact(int id)
    {
        var contact = _service.GetContact(id);
        return _service.DeleteContact(contact);
    }

    public Contact GetContact(int id)
    {
        return _service.GetContact(id);
    }

    public IReadOnlyList<Contact> GetContacts()
    {
        return _service.GetContacts();
    }

    public bool SetContact(int id, string name, string email, string phoneNumber)
    {
        var contact = _service.GetContact(id);
        contact.Name = name;
        contact.Email = email;
        contact.PhoneNumber = phoneNumber;

        return _service.SetContact(contact);
    }

    #endregion
}
