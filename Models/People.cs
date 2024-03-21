using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class People
{
  public int ID { get; set; }

  [Required]
  [BindProperty]
  public string? name { get; set; }
  public string[] names = { "Brett", "Kylie" };
}