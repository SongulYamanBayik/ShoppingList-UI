using DTO.DTOs.ProductDTOs;
using DTO.DTOs.UserDTOs;
using FluentValidation;
using Shoppinglist_DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_BusinessLayer.ValidationRules.UserValidator
{
    public class UserSignUpValidator : AbstractValidator<UserSignUpDto>
    {

        public UserSignUpValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen ad değerini boş geçmeyin");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen soyad değerini boş geçmeyin");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen mail adresini boş geçmeyin");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen kullanıcı adı alanını boş geçmeyin");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre alanını boş geçmeyin");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen şifreyi tekrar giriniz.");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor, lütfen kontrol ediniz.");
        }
    }
}
