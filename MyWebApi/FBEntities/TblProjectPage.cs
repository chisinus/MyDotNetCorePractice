using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblProjectPage
    {
        public TblProjectPage()
        {
            TblProjectInputSets = new HashSet<TblProjectInputSet>();
        }

        public int PageId { get; set; }
        public string PageName { get; set; } = null!;
        public int ProjectId { get; set; }

        public virtual TblProject Project { get; set; } = null!;
        public virtual ICollection<TblProjectInputSet> TblProjectInputSets { get; set; }
    }
}
