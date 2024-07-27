using Phonebook.Data.Contexts;
using Phonebook.Data.Entities;
using Phonebook.Data.Services;

namespace Phonebook.Controllers;

public partial class PhonebookController
{
    #region Methods

    public Category GetCategory(int id)
    {
        return _service.GetCategory(id);
    }

    public Category GetCategory(string name)
    {
        return _service.GetCategory(name);
    }

    public IReadOnlyList<Category> GetCategories()
    {
        return _service.GetCategories();
    }

    #endregion
}
