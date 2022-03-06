using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwCompany
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public DateTime CompanyCreatedOn { get; set; }
        public int CompanyStatusId { get; set; }
        public string CompanyStatusDesc { get; set; } = null!;
        public DateTime CompanyRemovedOn { get; set; }
    }
}
