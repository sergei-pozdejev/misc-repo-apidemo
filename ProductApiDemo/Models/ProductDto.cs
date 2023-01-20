namespace ProductApiDemo.Models
{
    public class ProductDto
    {
        public Guid? Id { get; set; } 

        /// <summary>
        /// Product friendly name 
        /// </summary>
        /// <example>Banana</example>
        public string Name { get; set; }        
        
        /// <summary>
        /// Product code. Should be unique 
        /// </summary>
        /// <example>CB12</example>
        public string Code { get; set; }        
        
        /// <summary>
        /// Expiration date
        /// </summary>
        /// <example>2023-06-01</example>
        public DateTime ExpirationDate { get; set; }
    }
}