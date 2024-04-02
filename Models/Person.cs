using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

public class Person
{
  [Key]
  public int PersonId { get; set; }

  [Required]
  public string? Name { get; set; }
}