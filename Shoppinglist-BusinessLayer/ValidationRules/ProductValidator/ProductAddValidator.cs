using DTO.DTOs.ProductDTOs;
using FluentValidation;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_BusinessLayer.ValidationRules.ProductValidator.ProductValidator
{
    public class ProductAddValidator : AbstractValidator<ProductAddDto>
    {
        Context context = new Context();

        private bool BeUniqueCategoryAndCaption(ProductAddDto model, string name)
        {
            var result = context.Products.Where(x => x.NormalizedName == name.ToUpper()).ToList().Any();
            return !result;
        }
        public ProductAddValidator()
        {
            RuleFor(x => x.Name)
            .Must(BeUniqueCategoryAndCaption)
            .WithMessage("Bu Ürün Daha Önce Kaydedilmiştir.");

        }





    }
}
