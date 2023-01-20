using ProductApiDemo.Data.Entities;

namespace ProductApiDemo.Models
{
    public class Product: Entity
    {
        public string Name { get; set; }
        
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}