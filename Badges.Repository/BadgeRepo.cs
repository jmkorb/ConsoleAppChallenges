
using Badges_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgeRepo
    {
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        public bool Create(Badge badge)
        {
            if (badge == default)
            {
                return false;
            }
            else if(CheckIfBadgeExists(badge.BadgeID))
            {
                return false;
            }

            _badgeDictionary.Add(badge.BadgeID, badge.DoorNames);
            return true;
        }
        public Dictionary<int, List<string>> ReturnBadges()
        {
            return _badgeDictionary;
        }

        public bool AddDoor(int badgeNumber, string doorNumber)
        {
            if (!_badgeDictionary.ContainsKey(badgeNumber))
            {
                return false;
            }

            List<string> doorList = _badgeDictionary[badgeNumber];
            doorList.Add(doorNumber);
            return true;
        }

        public bool DeleteDoor(int badgeNumber, string doorNumber)
        {
            if (!_badgeDictionary.ContainsKey(badgeNumber))
            {
                return false;
            }

            List<string> doorList = _badgeDictionary[badgeNumber];
            doorList.Remove(doorNumber);
            return true;
        }

        public bool CheckIfBadgeExists(int badgeNumber)
        {
            if (_badgeDictionary.ContainsKey(badgeNumber))
            {
                return true;
            }
            return false;
        }
    }
}
