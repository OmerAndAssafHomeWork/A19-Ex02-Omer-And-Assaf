using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookFeatures_Engine;

namespace FacebookFeatures_UI
{
    public class UserFriends : IEnumerable<string>, IEnumerable
    {
        private ManagerProxy m_Engine;
        private List<string> m_UserFriends;

        public UserFriends()
        {
            m_Engine = ManagerProxy.GetEngineManager();
            m_UserFriends = m_Engine.GetFriends();
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string friend in m_UserFriends)
            {
                yield return friend;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
