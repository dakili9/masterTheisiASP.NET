using System.ComponentModel.DataAnnotations;
using MasterThesisASP.NET.Dtos.Abstract;

using TaskStatus = MasterThesisASP.NET.Enums.TaskStatus;

namespace MasterThesisASP.NET.Dtos.Tasks;

public class CreateTaskRequestDto : CreateRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
    public string Name { get; set; }

    [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public TaskStatus? Status { get; set; }

    [Required(ErrorMessage = "Due date is required.")]
    public DateOnly DueDate { get; set; }

    [Required(ErrorMessage = "UserId is required.")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "CategoryId is required.")]
    public Guid CategoryId { get; set; }
}
