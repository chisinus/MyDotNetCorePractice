using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblProject
    {
        public TblProject()
        {
            TblGroups = new HashSet<TblGroup>();
            TblInvitations = new HashSet<TblInvitation>();
            TblProjectPages = new HashSet<TblProjectPage>();
            TblUserProjects = new HashSet<TblUserProject>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public int StatusId { get; set; }

        public virtual TblCompany Company { get; set; } = null!;
        public virtual TblDictStatus Status { get; set; } = null!;
        public virtual ICollection<TblGroup> TblGroups { get; set; }
        public virtual ICollection<TblInvitation> TblInvitations { get; set; }
        public virtual ICollection<TblProjectPage> TblProjectPages { get; set; }
        public virtual ICollection<TblUserProject> TblUserProjects { get; set; }
    }
}
