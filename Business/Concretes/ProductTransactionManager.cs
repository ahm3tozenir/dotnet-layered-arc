using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ProductTransactionManager : IProductTransactionService
{
    public readonly IProductTransactionRepository _productTransactionRepository;
    public readonly ProductTransactionValidations _productTransactionValidations;

    public ProductTransactionManager(IProductTransactionRepository productTransactionRepository, ProductTransactionValidations productTransactionValidations)
    {
        _productTransactionRepository = productTransactionRepository;
        _productTransactionValidations = productTransactionValidations;
    }
    
    public ProductTransaction? GetById(Guid id)
    {
        return _productTransactionRepository.Get(pt => pt.Id == id);
    }

    public async Task<ProductTransaction?> GetByIdAsync(Guid id)
    {
        return await _productTransactionRepository.GetAsync(pt => pt.Id == id);
    }

    public IList<ProductTransaction> GetAll()
    {
        return _productTransactionRepository.GetAll().ToList();
    }

    public async Task<IList<ProductTransaction>> GetAllAsync()
    {
        var result = await _productTransactionRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<ProductTransaction> GetAllWithProduct()
    {
        return _productTransactionRepository.GetAll(include: productTransaction => productTransaction.Include(pt => pt.Product)).ToList();
    }

    public async Task<IList<ProductTransaction>> GetAllWithProductAsync()
    {
        var result = await _productTransactionRepository.GetAllAsync(include: productTransaction => productTransaction.Include(pt => pt.Product));
        return result.ToList();
    }

    public ProductTransaction Add(ProductTransaction productTransaction)
    {
        return _productTransactionRepository.Add(productTransaction);
    }

    public ProductTransaction Update(ProductTransaction productTransaction)
    {
        return _productTransactionRepository.Update(productTransaction);
    }

    public void DeleteById(Guid id)
    {
        var productTransaction = _productTransactionRepository.Get(pt => pt.Id == id);
        _productTransactionValidations.ProductTransactionMustNotBeEmpty(productTransaction).Wait();
        _productTransactionRepository.Delete(productTransaction);
    }

    public async Task<ProductTransaction> AddAsync(ProductTransaction productTransaction)
    {
        return await _productTransactionRepository.AddAsync(productTransaction);
    }

    public async Task<ProductTransaction> UpdateAsync(ProductTransaction productTransaction)
    {
        return await _productTransactionRepository.UpdateAsync(productTransaction);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var productTransaction = _productTransactionRepository.Get(pt => pt.Id == id);
        await _productTransactionValidations.ProductTransactionMustNotBeEmpty(productTransaction);
        await _productTransactionRepository.DeleteAsync(productTransaction);
    }
}