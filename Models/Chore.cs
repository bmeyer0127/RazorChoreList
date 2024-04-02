using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

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
  public int PersonId { get; set; }
  public Person person { get; set; }
  public ICollection<Person> People { get; }
}

