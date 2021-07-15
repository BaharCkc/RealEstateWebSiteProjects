using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Data.Configuration
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Role)
            .WithMany(x => x.UserList)
           .HasForeignKey(x => x.RoleId);

            builder.Metadata.FindNavigation(nameof(User.AnnouncementsList)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(User.UserProfileList)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
