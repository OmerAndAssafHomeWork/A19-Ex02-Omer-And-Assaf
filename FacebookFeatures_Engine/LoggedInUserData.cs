using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookFeatures_Engine
{
    public class LoggedInUserData
    {
        public List<FacebookUser> Friends { get; set; }

        public FacebookUser BestFriend { get; set; }

        public DateTime SaveTime { get; set; }
    }
}
