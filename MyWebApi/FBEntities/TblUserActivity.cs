using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblUserActivity
    {
        public int UserActivityId { get; set; }
        public int UserId { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityLog { get; set; } = null!;
        public DateTime ActivityTime { get; set; }

        public virtual TblDictActivityType ActivityType { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}
