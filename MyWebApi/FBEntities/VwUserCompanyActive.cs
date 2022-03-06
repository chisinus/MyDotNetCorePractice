using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwUserCompanyActive
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordSand { get; set; } = null!;
        public int SecurityQuestionId { get; set; }
        public string SecurityQuestion { get; set; } = null!;
        public string SecurityQuestionAnswer { get; set; } = null!;
        public int UserStatusId { get; set; }
        public string UserStatusDesc { get; set; } = null!;
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public DateTime CompanyCreatedOn { get; set; }
        public int CompanyStatusId { get; set; }
        public string CompanyStatusDesc { get; set; } = null!;
        public int? UserCompanyRoleId { get; set; }
        public DateTime? CompanyJoinedOn { get; set; }
        public string UserCompanyRoleDesc { get; set; } = null!;
        public int? Projects { get; set; }
        public int? UserCompanyStatusId { get; set; }
        public string UserCompanyStatusDesc { get; set; } = null!;
        public int? UserCompanyId { get; set; }
    }
}
