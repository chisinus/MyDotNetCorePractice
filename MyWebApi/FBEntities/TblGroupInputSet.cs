using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblGroupInputSet
    {
        public int GroupInputSetId { get; set; }
        public int GroupId { get; set; }
        public int InputSetId { get; set; }

        public virtual TblGroup Group { get; set; } = null!;
        public virtual TblProjectInputSet InputSet { get; set; } = null!;
    }
}
