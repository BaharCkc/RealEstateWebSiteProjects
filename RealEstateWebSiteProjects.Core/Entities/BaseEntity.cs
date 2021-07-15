using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RealEstateWebSiteProjects.Core.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }

        [JsonIgnore]
        public Guid RecordUserId { get; set; }

        [JsonIgnore]
        public Guid? UpdateUserId { get; set; }

        [JsonIgnore]
        public DateTime RecordDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
