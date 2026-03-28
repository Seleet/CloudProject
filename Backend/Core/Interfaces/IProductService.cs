using CloudProject.Contracts.Products.Requests;
using CloudProject.Contracts.Products.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace CloudProject.Core.Interfaces;

public interface IProductService
{
    Task<List<ProductResponseDto>> GetAllAsync();

    Task<ProductResponseDto?> GetByIdAsync(int id);

    Task<List<ProductResponseDto>> GetBySlugAsync(string slug);

    Task<ProductResponseDto> CreateAsync(CreateProductRequestDto request);

    Task<ProductResponseDto?> PatchAsync(int id, JsonPatchDocument<UpdateProductRequestDto> patchDocument);

    Task<bool> DeleteAsync(int id);
}
