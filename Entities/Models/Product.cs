using Core.Repository;

namespace Entities.Models;

public class Product : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }

    public Product()
    {
        ProductTransactions = new HashSet<ProductTransaction>();
    }
}