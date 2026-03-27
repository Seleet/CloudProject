using CloudProject.Contracts.Products.Responses;

namespace CloudProject.Contracts.Categories.Responses;

public class CategoryResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public string UrlSlug { get; set; } = string.Empty;

    public List<ProductResponseDto> Products { get; set; } = new();
}