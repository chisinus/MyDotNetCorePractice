using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwInvitation
    {
        public int InvitationId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public int CompanyRoleId { get; set; }
        public string CompanyRoleDescription { get; set; } = null!;
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public int ProjectRoleId { get; set; }
        public string ProjectRoleDescription { get; set; } = null!;
        public string InviteeEmail { get; set; } = null!;
        public int InvitedBy { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime InvitedOn { get; set; }
        public string Description { get; set; } = null!;
        public int StatusId { get; set; }
    }
}
