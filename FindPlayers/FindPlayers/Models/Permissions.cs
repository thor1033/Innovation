using System;
using System.Collections.Generic;
using System.Text;

namespace FindPlayers.Models
{
    public class Permissions {
        public bool Error { get; set; }
        public string Error_Message { get; set; }
        public string Error_Code { get; set; }
        public List<PermissionsResult> Result { get; set; }
    }

    public class PermissionsResult {
        public bool Edit { get; set; }
        public bool Illness { get; set; }
        public bool Timeoff { get; set; }
        public bool Bonus { get; set; }
    }
}
