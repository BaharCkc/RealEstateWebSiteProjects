using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Data.Configuration
{
    public class AnnouncementCategoryConfiguration :BaseConfiguration<AnnouncementCategory>
    {
        public override void Configure(EntityTypeBuilder<AnnouncementCategory> builder)
        {
            base.Configure(builder);

            builder.Metadata.FindNavigation(nameof(AnnouncementCategory.AnnouncementsList)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
