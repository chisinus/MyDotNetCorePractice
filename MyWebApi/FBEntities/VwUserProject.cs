using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwUserProject
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public DateTime ProjectCreatedOn { get; set; }
        public int ProjectStatusId { get; set; }
        public string ProjectStatusDesc { get; set; } = null!;
        public int UserId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordSand { get; set; } = null!;
        public int UserStatusId { get; set; }
        public int SecurityQuestionId { get; set; }
        public string UserStatusDesc { get; set; } = null!;
        public string SecurityQuestion { get; set; } = null!;
        public string SecurityQuestionAnswer { get; set; } = null!;
        public int CompanyId { get; set; }
        public int UserProjectRoleId { get; set; }
        public string UserProjectRoleDesc { get; set; } = null!;
        public DateTime ProjectJoinedOn { get; set; }
        public int UserProjectStatusId { get; set; }
        public string UserProjectStatusDesc { get; set; } = null!;
        public int UserProjectId { get; set; }
        public int CurrentGroupId { get; set; }
        public DateTime ProjectDeletedOn { get; set; }
    }
}
