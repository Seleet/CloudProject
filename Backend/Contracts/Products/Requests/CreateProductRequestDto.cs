using System.ComponentModel.DataAnnotations;

namespace FreakyFashion.Contracts.Products.Requests;

public class CreateProductRequestDto
{
    [Required]
    [MinLength(1)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [MinLength(1)]
    public string Image { get; set; } = string.Empty;

    public List<int> Categories { get; set; } = new();
}
