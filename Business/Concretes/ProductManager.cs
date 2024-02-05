using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ProductManager : IProductService
{
    public readonly IProductRepository _productRepository;
    public readonly ProductValidations _productValidations;
    
    public ProductManager(IProductRepository productRepository, ProductValidations productValidations)
    {
        _productRepository = productRepository;
        _productValidations = productValidations;
    }
    
    public Product? GetById(Guid id)
    {
        return _productRepository.Get(od => od.Id == id);
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _productRepository.GetAsync(od => od.Id == id);
    }

    public IList<Product> GetAll()
    {
        return _productRepository.GetAll().ToList();
    }

    public async Task<IList<Product>> GetAllAsync()
    {
        var result = await _productRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<Product> GetAllWithCategory()
    {
        return _productRepository.GetAll(include: product => product.Include(p => p.Category)).ToList();
    }

    public async Task<IList<Product>> GetAllWithCategoryAsync()
    {
        var result = await _productRepository.GetAllAsync(include: product => product.Include(p => p.Category));
        return result.ToList();

    }

    public IList<Product> GetAllWithProductTransactions()
    {
        return _productRepository.GetAll(include: product => product.Include(p => p.ProductTransactions)).ToList();
    }

    public async Task<IList<Product>> GetAllWithProductTransactionsAsync()
    {
        var result = await _productRepository.GetAllAsync(include: product => product.Include(p => p.ProductTransactions));
        return result.ToList();
    }

    public Product Add(Product product)
    {
        return _productRepository.Add(product);
    }

    public Product Update(Product product)
    {
        return _productRepository.Update(product);
    }

    public void DeleteById(Guid id)
    {
        var product = _productRepository.Get(od => od.Id == id);
        _productValidations.ProductMustNotBeEmpty(product).Wait();
        _productRepository.Delete(product);
    }

    public async Task<Product> AddAsync(Product product)
    {
        return await _productRepository.AddAsync(product);
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        return await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var product = _productRepository.Get(od => od.Id == id);
        await _productValidations.ProductMustNotBeEmpty(product);
        await _productRepository.DeleteAsync(product);
    }
}