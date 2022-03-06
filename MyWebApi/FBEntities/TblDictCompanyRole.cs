using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictCompanyRole
    {
        public TblDictCompanyRole()
        {
            TblInvitations = new HashSet<TblInvitation>();
            TblUserCompanies = new HashSet<TblUserCompany>();
        }

        public int CompanyRoleId { get; set; }
        public string CompanyRoleDescription { get; set; } = null!;

        public virtual ICollection<TblInvitation> TblInvitations { get; set; }
        public virtual ICollection<TblUserCompany> TblUserCompanies { get; set; }
    }
}
