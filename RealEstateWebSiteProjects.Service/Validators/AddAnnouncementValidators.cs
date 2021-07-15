using FluentValidation;
using RealEstateWebSiteProjects.Contract.CustomModels.Announcement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Service.Validators
{
    public class AddAnnouncementValidators : AbstractValidator<AddAnnouncementModel>
    {
        public AddAnnouncementValidators()
        {
            RuleFor(b => b.Header).NotEmpty().WithMessage("İlan Adı Boş Geçilemez!");
            RuleFor(b => b.Address).NotEmpty().WithMessage("Adres Boş Geçilemez!");
            RuleFor(b => b.AnnouncementCategoryId).NotEmpty().WithMessage("Kategori Boş Geçilemez!");
            RuleFor(b => b.AnnouncementTypeId).NotEmpty().WithMessage("Tip Boş Geçilemez!");
            RuleFor(b => b.CityId).NotEmpty().WithMessage("Şehir Boş Geçilemez!");
            RuleFor(b => b.CountyId).NotEmpty().WithMessage("İlçe Boş Geçilemez!");
            RuleFor(b => b.UploadFile).NotEmpty().WithMessage("Dosya Boş Geçilemez!");
            RuleFor(b => b.Price).NotEmpty().WithMessage("Fiyat Boş Geçilemez!");
            RuleFor(b => b.NetSquareMeter).NotEmpty().WithMessage("Net Mk Boş Geçilemez!");
            RuleFor(b => b.GrossSquareMeter).NotEmpty().WithMessage("Brüt Mk Boş Geçilemez!");
            RuleFor(b => b.NumberOfRooms).NotEmpty().WithMessage("Oda Sayısı Boş Geçilemez!");
            RuleFor(b => b.FloorLocation).NotEmpty().WithMessage("Bulunduğu Kat Boş Geçilemez!");
            RuleFor(b => b.Price).GreaterThan(0).WithMessage("Fiyat 0'dan Büyük Olmalıdır!");
        }
    }
}
