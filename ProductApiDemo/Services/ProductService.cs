using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using ProductApiDemo.Data.Interfaces;
using ProductApiDemo.Exceptions;
using ProductApiDemo.Models;
using ProductApiDemo.Services.Interfaces;

namespace ProductApiDemo.Services
{
    public class ProductService : IProductService
    {
        private int pageSize = 10;

        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddAsync(ProductDto dto)
        {
            ValidateProduct(dto);            

            var product = _mapper.Map<Product>(dto);

            product = await _productRepository.AddAsync(product);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product != null)
            {
                await _productRepository.DeleteAsync(product);

                return;
            }

            throw new ItemNotFoundException("Product not found");
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                throw new ItemNotFoundException("Product not found");
            }

            return _mapper.Map<ProductDto>(product);
        }

        public Task<PagedResult<ProductDto>> SearchAsync(int pageNumber, string? term, bool showExpired)
        {
            term = term?.ToLower() ?? string.Empty;

            var pagedResult = _productRepository.PagedSearch(pageSize, pageNumber, 
                                                        x => (showExpired || x.ExpirationDate.Date > DateTime.Now.Date)
                                                            && (x.Name.ToLower().Contains(term) || x.Code.ToLower().Contains(term)));

            var skippedItems = pageSize * (pageNumber - 1);

            if (skippedItems >= pagedResult.TotalCount)
            {
                throw new PageNotFoundException("Page not found");
            }

            var nextPage = GetNextPagePath(pageNumber, pagedResult.TotalCount, term);
            var productPageDtos = _mapper.Map<IEnumerable<ProductDto>>(pagedResult.Items);

            return Task.FromResult(new PagedResult<ProductDto>(pageNumber, pagedResult.TotalCount, nextPage, productPageDtos));
        }

        public async Task<ProductDto> UpdateAsync(ProductDto dto)
        {
            if (!dto.Id.HasValue)
            {
                throw new InvalidRequestException();
            }

            ValidateProduct(dto);

            var product = await _productRepository.GetAsync(dto.Id.Value);

            if (product == null) 
            {
                throw new ItemNotFoundException("Product not found");
            }

            _mapper.Map(dto, product);

            await _productRepository.SaveCahngesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        private void ValidateProduct(ProductDto dto)
        {
            ValidationException validation = new ValidationException();

            if (dto.ExpirationDate.Date < DateTime.Now.Date)
            {
                validation.AddValidationError("ExpirationDate", "Expiration date should be in future");
            }

            if (_productRepository.GetQuery().Any(x => (!dto.Id.HasValue || dto.Id != x.Id) && x.Code == dto.Code))
            {
                validation.AddValidationError("Code", "Product with same code already exists");
            }

            if (validation.HasErrors)
            {
                throw validation;
            }
        }

        private string GetNextPagePath(int pageNumber, int totalCount, string term)
        {
            var skipItemsTilNextPage = pageSize * pageNumber;

            if (skipItemsTilNextPage >= totalCount)
            {
                return string.Empty;
            }

            var queryParams = new Dictionary<string, string?>
            {
                { "pageNumber", (pageNumber + 1).ToString() },
                { "term", term }
            };

            return QueryHelpers.AddQueryString("Product/Search", queryParams);
        }

    }
}
