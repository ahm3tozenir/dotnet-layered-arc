using Entities.Models;
using Business.Tools.Exceptions;


namespace Business.Validations;

public class OrderDetailValidations
{
    public async Task OrderDetailMustNotBeEmpty(OrderDetail? orderDetail)
    {
        if (orderDetail == null)
        {
            throw new ValidationException("Order detail must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}