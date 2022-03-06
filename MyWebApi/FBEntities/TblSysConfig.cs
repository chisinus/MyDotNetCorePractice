using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblSysConfig
    {
        public int CurrentVersion { get; set; }
        public string ScriptFolder { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
    }
}
