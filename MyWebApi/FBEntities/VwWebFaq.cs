using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwWebFaq
    {
        public int Faqid { get; set; }
        public string Faqtitle { get; set; } = null!;
        public string Faqdetails { get; set; } = null!;
        public int FaqtypeId { get; set; }
        public string FaqtypeDesc { get; set; } = null!;
    }
}
