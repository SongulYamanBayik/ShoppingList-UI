using DTO.DTOs.ProductDTOs;
using FluentValidation;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_BusinessLayer.ValidationRules.CategoryValidator
{
    public class CategoryAddValidator : AbstractValidator<Category>
    {
        Context context = new Context();
        private bool BeUniqueCategoryAndCaption(Category model, string name)
        {
            var result = context.Categories.Where(x => x.NormalizedName == name.ToUpper()).ToList().Any();
            return !result;
        }
        public CategoryAddValidator()
        {
            RuleFor(x => x.Name)
            .Must(BeUniqueCategoryAndCaption)
            .WithMessage("Bu Kategori Daha Önce Kaydedilmiştir.");
        }
    }
}
