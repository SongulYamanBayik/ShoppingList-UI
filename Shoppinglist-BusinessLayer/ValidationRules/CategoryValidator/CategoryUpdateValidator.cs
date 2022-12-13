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
    public class CategoryUpdateValidator : AbstractValidator<Category>
    {
        Context context = new Context();
        private bool BeUniqueCategoryAndCaption(Category model, string name)
        {
            var result = context.Categories.Where(x => x.ID == model.ID & x.NormalizedName == model.Name.ToUpper()).ToList().Any();
            if (!result)
            {
                result = !context.Categories.Where(x => x.NormalizedName == name.ToUpper()).ToList().Any();

            }
            return result;
        }
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Name)
            .Must(BeUniqueCategoryAndCaption)
            .WithMessage("Bu kategori adı ile güncel kayıt var.");
        }
    }
}
