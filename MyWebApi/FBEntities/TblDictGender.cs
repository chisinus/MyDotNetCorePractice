using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictGender
    {
        public TblDictGender()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public int GenderTypeId { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
