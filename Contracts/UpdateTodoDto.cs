using System.ComponentModel.DataAnnotations;

namespace TodoApi.Contracts;

public class UpdateTodoDto
{
    [Required]
    [StringLength(10, MinimumLength = 5)]
    public string Name { get; set; }

    [Required]
    public bool IsComplete { get; set; }
}