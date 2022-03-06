using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwProjectSummary
    {
        public int? Users { get; set; }
        public int? Pages { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public DateTime ProjectCreatedOn { get; set; }
        public int ProjectStatusId { get; set; }
        public string ProjectStatusDesc { get; set; } = null!;
        public DateTime ProjectDeletedOn { get; set; }
        public int CompanyId { get; set; }
    }
}
