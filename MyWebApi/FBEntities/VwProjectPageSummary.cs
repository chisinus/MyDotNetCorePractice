using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwProjectPageSummary
    {
        public int ProjectId { get; set; }
        public int PageId { get; set; }
        public string PageName { get; set; } = null!;
        public int? InputSets { get; set; }
    }
}
