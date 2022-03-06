using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblWebFaq
    {
        public int Faqid { get; set; }
        public int FaqtypeId { get; set; }
        public string Faqtitle { get; set; } = null!;
        public string Faqdetails { get; set; } = null!;

        public virtual TblDictWebFaqtype Faqtype { get; set; } = null!;
    }
}
