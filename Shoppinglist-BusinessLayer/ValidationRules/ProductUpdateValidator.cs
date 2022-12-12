using FluentValidation;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_BusinessLayer.ValidationRules
{
    public class ProductUpdateValidator : AbstractValidator<Product>
    {
        Context context = new Context();

        private bool BeUniqueCategoryAndCaption(Product model, string name)
        {
            var result = context.Products.Where(x => x.ID == model.ID & x.NormalizedName == model.Name.ToUpper()).ToList().Any();
            if (!result) 
            {
                result = !context.Products.Where(x => x.NormalizedName == name.ToUpper()).ToList().Any();
                
            }
            return result;
        }
        public ProductUpdateValidator()
        {
            RuleFor(x => x.Name)
            .Must(BeUniqueCategoryAndCaption)
            .WithMessage("Bu Ürün Adı ile güncel kayıt var.");

        }
    }
}
