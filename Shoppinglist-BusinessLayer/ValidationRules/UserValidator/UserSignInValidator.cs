using DTO.DTOs.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_BusinessLayer.ValidationRules.UserValidator
{
    public class UserSignInValidator : AbstractValidator<UserSignInDto>
    {
        public UserSignInValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen Email alanını boş geçmeyin");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre alanını boş geçmeyin");
        }
    }
}
