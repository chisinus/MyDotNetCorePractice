using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblGroups = new HashSet<TblGroup>();
            TblInvitations = new HashSet<TblInvitation>();
            TblUserActivities = new HashSet<TblUserActivity>();
            TblUserCompanies = new HashSet<TblUserCompany>();
            TblUserProjects = new HashSet<TblUserProject>();
            TblUserWebPositions = new HashSet<TblUserWebPosition>();
        }

        public int UserId { get; set; }
        public string? Username { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordSand { get; set; } = null!;
        public int? GenderTypeId { get; set; }
        public int StatusId { get; set; }
        public int SecurityQuestionId { get; set; }
        public string SecurityQuestionAnswer { get; set; } = null!;
        public int CurrentGroupId { get; set; }
        public DateTime Dob { get; set; }

        public virtual TblDictGender? GenderType { get; set; }
        public virtual ICollection<TblGroup> TblGroups { get; set; }
        public virtual ICollection<TblInvitation> TblInvitations { get; set; }
        public virtual ICollection<TblUserActivity> TblUserActivities { get; set; }
        public virtual ICollection<TblUserCompany> TblUserCompanies { get; set; }
        public virtual ICollection<TblUserProject> TblUserProjects { get; set; }
        public virtual ICollection<TblUserWebPosition> TblUserWebPositions { get; set; }
    }
}
