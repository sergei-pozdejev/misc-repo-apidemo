using System.ComponentModel.DataAnnotations;


namespace ProductApiDemo.Data.Entities
{
    public class Entity
    {
        [Key]
        public Guid? Id { get; set; }
    }
}
