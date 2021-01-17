using ECommerceAPI.Server.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Server.ValidationRules.DeleteDtos
{
    public class ProductDeleteDtoValidator : AbstractValidator<ProductDeleteDto>
    {
        public ProductDeleteDtoValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Id alanı boş geçilemez");
        }
    }
}
