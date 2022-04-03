using eShop.Application.Features.Products;
using FluentValidation;

namespace eShop.Api.Validation;

public sealed class UpdateProductDescriptionValidator : AbstractValidator<ProductDescriptionUpdateRequest>
{
    public UpdateProductDescriptionValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .GreaterThan(0);
    }
}
