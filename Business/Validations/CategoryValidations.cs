using Business.Tools.Exceptions;
using Entities.Models;

namespace Business.Validations;

public class CategoryValidations
{
    public async Task CategoryMustNotBeEmpty(Category? category)
    {
        if (category == null)
        {
            throw new ValidationException("Category must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}