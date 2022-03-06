using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictControlType
    {
        public TblDictControlType()
        {
            TblProjectControls = new HashSet<TblProjectControl>();
        }

        public int ControlTypeId { get; set; }
        public string ControlTypeDesc { get; set; } = null!;
        public int ApplicationTypeId { get; set; }

        public virtual ICollection<TblProjectControl> TblProjectControls { get; set; }
    }
}
