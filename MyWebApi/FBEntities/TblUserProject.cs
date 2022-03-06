using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class TblUserProject
    {
        public int UserProjectId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectRoleId { get; set; }
        public int StatusId { get; set; }
        public DateTime ProjectJoinedOn { get; set; }
        public DateTime ProjectRemovedOn { get; set; }

        public virtual TblProject Project { get; set; } = null!;
        public virtual TblDictProjectRole ProjectRole { get; set; } = null!;
        public virtual TblDictStatus Status { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}
