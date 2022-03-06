using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwCurrent
    {
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public int CurrentUserId { get; set; }
        public int GroupId { get; set; }
        public string Wpid { get; set; } = null!;
    }
}
