using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FacebookFeatures_Engine;

namespace FacebookFeatures_UI
{
     public class FeaturesFacade
     {
          private SortingFriendsControl m_SortingFriends;
          private FindBestFriendControl m_FindBestFriend;
          private Control m_ContainerScreen;
          private IManager m_EngineManager;
          private object m_LockedObject = new object();

          public FeaturesFacade(Control i_ContainerScreen)
          {
               m_ContainerScreen = i_ContainerScreen;
               m_EngineManager = ManagerProxy.GetEngineManager();
               initialControls();
          }

          public void LogoutUser()
          {
               m_EngineManager.LogoutUser();
          }

          public void LoginUser()
          {
               m_EngineManager.LoginUser();
               initialControls();
          }

          public bool UserConnected()
          {
               return m_EngineManager.UserConnected();
          }

          public string GetLoginUserName()
          {
               return m_EngineManager.GetLoginUserName();
          }

          private void initialControls()
          {
               m_SortingFriends = new SortingFriendsControl();
               m_FindBestFriend = new FindBestFriendControl();
          }

          public void ExecuteFeature(FeaturesTypeEnum i_FeatureType)
          {
               switch (i_FeatureType)
               {
                    case FeaturesTypeEnum.SortingFriends:
                         {
                              Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature++;
                              new Thread(displaySortingFriendsFeature).Start();
                              break;
                         }

                    case FeaturesTypeEnum.FindBestFriend:
                         {
                              new Thread(displayFindBestFriendFeature).Start();
                              break;
                         }
               }
          }

          private void displaySortingFriendsFeature()
          {
               if (m_EngineManager.UserConnected())
               {
                    lock (m_LockedObject)
                    {
                         m_ContainerScreen.Invoke(new Action(() => m_ContainerScreen.Controls.Clear()));
                         m_ContainerScreen.Invoke(new Action(() => m_ContainerScreen.Controls.Add(m_SortingFriends)));
                         m_SortingFriends.FetchFriends();
                    }
               }
               else
               {
                    m_ContainerScreen.Invoke(new Action(() => MessageBox.Show(Common.NoConnectionToFacebook)));
               }

               Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature--;
          }

          private void displayFindBestFriendFeature()
          {
               if (m_EngineManager.UserConnected())
               {
                    m_ContainerScreen.Invoke(new Action(() => m_ContainerScreen.Controls.Clear()));
                    m_ContainerScreen.Invoke(new Action(() => m_ContainerScreen.Controls.Add(m_FindBestFriend)));
               }
               else
               {
                    m_ContainerScreen.Invoke(new Action(() => MessageBox.Show(Common.NoConnectionToFacebook)));
               }
          }
     }
}
