using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwProjectGroupSummary
    {
        public int? InputSets { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public DateTime GroupCreatedOn { get; set; }
        public string GroupCreatedByFirstname { get; set; } = null!;
        public string GroupCreatedByLastname { get; set; } = null!;
        public int ProjectId { get; set; }
        public int GroupCreatedBy { get; set; }
        public int GroupTypeId { get; set; }
        public string GroupTypeDesc { get; set; } = null!;
    }
}
