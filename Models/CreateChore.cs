using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class CreateChore
{
  [Required]
  [Display(Name = "Chore")]
  public string? ChoreName { get; set; }

  [Required]
  [Display(Name = "Completion Status")]
  [BindProperty]
  public string? CompletionStatus { get; set; }

  public static string[]? CompletionStatusOptions = { "Not Completed", "Completed" };

  [Required]
  public int PersonId { get; set; }
}