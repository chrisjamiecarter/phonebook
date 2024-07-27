using Phonebook.Data.Contexts;

namespace Phonebook.Data.Services;

public partial class PhonebookService
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
}
