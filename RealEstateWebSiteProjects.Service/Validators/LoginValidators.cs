using FluentValidation;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Service.Validators
{
    public class LoginValidators : AbstractValidator<LoginUserModel>
    {
        public LoginValidators()
        {
            RuleFor(b => b.RegisterName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(b => b.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
        }
    }
}
