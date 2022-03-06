using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwGroupActive
    {
        public int GroupId { get; set; }
        public int ProjectId { get; set; }
        public string GroupName { get; set; } = null!;
        public DateTime GroupCreatedOn { get; set; }
        public int GroupCreatedBy { get; set; }
        public int GroupTypeId { get; set; }
        public string GroupTypeDesc { get; set; } = null!;
    }
}
