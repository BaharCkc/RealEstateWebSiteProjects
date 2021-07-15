using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Data.Configuration
{
    public class CityConfiguration : BaseConfiguration<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);

            builder.Metadata.FindNavigation(nameof(City.AnnouncementsList)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(City.CountyList)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
