using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProductManager.Domain.Models;

namespace ProductManager.API.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // Double validations through DataAnnotations and FluentValidation is not a good practice
            // and only for demonstration purposes have been put here.
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name should not be empty.")
                .Length(3, 50);
            RuleFor(x => x.Price).Must(x => x > 0)
                .WithMessage("Price should be bigger than 0");
            RuleFor(x => x.Type).Must(x => x > 0)
                .WithMessage("Product Type should be selected.");
            RuleFor(x => x.Category).Must(x => x != null)
                .WithMessage("Product Category should be selected.");
        }
    }
}
