using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictSecurityQuestion
    {
        public int SecurityQuestionId { get; set; }
        public string SecurityQuestion { get; set; } = null!;
    }
}
