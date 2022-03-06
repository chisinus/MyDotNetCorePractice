using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwPageControl
    {
        public int ControlId { get; set; }
        public int InputSetId { get; set; }
        public string ControlName { get; set; } = null!;
        public int ControlTypeId { get; set; }
        public string ControlTypeDesc { get; set; } = null!;
        public int ValueSourceId { get; set; }
        public string ValueSourceDesc { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
