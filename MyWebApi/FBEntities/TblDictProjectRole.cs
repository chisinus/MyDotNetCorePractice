using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictProjectRole
    {
        public TblDictProjectRole()
        {
            TblInvitations = new HashSet<TblInvitation>();
            TblUserProjects = new HashSet<TblUserProject>();
        }

        public int ProjectRoleId { get; set; }
        public string ProjectRoleDesc { get; set; } = null!;

        public virtual ICollection<TblInvitation> TblInvitations { get; set; }
        public virtual ICollection<TblUserProject> TblUserProjects { get; set; }
    }
}
