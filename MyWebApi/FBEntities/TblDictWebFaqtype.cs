using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictWebFaqtype
    {
        public TblDictWebFaqtype()
        {
            TblWebFaqs = new HashSet<TblWebFaq>();
        }

        public int FaqtypeId { get; set; }
        public string FaqtypeDesc { get; set; } = null!;

        public virtual ICollection<TblWebFaq> TblWebFaqs { get; set; }
    }
}
