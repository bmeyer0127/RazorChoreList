using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

public class Chore
{
  [Key]
  public int ID { get; set; }

  [Required]
  [Display(Name = "Chore")]
  public string? ChoreName { get; set; }

  [Required]
  [Display(Name = "Completion Status")]
  [BindProperty]
  public string? CompletionStatus { get; set; }
  public static string[] CompletionStatusOptions = { "Not Completed", "Completed" };

  public int PeopleID { get; set; }
  [ForeignKey("PeopleID")]
  public People people { get; set; }
}

