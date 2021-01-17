using ECommerceAPI.Server.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Server.ValidationRules.AddDtos
{
    public class ProductAddDtoValidator:AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez");
        }
    }
}
