using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictStatus
    {
        public TblDictStatus()
        {
            TblCompanies = new HashSet<TblCompany>();
            TblInvitations = new HashSet<TblInvitation>();
            TblProjects = new HashSet<TblProject>();
            TblUserCompanies = new HashSet<TblUserCompany>();
            TblUserProjects = new HashSet<TblUserProject>();
        }

        public int StatusId { get; set; }
        public string StatusDesc { get; set; } = null!;

        public virtual ICollection<TblCompany> TblCompanies { get; set; }
        public virtual ICollection<TblInvitation> TblInvitations { get; set; }
        public virtual ICollection<TblProject> TblProjects { get; set; }
        public virtual ICollection<TblUserCompany> TblUserCompanies { get; set; }
        public virtual ICollection<TblUserProject> TblUserProjects { get; set; }
    }
}
