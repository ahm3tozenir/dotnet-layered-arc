using Entities.Models;
using Business.Tools.Exceptions;


namespace Business.Validations;

public class ProductValidations
{
    public async Task ProductMustNotBeEmpty(Product? product)
    {
        if (product == null)
        {
            throw new ValidationException("Product  must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}