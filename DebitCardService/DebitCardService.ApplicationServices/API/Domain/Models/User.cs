﻿namespace DebitCardService.ApplicationServices.API.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Login { get; set; }
    public List<decimal>? AmountsOnCards { get; set; }
}
