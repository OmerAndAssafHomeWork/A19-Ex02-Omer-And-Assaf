using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookFeatures_Engine
{
    public class LoggedInUserData
    {
        public List<FacebookUser> m_Friends { get; set; }

        public FacebookUser m_BestFriend { get; set; }

        public DateTime m_SaveTime { get; set; }
    }
}
