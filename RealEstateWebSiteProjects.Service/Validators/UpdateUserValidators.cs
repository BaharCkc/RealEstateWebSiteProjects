using FluentValidation;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Service.Validators
{
    public class UpdateUserValidators : AbstractValidator<UserModel>
    {
        public UpdateUserValidators()
        {
            RuleFor(b => b.RegisterName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(b => b.FullName).NotEmpty().WithMessage("Adı Soyadı Boş Geçilemez!");
        }
    }
}
