using System.ComponentModel.DataAnnotations;

namespace FreakyFashion.Contracts.Categories.Requests;

public class CreateCategoryRequestDto
{
    [Required]
    [MinLength(1)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string Image { get; set; } = string.Empty;
}
