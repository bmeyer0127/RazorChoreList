using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

public class People
{
  [Key]
  public int PeopleID { get; set; }

  [Required]
  public string? name { get; set; }
}