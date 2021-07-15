using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Data.Configuration
{
    public class CountyConfiguration : BaseConfiguration<County>
    {
        public override void Configure(EntityTypeBuilder<County> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.City)
            .WithMany(x => x.CountyList)
           .HasForeignKey(x => x.CityId);

            //builder.Metadata.FindNavigation(nameof(County.AnnouncementsList)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
