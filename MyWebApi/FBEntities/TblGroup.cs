using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblGroup
    {
        public TblGroup()
        {
            TblGroupInputSets = new HashSet<TblGroupInputSet>();
        }

        public int GroupId { get; set; }
        public int ProjectId { get; set; }
        public string GroupName { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int GroupTypeId { get; set; }

        public virtual TblUser CreatedByNavigation { get; set; } = null!;
        public virtual TblDictGroupType GroupType { get; set; } = null!;
        public virtual TblProject Project { get; set; } = null!;
        public virtual ICollection<TblGroupInputSet> TblGroupInputSets { get; set; }
    }
}
