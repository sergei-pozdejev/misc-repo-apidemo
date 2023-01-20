using AutoMapper;
using ProductApiDemo.Models;

namespace ProductApiDemo.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(x=>x.Id, opts => opts.Ignore());
        }
    }
}
