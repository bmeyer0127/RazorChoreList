using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Chore
{
  public int ID { get; set; }

  [Display(Name = "Chore")]
  public string? ChoreName { get; set; }

  [Display(Name = "Person Doing It")]
  public string? ChoreDoer { get; set; }

  [Display(Name = "Completion Status")]
  public string? CompletionStatus { get; set; }
}