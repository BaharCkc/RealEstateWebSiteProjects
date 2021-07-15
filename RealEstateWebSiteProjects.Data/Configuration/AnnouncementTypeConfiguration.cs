using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Data.Configuration
{
    public class AnnouncementTypeConfiguration : BaseConfiguration<AnnouncementType>
    {
        public override void Configure(EntityTypeBuilder<AnnouncementType> builder)
        {
            base.Configure(builder);

            builder.Metadata.FindNavigation(nameof(AnnouncementType.AnnouncementsList)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
