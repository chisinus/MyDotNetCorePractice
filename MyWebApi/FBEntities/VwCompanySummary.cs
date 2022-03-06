using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwCompanySummary
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public DateTime CompanyCreatedOn { get; set; }
        public int CompanyStatusId { get; set; }
        public string CompanyStatusDesc { get; set; } = null!;
        public int? Projects { get; set; }
        public int? Users { get; set; }
        public DateTime CompanyRemovedOn { get; set; }
    }
}
