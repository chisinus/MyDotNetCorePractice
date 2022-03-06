using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblUserCompany
    {
        public int UserCompanyId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string EmailAddress { get; set; } = null!;
        public int CompanyRoleId { get; set; }
        public int StatusId { get; set; }
        public DateTime CompanyJoinedOn { get; set; }
        public DateTime CompanyRemovedOn { get; set; }

        public virtual TblCompany Company { get; set; } = null!;
        public virtual TblDictCompanyRole CompanyRole { get; set; } = null!;
        public virtual TblDictStatus Status { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}
