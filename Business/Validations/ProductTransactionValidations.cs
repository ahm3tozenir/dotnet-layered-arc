using Entities.Models;
using Business.Tools.Exceptions;


namespace Business.Validations;

public class ProductTransactionValidations
{
    public async Task ProductTransactionMustNotBeEmpty(ProductTransaction? product)
    {
        if (product == null)
        {
            throw new ValidationException("ProductTransaction  must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}