using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SingletonCreator;

namespace FacebookFeatures_Engine
{
     public class EngineManager
     {
          private readonly object r_LogoutObjectContext = new object();
          private const int k_CollectionsLimit = 20;
          private const string k_AppId = "1027335734116799", k_PublicProfile = "public_profile", k_UsersFriend = "user_friends",
              k_UserBirthday = "user_birthday", k_UserGender = "user_gender",
              k_UserLikes = "user_likes", k_UserPosts = "user_posts", k_UserTaggedPlace = "user_tagged_places";
          private FacebookUser m_LoggedInUser;
          private SortingFriendsFeatureEngine m_SortingFriendsEngine;
          private FindBestFriendFeatureEngine m_FindBestFriendEngine;
          private List<FacebookUser> m_Friends;

          private EngineManager()
          {
               m_SortingFriendsEngine = new SortingFriendsFeatureEngine();
               m_FindBestFriendEngine = new FindBestFriendFeatureEngine();
               m_SortingFriendsEngine.m_FetchFriendsNotifier += fetchFriends;
          }

          public static EngineManager GetEngineManager()
          {
               return Singleton<EngineManager>.Instance;
          }

          public string GetFriendFirstName(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.GetFriendFirstName(i_FriendIndex);
          }

          public List<string> GetFriends()
          {
               return m_SortingFriendsEngine.GetFriends();
          }

          public bool SetNextPictureAlbumIndex(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.SetNextPictureAlbumIndex(i_FriendIndex);
          }

          public bool SetPrevPictureAlbumIndex()
          {
               return m_SortingFriendsEngine.SetPrevPictureAlbumIndex();
          }

          public bool SetPrevPlaceHolderIndex()
          {
               return m_SortingFriendsEngine.SetPrevPlaceHolderIndex();
          }

          public bool SetNextCheckinIndex(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.SetNextCheckinIndex(i_FriendIndex);
          }

          public bool SetNextPostIndex(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.SetNextPostIndex(i_FriendIndex);
          }

          public bool SetNextTagIndex(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.SetNextTagIndex(i_FriendIndex);
          }

          public bool SetNextAlbumIndex(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.SetNextAlbumIndex(i_FriendIndex);
          }

          public string GetPost(int i_FriendIndex, ref string io_PictureURL)
          {
               return m_SortingFriendsEngine.GetPost(i_FriendIndex, ref io_PictureURL);
          }

          public string GetCheckin(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.GetCheckin(i_FriendIndex);
          }

          public string GetTag(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.GetTag(i_FriendIndex);
          }

          public void InitialAlbumIndexes()
          {
               m_SortingFriendsEngine.InitialAlbumIndexes();
          }

          public string GetFriendPicture(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.GetFriendPicture(i_FriendIndex);
          }

          public string GetPictureTitle(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.GetPictureTitle(i_FriendIndex);
          }

          public string GetAlbumName(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.GetAlbumName(i_FriendIndex);
          }

          public string GetPictureFromAlbum(int i_FriendIndex)
          {
               return m_SortingFriendsEngine.GetPictureFromAlbum(i_FriendIndex);
          }

          public void Sort(int i_Index)
          {
               m_SortingFriendsEngine.Sort(i_Index);
          }

          public string GetFriendBirthdayOrAgeAttribute(int i_FriendIndex, int i_SortingBySelectedIndex)
          {
               return m_SortingFriendsEngine.GetFriendBirthdayOrAgeAttribute(i_FriendIndex, i_SortingBySelectedIndex);
          }

          public int FindBestFriend()
          {
               return m_FindBestFriendEngine.FindBestFriend();
          }

          public string GetBestFriendFullName()
          {
               return m_FindBestFriendEngine.GetBestFriendFullName();
          }

          public string GetBestFriendBirthdayDate()
          {
               return m_FindBestFriendEngine.GetBestFriendBirthdayDate();
          }

          public bool IsBestFriendExist()
          {
               return m_FindBestFriendEngine.IsBestFriendExist();
          }

          public void CreateEvent(string i_Description, string i_Location)
          {
               m_FindBestFriendEngine.CreateEvent(i_Description, i_Location);
          }

          public string GetBestFriendTopTag()
          {
               return m_FindBestFriendEngine.GetBestFriendTopTag();
          }

          public string GetBestFriendGender()
          {
               return m_FindBestFriendEngine.GetBestFriendGender();
          }

          public int GetBestFriendAmountOfAlbums()
          {
               return m_FindBestFriendEngine.GetBestFriendAmountOfAlbums();
          }

          public string GetBestFriendTopCheckIn()
          {
               return m_FindBestFriendEngine.GetBestFriendTopCheckIn();
          }

          public void LoginUser()
          {
               try
               {
                    FacebookService.s_CollectionLimit = k_CollectionsLimit;
                    LoginResult result = FacebookService.Login(k_AppId, k_PublicProfile, k_UsersFriend, k_UserBirthday, k_UserGender, k_UserLikes, k_UserPosts, k_UserTaggedPlace);
                    if (!string.IsNullOrEmpty(result.AccessToken))
                    {
                         m_LoggedInUser = new FacebookUser(result.LoggedInUser);
                         new Thread(fetchFriends).Start();
                    }
                    m_FindBestFriendEngine.m_LoggedInUserId = m_LoggedInUser.Id;
                    m_FindBestFriendEngine.m_CreateEventNotifier += m_LoggedInUser.CreateEvent;
               }
               catch (FacebookOAuthException e)
               {
                    throw new Exception();
               }
          }

          public void LogoutUser()
          {
               lock (r_LogoutObjectContext)
               {
                    if (m_LoggedInUser != null)
                    {
                         FacebookService.Logout(null);
                         m_Friends.Clear();
                         m_LoggedInUser = null;
                         m_FindBestFriendEngine.m_BestFriend = null;
                    }
               }
          }

          public string GetLoginUserName()
          {
               return m_LoggedInUser.Name;
          }



          public bool UserConnected()
          {
               return m_LoggedInUser != null;
          }

          private void fetchFriends()
          {
               m_Friends = new List<FacebookUser>();
               foreach (User friend in m_LoggedInUser.Friends)
               {
                    m_Friends.Add(new FacebookUser(friend));
               }

               m_SortingFriendsEngine.m_Friends = m_Friends;
               m_FindBestFriendEngine.m_Friends = m_Friends;
          }


     }
}
