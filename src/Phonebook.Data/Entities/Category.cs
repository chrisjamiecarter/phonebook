using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.Data.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
    #region Properties

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "Default";

    public ICollection<Contact> Contacts { get; } = new List<Contact>();

    #endregion
}
