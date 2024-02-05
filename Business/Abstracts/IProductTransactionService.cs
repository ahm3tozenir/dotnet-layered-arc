using Entities.Models;

namespace Business.Abstracts;

public interface IProductTransactionService
{
    ProductTransaction? GetById(Guid id);
    Task<ProductTransaction?> GetByIdAsync(Guid id);
    IList<ProductTransaction> GetAll();
    Task<IList<ProductTransaction>> GetAllAsync();
    IList<ProductTransaction> GetAllWithProduct();
    Task<IList<ProductTransaction>> GetAllWithProductAsync();
    ProductTransaction Add(ProductTransaction productTransaction);
    ProductTransaction Update(ProductTransaction productTransaction);
    void DeleteById(Guid id);
    Task<ProductTransaction> AddAsync(ProductTransaction productTransaction);
    Task<ProductTransaction> UpdateAsync(ProductTransaction productTransaction);
    Task DeleteByIdAsync(Guid id);
}