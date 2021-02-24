using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            //RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("bla la");

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId ==1);
            RuleFor(p => p.ProductName).Must(StartsWithA);

        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("a") || arg.StartsWith("A");
        }
    }
}
