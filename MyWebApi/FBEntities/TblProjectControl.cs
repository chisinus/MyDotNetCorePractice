using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblProjectControl
    {
        public int ControlId { get; set; }
        public int InputSetId { get; set; }
        public string ControlName { get; set; } = null!;
        public int ControlTypeId { get; set; }
        public int ValueSourceId { get; set; }
        public string Value { get; set; } = null!;

        public virtual TblDictControlType ControlType { get; set; } = null!;
        public virtual TblProjectInputSet InputSet { get; set; } = null!;
        public virtual TblDictValueSource ValueSource { get; set; } = null!;
    }
}
