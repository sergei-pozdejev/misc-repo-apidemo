using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NuGet.Frameworks;
using ProductApiDemo.Data;
using ProductApiDemo.Data.Base;
using ProductApiDemo.Data.DemoData;
using ProductApiDemo.Data.Interfaces;
using ProductApiDemo.Exceptions;
using ProductApiDemo.Models;
using ProductApiDemo.Services;
using ProductApiDemo.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProductApiDemo.Test
{
    public class ProductApiServiceTest
    {
        

        private IMapper CreateAutomapper()
        {
            var coreAssembly = typeof(ProductService).Assembly;

            return new MapperConfiguration(mc => mc.AddMaps(coreAssembly)).CreateMapper();
        }

        private ProductDbContext SetupContext()
        {
            var data = DemoData.GetProductExamples().AsQueryable();

            var contextMock = new Mock<ProductDbContext>();

            contextMock.SetupSequence(x => x.Set<Product>())
                        .ReturnsDbSet(new List<Product>())
                        .ReturnsDbSet(data);
            return contextMock.Object;
        }

        private IRepository<Product> SetupRepository(ProductDbContext context)
        {
            var data = DemoData.GetProductExamples().ToArray();
            var prRepo = new Mock<Repository<Product>>(context);

            prRepo.Setup(repo => repo.AddAsync(It.IsNotNull<Product>()))
                                     .ReturnsAsync((Product x) => 
                                     { 
                                         x.Id = Guid.NewGuid(); 
                                         return x; 
                                     });

            prRepo.Setup(repo => repo.GetAsync(It.IsNotNull<Guid>()))
                        .ReturnsAsync((Guid id) =>
                        {
                            return new Product 
                            { 
                                Id = id, 
                                ExpirationDate = new DateTime(2024, 1, 1), 
                                Name = "Test product" 
                            };
                        });

            prRepo.Setup(repo => repo.DeleteAsync(It.IsNotNull<Product>()));
            
           prRepo.Setup(repo => repo.GetQuery())
                .Returns(()=> data.AsQueryable());

            return prRepo.Object;
        }

        [Fact]
        public async Task TestGetProduct()
        {
            var context = SetupContext();
            var repo = SetupRepository(context);
            var mapper = CreateAutomapper();
            var productService = new ProductService(repo, mapper);

            var productId = Guid.NewGuid();
            var product = await productService.GetAsync(productId);

            Assert.Equal(productId, product.Id);
            Assert.Equal("Test product", product.Name);
        }

        [Fact]
        public async Task ProductService_SearchNonExistingPage()
        {
            var context = SetupContext();
            var repo = SetupRepository(context);
            var mapper = CreateAutomapper();
            var productService = new ProductService(repo, mapper);

            await Assert.ThrowsAsync<PageNotFoundException>(() => productService.SearchAsync(100, "", false));
        }

        [Fact]
        public async Task ProductService_SearchBananasMoreThanOne()
        {
            var context = SetupContext();
            var repo = SetupRepository(context);
            var mapper = CreateAutomapper();
            var productService = new ProductService(repo, mapper);

            var products = await productService.SearchAsync(1, "banana", false);

            Assert.True(products.Items.Count() > 1);
        }

        [Fact]
        public async Task ProductService_SearchNextPageGenerated()
        {
            var context = SetupContext();
            var repo = SetupRepository(context);
            var mapper = CreateAutomapper();
            var productService = new ProductService(repo, mapper);

            var products = await productService.SearchAsync(1, "", false);

            Assert.False(String.IsNullOrEmpty(products.NextPage));
        }
    }
}