using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SingletonCreator;

namespace FacebookFeatures_Engine
{
     public class ManagerProxy : IManager
     {
          private const int k_NotFound = -1, k_SaveDataMinutes = 20;
          private string m_CurrentLoggedInUserId;
          private EngineManager m_Manager;
          private Dictionary<string, LoggedInUserData> m_LoggedInUsers = new Dictionary<string, LoggedInUserData>();

          private ManagerProxy()
          {
               m_Manager = EngineManager.GetEngineManager();
          }

          public static ManagerProxy GetEngineManager()
          {
               return Singleton<ManagerProxy>.Instance;
          }

          public string GetFriendFirstName(int i_FriendIndex)
          {
               return m_Manager.GetFriendFirstName(i_FriendIndex);
          }

          public List<string> GetFriends()
          {
               m_LoggedInUsers[m_CurrentLoggedInUserId].Friends = m_Manager.Friends;

               return m_Manager.GetFriends();
          }

          public bool SetNextPictureAlbumIndex(int i_FriendIndex)
          {
               return m_Manager.SetNextPictureAlbumIndex(i_FriendIndex);
          }

          public bool SetPrevPictureAlbumIndex()
          {
               return m_Manager.SetPrevPictureAlbumIndex();
          }

          public bool SetPrevPlaceHolderIndex()
          {
               return m_Manager.SetPrevPlaceHolderIndex();
          }

          public bool SetNextCheckinIndex(int i_FriendIndex)
          {
               return m_Manager.SetNextCheckinIndex(i_FriendIndex);
          }

          public bool SetNextPostIndex(int i_FriendIndex)
          {
               return m_Manager.SetNextPostIndex(i_FriendIndex);
          }

          public bool SetNextTagIndex(int i_FriendIndex)
          {
               return m_Manager.SetNextTagIndex(i_FriendIndex);
          }

          public bool SetNextAlbumIndex(int i_FriendIndex)
          {
               return m_Manager.SetNextAlbumIndex(i_FriendIndex);
          }

          public string GetPost(int i_FriendIndex, ref string io_PictureURL)
          {
               return m_Manager.GetPost(i_FriendIndex, ref io_PictureURL);
          }

          public string GetCheckin(int i_FriendIndex)
          {
               return m_Manager.GetCheckin(i_FriendIndex);
          }

          public string GetTag(int i_FriendIndex)
          {
               return m_Manager.GetTag(i_FriendIndex);
          }

          public void InitialAlbumIndexes()
          {
               m_Manager.InitialAlbumIndexes();
          }

          public string GetFriendPicture(int i_FriendIndex)
          {
               return m_Manager.GetFriendPicture(i_FriendIndex);
          }

          public string GetPictureTitle(int i_FriendIndex)
          {
               return m_Manager.GetPictureTitle(i_FriendIndex);
          }

          public string GetAlbumName(int i_FriendIndex)
          {
               return m_Manager.GetAlbumName(i_FriendIndex);
          }

          public string GetPictureFromAlbum(int i_FriendIndex)
          {
               return m_Manager.GetPictureFromAlbum(i_FriendIndex);
          }

          public void Sort(int i_Index)
          {
               m_Manager.Sort(i_Index);
          }

          public string GetFriendBirthdayOrAgeAttribute(int i_FriendIndex, int i_SortingBySelectedIndex)
          {
               return m_Manager.GetFriendBirthdayOrAgeAttribute(i_FriendIndex, i_SortingBySelectedIndex);
          }

          public FacebookUser FindBestFriend()
          {
               FacebookUser bestFriend = m_Manager.FindBestFriend();
               if (bestFriend != null)
               {
                    m_LoggedInUsers[m_CurrentLoggedInUserId].BestFriend = bestFriend;
               }

               return bestFriend;
          }

          public string GetBestFriendFullName()
          {
               return m_Manager.GetBestFriendFullName();
          }

          public string GetBestFriendBirthdayDate()
          {
               return m_Manager.GetBestFriendBirthdayDate();
          }

          public bool IsBestFriendExist()
          {
               return m_Manager.IsBestFriendExist();
          }

          public void CreateEvent(string i_Description, string i_Location)
          {
               m_Manager.CreateEvent(i_Description, i_Location);
          }

          public string GetBestFriendGender()
          {
               return m_Manager.GetBestFriendGender();
          }

          public void LoginUser()
          {
               FacebookUser loggedInUser = m_Manager.ConnectToFacebook();
               m_CurrentLoggedInUserId = loggedInUser.Id;
               if (loggedInUser != null && m_LoggedInUsers.ContainsKey(loggedInUser.Id))
               {
                    TimeSpan deltaTime = DateTime.Now - m_LoggedInUsers[loggedInUser.Id].SaveTime;
                    if (deltaTime.TotalMinutes <= k_SaveDataMinutes)
                    {
                         initialUserData(m_CurrentLoggedInUserId);
                         m_Manager.InitialFindBestFriendData();
                         m_Manager.SetFeaturesFriends();
                    }
               }
               else
               {
                    m_Manager.LoginUser();
                    m_LoggedInUsers.Add(m_CurrentLoggedInUserId, new LoggedInUserData());
               }

               m_LoggedInUsers[m_CurrentLoggedInUserId].SaveTime = DateTime.Now;
          }

          private void initialUserData(string i_Id)
          {
               m_Manager.Friends = m_LoggedInUsers[i_Id].Friends;
               m_Manager.SetBestFriend(m_LoggedInUsers[i_Id].BestFriend);
          }

          public void LogoutUser()
          {
               m_Manager.LogoutUser();
          }

          public string GetLoginUserName()
          {
               return m_Manager.GetLoginUserName();
          }

          public bool UserConnected()
          {
               return m_Manager.UserConnected();
          }
     }
}
