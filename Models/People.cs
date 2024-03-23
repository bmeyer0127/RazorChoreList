using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class People
{
  public int PeopleID { get; set; }

  [Required]
  [BindProperty]
  public string? name { get; set; }

  public ICollection<Chore> Chores { get; set; }
}