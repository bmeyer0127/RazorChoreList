using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

public class Chore
{
  public int ID { get; set; }

  [Required]
  [Display(Name = "Chore")]
  public string? ChoreName { get; set; }

  [Required]
  [Display(Name = "Person Doing It")]
  public string? ChoreDoer { get; set; }

  [Required]
  [Display(Name = "Completion Status")]
  [BindProperty]
  public string? CompletionStatus { get; set; }
  public static string[] CompletionStatusOptions = { "Not Completed", "Completed" };
}