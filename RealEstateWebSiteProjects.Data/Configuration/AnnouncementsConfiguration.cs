using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Data.Configuration
{
    public class AnnouncementsConfiguration : BaseConfiguration<Announcements>
    {
        public override void Configure(EntityTypeBuilder<Announcements> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.User)
            .WithMany(x => x.AnnouncementsList)
           .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.AnnouncementCategory)
            .WithMany(x => x.AnnouncementsList)
           .HasForeignKey(x => x.AnnouncementCategoryId);

            builder.HasOne(x => x.AnnouncementType)
            .WithMany(x => x.AnnouncementsList)
           .HasForeignKey(x => x.AnnouncementTypeId);

            builder.HasOne(x => x.City)
            .WithMany(x => x.AnnouncementsList)
           .HasForeignKey(x => x.CityId);

            builder.Metadata.FindNavigation(nameof(Announcements.DocumentFileList)).SetPropertyAccessMode(PropertyAccessMode.Field);
            // builder.HasOne(x => x.County)
            // .WithMany(x => x.AnnouncementsList)
            //.HasForeignKey(x => x.CountyId);

        }
    }
}
