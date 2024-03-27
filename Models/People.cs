using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class People
{
  [Key]
  public int PeopleID { get; set; }

  public string? name { get; set; }
}