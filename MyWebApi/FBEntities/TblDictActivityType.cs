using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblDictActivityType
    {
        public TblDictActivityType()
        {
            TblUserActivities = new HashSet<TblUserActivity>();
        }

        public int ActivityTypeId { get; set; }
        public string ActivityTypeDescription { get; set; } = null!;

        public virtual ICollection<TblUserActivity> TblUserActivities { get; set; }
    }
}
