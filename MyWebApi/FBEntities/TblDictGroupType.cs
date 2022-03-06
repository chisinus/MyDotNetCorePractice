using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictGroupType
    {
        public TblDictGroupType()
        {
            TblGroups = new HashSet<TblGroup>();
        }

        public int GroupTypeId { get; set; }
        public string GroupTypeDesc { get; set; } = null!;

        public virtual ICollection<TblGroup> TblGroups { get; set; }
    }
}
