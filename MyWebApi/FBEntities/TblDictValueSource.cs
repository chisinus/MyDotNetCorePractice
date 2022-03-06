using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictValueSource
    {
        public TblDictValueSource()
        {
            TblProjectControls = new HashSet<TblProjectControl>();
        }

        public int ValueSourceId { get; set; }
        public string ValueSourceDesc { get; set; } = null!;

        public virtual ICollection<TblProjectControl> TblProjectControls { get; set; }
    }
}
