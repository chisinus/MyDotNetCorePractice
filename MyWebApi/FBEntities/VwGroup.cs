using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwGroup
    {
        public int GroupId { get; set; }
        public int ProjectId { get; set; }
        public string GroupName { get; set; } = null!;
        public DateTime GroupCreatedOn { get; set; }
        public int GroupCreatedBy { get; set; }
        public string GroupCreatedByFirstname { get; set; } = null!;
        public string GroupCreatedByLastname { get; set; } = null!;
        public int GroupTypeId { get; set; }
        public string GroupTypeDesc { get; set; } = null!;
    }
}
