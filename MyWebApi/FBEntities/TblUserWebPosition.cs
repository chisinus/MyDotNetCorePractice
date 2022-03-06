using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblUserWebPosition
    {
        public int CurrentId { get; set; }
        public string Wpid { get; set; } = null!;
        public int CurrentUserId { get; set; }
        public int CurrentGroupId { get; set; }

        public virtual TblUser CurrentUser { get; set; } = null!;
    }
}
