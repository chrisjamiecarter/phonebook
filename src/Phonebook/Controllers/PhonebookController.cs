using Phonebook.Data.Contexts;
using Phonebook.Data.Entities;
using Phonebook.Data.Services;

namespace Phonebook.Controllers;

public partial class PhonebookController
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
}
