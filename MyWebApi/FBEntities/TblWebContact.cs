using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblWebContact
    {
        public int ContactId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int ContactTypeId { get; set; }
        public string Subject { get; set; } = null!;
        public string Details { get; set; } = null!;

        public virtual TblDictWebContactType ContactType { get; set; } = null!;
    }
}
