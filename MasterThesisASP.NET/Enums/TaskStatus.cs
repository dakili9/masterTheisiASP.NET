using System.ComponentModel.DataAnnotations;

namespace MasterThesisASP.NET.Enums;


public enum TaskStatus
{
    [Display(Name = "Pending")]
    Pending, 
    [Display(Name = "In Progress")]
    InProgress,
    [Display(Name = "Completed")]
    Completed,
    [Display(Name ="On Hold")]
    OnHold
}
