using System;
using System.Collections.Generic;

namespace MyWebApi.FBEntities
{
    public partial class VwUser
    {
        public int UserId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordSand { get; set; } = null!;
        public int UserStatusId { get; set; }
        public string UserStatusDesc { get; set; } = null!;
        public int SecurityQuestionId { get; set; }
        public string SecurityQuestion { get; set; } = null!;
        public string SecurityQuestionAnswer { get; set; } = null!;
        public int CurrentGroupId { get; set; }
    }
}
