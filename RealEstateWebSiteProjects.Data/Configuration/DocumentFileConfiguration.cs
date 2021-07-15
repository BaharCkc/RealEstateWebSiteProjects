using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Data.Configuration
{
    public class DocumentFileConfiguration : BaseConfiguration<DocumentFile>
    {
        public override void Configure(EntityTypeBuilder<DocumentFile> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Announcements)
            .WithMany(x => x.DocumentFileList)
           .HasForeignKey(x => x.AnnouncementId);
        }
    }
}
