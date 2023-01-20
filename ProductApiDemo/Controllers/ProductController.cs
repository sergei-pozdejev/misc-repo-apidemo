using Microsoft.AspNetCore.Mvc;
using ProductApiDemo.Exceptions;
using ProductApiDemo.Models;
using ProductApiDemo.Services.Interfaces;
using System.Net;

namespace ProductApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Returns product by <paramref name="id"/> parameter
        /// </summary>
        /// <param name="id">Guid of product</param>
        /// <response code="200">Returns Product</response>
        /// <response code="404">Product not found</response>
        /// <response code="400">Invalid parameter</response>
        /// <returns>Existing product</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.Log(LogLevel.Information, "Product Get request was made");

            if (id == default(Guid))
            {
                return BadRequest();
            }

            var product = await _productService.GetAsync(id);

            return Ok(product);

        }

        /// <summary>
        /// Returns paged list of not expired Products by page <paramref name="page"/> parameter and filtered by <paramref name="term"/> parameter.
        /// </summary>
        /// <param name="page">Page number(default pageSize is 5). Should be bigger than 0</param>
        /// <param name="term">Search term. Can be part of product name or code. Can be empty</param>
        /// <param name="showExpired">If true includes expired products in result. False by default</param>
        /// <response code="200">Returns paged Products</response>
        /// <response code="400">Invalid parameters</response>
        /// <returns>A paged list of Products</returns>
        [HttpGet("Search")]
        [ProducesResponseType(typeof(PagedResult<ProductDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Search(int page, string? term, bool showExpired = false)
        {
            _logger.Log(LogLevel.Information, "Product Search request was made");

            if (page <= 0)
            {
                throw new InvalidRequestException("Page should be bigger than zero");
            }

            var result = await _productService.SearchAsync(page, term, showExpired);

            return Ok(result); 
        }

        /// <summary>
        /// Updates existing product if no other product with provided code exists
        /// </summary>
        /// <param name="id">Product id</param>
        /// <param name="product">Product json object</param>
        /// <response code="200">Returns modified Product</response>
        /// <response code="404">Product not found</response>
        /// <response code="400">Other product with same code exists or invalid parameter</response>
        /// <returns>Existing product</returns>
        [HttpPost("{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody]ProductDto product)
        {
            _logger.Log(LogLevel.Information, "Product Update request was made");

            if (product == null ) 
            { 
                return BadRequest(); 
            }

            product.Id = id;

            product = await _productService.UpdateAsync(product);

            return Ok(product);
        }

        /// <summary>
        /// Creates new product if no product with same code exists
        /// </summary>
        /// <param name="product">Product json object</param>
        /// <response code="200">Returns new Product</response>
        /// <response code="404">Product not found</response>
        /// <response code="400">Product with code exists or invalid parameter</response>
        /// <returns>Existing product</returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromBody]ProductDto product)
        {
            _logger.Log(LogLevel.Information, "Product Add request was made");

            if (product == null)
            {
                return BadRequest();
            }

            product = await _productService.AddAsync(product);

            return Ok(product);
        }

        /// <summary>
        /// Deletes product by <paramref name="id"/> parameter
        /// </summary>
        /// <param name="id">Guid of product</param>
        /// <response code="200">Product deleted</response>
        /// <response code="404">Product not found</response>
        /// <response code="400">Invalid parameter</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.Log(LogLevel.Information, "Product Delete request was made");

            if (id == default(Guid))
            {
                return BadRequest();
            }

            await _productService.DeleteAsync(id);

            return Ok();
        }
    }
}