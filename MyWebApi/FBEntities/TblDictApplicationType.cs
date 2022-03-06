using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictApplicationType
    {
        public int ApplicationTypeId { get; set; }
        public string ApplicationTypeDesc { get; set; } = null!;
    }
}
