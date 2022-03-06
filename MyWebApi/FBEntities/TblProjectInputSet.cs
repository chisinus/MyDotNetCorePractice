using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblProjectInputSet
    {
        public TblProjectInputSet()
        {
            TblGroupInputSets = new HashSet<TblGroupInputSet>();
            TblProjectControls = new HashSet<TblProjectControl>();
        }

        public int InputSetId { get; set; }
        public string InputSetName { get; set; } = null!;
        public int PageId { get; set; }

        public virtual TblProjectPage Page { get; set; } = null!;
        public virtual ICollection<TblGroupInputSet> TblGroupInputSets { get; set; }
        public virtual ICollection<TblProjectControl> TblProjectControls { get; set; }
    }
}
