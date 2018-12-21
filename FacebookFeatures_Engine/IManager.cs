using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookFeatures_Engine
{
     public interface IManager
     {
          string GetFriendFirstName(int i_FriendIndex);
          List<string> GetFriends();
          bool SetPrevPictureAlbumIndex();
          bool SetPrevPlaceHolderIndex();
          bool SetNextCheckinIndex(int i_FriendIndex);
          bool SetNextPostIndex(int i_FriendIndex);
          bool SetNextTagIndex(int i_FriendIndex);
          bool SetNextAlbumIndex(int i_FriendIndex);
          string GetPost(int i_FriendIndex, ref string io_PictureURL);
          string GetCheckin(int i_FriendIndex);
          string GetTag(int i_FriendIndex);
          void InitialAlbumIndexes();
          string GetFriendPicture(int i_FriendIndex);
          string GetPictureTitle(int i_FriendIndex);
          string GetAlbumName(int i_FriendIndex);
          string GetPictureFromAlbum(int i_FriendIndex);
          void Sort(int i_Index);
          string GetFriendBirthdayOrAgeAttribute(int i_FriendIndex, int i_SortingBySelectedIndex);
          int FindBestFriend();
          string GetBestFriendFullName();
          string GetBestFriendBirthdayDate();
          bool IsBestFriendExist();
          void CreateEvent(string i_Description, string i_Location);
          string GetBestFriendTopTag();
          string GetBestFriendGender();
          int GetBestFriendAmountOfAlbums();
          string GetBestFriendTopCheckIn();
          void LoginUser();
          void LogoutUser();
          string GetLoginUserName();
          bool UserConnected();
     }
}
