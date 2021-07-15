using FluentValidation;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Service.Validators
{
    public class UpdateUserProfileValidator : AbstractValidator<UserProfileModel>
    {
        public UpdateUserProfileValidator()
        {
            RuleFor(b => b.RegisterName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(b => b.FullName).NotEmpty().WithMessage("Adı Soyadı Boş Geçilemez!");
            RuleFor(b => b.TelephoneNumber).NotEmpty().WithMessage("Telefon Boş Geçilemez!");
            RuleFor(b => b.TelephoneNumber).Matches(@"^[0-9]{10}$").WithMessage("Telefon numarası başında 0 olmadan 10 haneli ve sayısal olmalıdır!");
            RuleFor(b => b.Email).NotEmpty().WithMessage("Mail Boş Geçilemez!");
            RuleFor(b => b.Email).Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
             .WithMessage("test@test.com formatında olmalıdır!");
            RuleFor(b => b.Address).NotEmpty().WithMessage("Adres Boş Geçilemez!");
        }
    }
}
