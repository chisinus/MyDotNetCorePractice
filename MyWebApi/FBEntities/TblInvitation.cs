using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblInvitation
    {
        public int InvitationId { get; set; }
        public int CompanyId { get; set; }
        public int CompanyRoleId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectRoleId { get; set; }
        public string InviteeEmail { get; set; } = null!;
        public int InvitedBy { get; set; }
        public DateTime InvitedOn { get; set; }
        public string Description { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual TblCompany Company { get; set; } = null!;
        public virtual TblDictCompanyRole CompanyRole { get; set; } = null!;
        public virtual TblUser InvitedByNavigation { get; set; } = null!;
        public virtual TblProject Project { get; set; } = null!;
        public virtual TblDictProjectRole ProjectRole { get; set; } = null!;
        public virtual TblDictStatus Status { get; set; } = null!;
    }
}
