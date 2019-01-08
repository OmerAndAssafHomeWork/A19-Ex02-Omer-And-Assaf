using System;
using System.Collections.Generic;
using System.Threading;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using SingletonCreator;

namespace FacebookFeatures_Engine
{
     public class EngineManager : IManager
     {
          private const int k_CollectionsLimit = 5, k_BestFriendNotFound = -1;
          private const string k_AppId = "1027335734116799", k_PublicProfile = "public_profile", k_UsersFriend = "user_friends",
              k_UserBirthday = "user_birthday", k_UserGender = "user_gender",
              k_UserLikes = "user_likes", k_UserPosts = "user_posts", k_UserTaggedPlace = "user_tagged_places";

          private readonly object r_LogoutObjectContext = new object();

          public FacebookUser LoggedInUser { get; set; }

          private SortingFriendsFeatureEngine m_SortingFriendsEngine;
          private FindBestFriendFeatureEngine m_FindBestFriendEngine;

          public List<FacebookUser> Friends { get; set; }

          private EngineManager()
          {
               m_SortingFriendsEngine = new SortingFriendsFeatureEngine();
               m_FindBestFriendEngine = new FindBestFriendFeatureEngine();
               m_SortingFriendsEngine.FetchFriendsNotifier += fetchFriends;
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

          public FacebookUser FindBestFriend()
          {
               int bestFriendIndex = m_FindBestFriendEngine.FindBestFriend();

               if (bestFriendIndex != k_BestFriendNotFound)
               {
                    setMyBestFriend(bestFriendIndex);
               }

               return m_FindBestFriendEngine.BestFriend;
          }

          private void setMyBestFriend(int i_BestFriendIndex)
          {
               m_FindBestFriendEngine.BestFriend = Friends[i_BestFriendIndex];
               m_FindBestFriendEngine.BestFriend.AmountOfAlbums = getBestFriendAmountOfAlbums().ToString();
               m_FindBestFriendEngine.BestFriend.MostTaggedUser = getBestFriendTopTag() ?? "No Tags Available";
               m_FindBestFriendEngine.BestFriend.MostCommonCheckin = getBestFriendTopCheckIn() ?? "No Checkins Available";
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

          private string getBestFriendTopTag()
          {
               return m_FindBestFriendEngine.GetBestFriendTopTag();
          }

          public string GetBestFriendGender()
          {
               return m_FindBestFriendEngine.GetBestFriendGender();
          }

          private int getBestFriendAmountOfAlbums()
          {
               return m_FindBestFriendEngine.GetBestFriendAmountOfAlbums();
          }

          private string getBestFriendTopCheckIn()
          {
               return m_FindBestFriendEngine.GetBestFriendTopCheckIn();
          }

          public FacebookUser ConnectToFacebook()
          {
               if (LoggedInUser == null)
               {
                    LoginResult result = FacebookService.Login(k_AppId, k_PublicProfile, k_UsersFriend, k_UserBirthday, k_UserGender, k_UserLikes, k_UserPosts, k_UserTaggedPlace);
                    if (!string.IsNullOrEmpty(result.AccessToken))
                    {
                         LoggedInUser = new FacebookUser(result.LoggedInUser);
                    }
               }

               return LoggedInUser;
          }

          public void LoginUser()
          {
               try
               {
                    FacebookService.s_CollectionLimit = k_CollectionsLimit;
                    ConnectToFacebook();
                    if (LoggedInUser != null)
                    {
                         fetchFriends();
                    }

                    InitialFindBestFriendData();
               }
               catch (FacebookOAuthException)
               {
                    throw new Exception();
               }
          }

          public void InitialFindBestFriendData()
          {
               m_FindBestFriendEngine.LoggedInUserId = LoggedInUser.Id;
               m_FindBestFriendEngine.CreateEventNotifier += LoggedInUser.CreateEvent;
          }

          public void LogoutUser()
          {
               lock (r_LogoutObjectContext)
               {
                    if (LoggedInUser != null)
                    {
                         FacebookService.Logout(null);
                         Friends = null;
                         LoggedInUser = null;
                         m_FindBestFriendEngine.BestFriend = null;
                    }
               }
          }

          public string GetLoginUserName()
          {
               return LoggedInUser.Name;
          }

          public void SetBestFriend(FacebookUser i_BestFriend)
          {
               m_FindBestFriendEngine.BestFriend = i_BestFriend;
          }

          public bool UserConnected()
          {
               return LoggedInUser != null;
          }

          private void fetchFriends()
          {
               Friends = new List<FacebookUser>();
               foreach (User friend in LoggedInUser)
               {
                    Friends.Add(new FacebookUser(friend));
               }

               SetFeaturesFriends();
          }

          public void SetFeaturesFriends()
          {
               m_SortingFriendsEngine.Friends = Friends;
               m_FindBestFriendEngine.Friends = Friends;
          }

        public void SetBirthdayInRangeMethod(Func<DateTime, bool> i_CompareMethod)
        {
            m_FindBestFriendEngine.ComparerMethod = i_CompareMethod;
        }
    }
}
