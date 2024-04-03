using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Chore
{
  [Key]
  public int ChoreId { get; set; }

  [Required]
  [Display(Name = "Chore")]
  public string? ChoreName { get; set; }

  [Required]
  [Display(Name = "Completion Status")]
  [BindProperty]
  public string? CompletionStatus { get; set; }
  public static string[] CompletionStatusOptions = { "Not Completed", "Completed" };

  // [ForeignKey("PersonId")]
  [Required]
  public int PersonId { get; set; }
  public Person person { get; set; } = new();

  [ValidateNever]
  public ICollection<Person> People { get; }
}

