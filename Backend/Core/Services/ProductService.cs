using CloudProject.Contracts.Products.Requests;
using CloudProject.Contracts.Products.Responses;
using CloudProject.Core.Interfaces;
using CloudProject.Data.Entities;
using CloudProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CloudProject.Core.Services;

public class ProductService(AppDbContext dbContext) : IProductService
{
    public async Task<List<ProductResponseDto>> GetAllAsync()
    {
        var products = await dbContext.Products
            .Include(p => p.Categories)
            .ToListAsync();

        return products.Select(MapProductToResponse).ToList();
    }

public async Task<ProductResponseDto?> GetByIdAsync(int id)
  {
    var product = await dbContext.Products
    .Include(p => p.Categories)
    .FirstOrDefaultAsync(p => p.Id == id);

    if (product is null)
    {
      return null;
    }


    return MapProductToResponse(product);
  }













    private static ProductResponseDto MapProductToResponse(Product product)
    {
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Image = product.Image,
            UrlSlug = product.UrlSlug
        };
    }
}