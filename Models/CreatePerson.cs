using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

public class CreatePerson
{
  [Required]
  public string? Name { get; set; }
}