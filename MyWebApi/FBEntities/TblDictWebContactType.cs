using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictWebContactType
    {
        public TblDictWebContactType()
        {
            TblWebContacts = new HashSet<TblWebContact>();
        }

        public int ContactTypeId { get; set; }
        public string ContactTypeDesc { get; set; } = null!;

        public virtual ICollection<TblWebContact> TblWebContacts { get; set; }
    }
}
