using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwUserActivity
    {
        public int UserActivityId { get; set; }
        public int UserId { get; set; }
        public DateTime ActivityTime { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityLog { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string ActivityTypeDescription { get; set; } = null!;
    }
}
