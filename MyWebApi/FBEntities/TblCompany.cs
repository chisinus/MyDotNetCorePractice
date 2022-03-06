using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblCompany
    {
        public TblCompany()
        {
            TblInvitations = new HashSet<TblInvitation>();
            TblProjects = new HashSet<TblProject>();
            TblUserCompanies = new HashSet<TblUserCompany>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public DateTime CompanyCreatedOn { get; set; }
        public DateTime CompanyRemovedOn { get; set; }
        public int StatusId { get; set; }

        public virtual TblDictStatus Status { get; set; } = null!;
        public virtual ICollection<TblInvitation> TblInvitations { get; set; }
        public virtual ICollection<TblProject> TblProjects { get; set; }
        public virtual ICollection<TblUserCompany> TblUserCompanies { get; set; }
    }
}
