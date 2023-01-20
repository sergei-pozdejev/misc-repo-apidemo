using ProductApiDemo.Models;

namespace ProductApiDemo.Services.Interfaces
{
    public interface IProductService: ICRUDService<ProductDto>
    {
        Task<PagedResult<ProductDto>> SearchAsync(int pageNumber, string? term, bool showExpired);
    }
}
