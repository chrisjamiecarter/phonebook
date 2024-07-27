﻿using Phonebook.Data.Entities;

namespace Phonebook.Models;

public class CreateContactRequest
{
    #region Properties

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public Category Category { get; set; } = new Category();

    #endregion
}
