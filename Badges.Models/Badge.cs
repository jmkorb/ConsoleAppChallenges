using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Models
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public Badge() { }

        public Badge(int badgeID, List<string> doorNames)
        {
            this.DoorNames = doorNames;
            this.BadgeID = badgeID;
        }
    }
}
