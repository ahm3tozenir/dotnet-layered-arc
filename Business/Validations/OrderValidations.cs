using Entities.Models;
using Business.Tools.Exceptions;


namespace Business.Validations;

public class OrderValidations
{
    public async Task OrderMustNotBeEmpty(Order? order)
    {
        if (order == null)
        {
            throw new ValidationException("Order  must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}