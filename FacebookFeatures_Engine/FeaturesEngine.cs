using System;
using System.Collections.Generic;
using Facebook;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using eSortingByEnum;
using System.Threading;

namespace FacebookFeatures_Engine
{
    public class FeaturesEngine : IFilterSort
    {
        private const int k_NotInitialized = -1, k_ChangePositions = 1, k_NotChangePosition = -1, k_BestFriendNotFound = -1, k_IndexNotFound = -1;
        private const string k_AppId = "1027335734116799", k_PublicProfile = "public_profile", k_UsersFriend = "user_friends",
            k_UserBirthday = "user_birthday", k_UserGender = "user_gender",
            k_UserLikes = "user_likes", k_UserPosts = "user_posts", k_UserTaggedPlace = "user_tagged_places";

        private const int k_MonthLength = 2, k_DayLength = 2, k_YearLength = 4;
        private const int k_MonthIndex = 0, k_DayIndex = 3, k_YearIndex = 6, k_CollectionsLimit = 20;
        private readonly object r_LogoutObjectContext = new object();
        private FacebookUser m_LoggedInUser;
        private FacebookUser m_BestFriend;
        private List<FacebookUser> m_Friends;
        private int m_AlbumPictureIndex = 0;
        private int m_PlaceHolderIndex = 0;

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
                    m_BestFriend = null;
                }
            }
        }

        public string GetFriendFirstName(int i_FriendIndex)
        {
            return m_Friends[i_FriendIndex].FirstName;
        }

        public string GetLoginUserName()
        {
            return m_LoggedInUser.Name;
        }

        private void fetchFriends()
        {
            m_Friends = new List<FacebookUser>();
            foreach (User friend in m_LoggedInUser.Friends)
            {
                m_Friends.Add(new FacebookUser(friend));
            }
        }

        public List<string> GetFriends()
        {
            List<string> friends = new List<string>();

            foreach (FacebookUser friend in m_Friends)
            {
                friends.Add($"{friend.FirstName} {friend.LastName}");
            }

            return friends;
        }

        public string GetPictureFromAlbum(int i_FriendIndex)
        {
            string pictureURL = null;
            if (m_Friends[i_FriendIndex].Albums.Count > 0 && m_Friends[i_FriendIndex].Albums[m_PlaceHolderIndex].Photos.Count > 0)
            {
                pictureURL = m_Friends[i_FriendIndex].Albums[m_PlaceHolderIndex].Photos[m_AlbumPictureIndex].Images[0].Source;
            }

            return pictureURL;
        }

        public string GetAlbumName(int i_FriendIndex = k_NotInitialized)
        {
            return m_Friends[i_FriendIndex].Albums[m_PlaceHolderIndex].Name;
        }

        public string GetPictureTitle(int i_FriendIndex)
        {
            return m_Friends[i_FriendIndex].Albums[m_PlaceHolderIndex].Photos[m_AlbumPictureIndex].Name;
        }

        public string GetFriendPicture(int i_FriendIndex)
        {
            return m_Friends[i_FriendIndex].PictureLargeURL;
        }

        public void InitialAlbumIndexes()
        {
            m_AlbumPictureIndex = m_PlaceHolderIndex = 0;
        }

        public string GetTag(int i_FriendIndex)
        {
            string tag = null;
            if (m_Friends[i_FriendIndex].PhotosTaggedIn.Count > 0)
            {
                tag = m_Friends[i_FriendIndex].PhotosTaggedIn[m_PlaceHolderIndex].Message;
            }

            return tag;
        }

        public string GetCheckin(int i_FriendIndex)
        {
            string checkin = null;
            if (m_Friends[i_FriendIndex].Checkins.Count > 0)
            {
                checkin = m_Friends[i_FriendIndex].Checkins[m_PlaceHolderIndex].Message;
            }

            return checkin;
        }

        public string GetPost(int i_FriendIndex, ref string io_PictureURL)
        {
            const string k_EmptyPost = "Empty Post";
            string post = null;

            if (m_Friends[i_FriendIndex].Posts.Count > 0)
            {
                if (m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].Message != null)
                {
                    post = m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].Message;
                }
                else if (m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].Caption != null)
                {
                    post = m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].Caption;
                }
                else if (m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].Description != null)
                {
                    post = m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].Description;
                }
                else if (m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].Name != null)
                {
                    post = m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].Name;
                }
                else
                {
                    post = k_EmptyPost;
                }

                if (m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].Type == Post.eType.photo)
                {
                    io_PictureURL = m_Friends[i_FriendIndex].Posts[m_PlaceHolderIndex].PictureURL;
                }
            }

            return post;
        }

        public bool SetNextAlbumIndex(int i_FriendIndex)
        {
            var setNextAlbumSucceed = false;
            if (m_PlaceHolderIndex + 1 < m_Friends[i_FriendIndex].Albums.Count)
            {
                setNextAlbumSucceed = true;
                m_PlaceHolderIndex++;
                m_AlbumPictureIndex = 0;
            }

            return setNextAlbumSucceed;
        }

        public bool SetNextTagIndex(int i_FriendIndex)
        {
            var setNextTagSucceed = false;
            if (m_PlaceHolderIndex + 1 < m_Friends[i_FriendIndex].PhotosTaggedIn.Count)
            {
                setNextTagSucceed = true;
                m_PlaceHolderIndex++;
            }

            return setNextTagSucceed;
        }

        public bool SetNextPostIndex(int i_FriendIndex)
        {
            bool setNextTagSucceed = false;
            if (m_PlaceHolderIndex + 1 < m_Friends[i_FriendIndex].Posts.Count)
            {
                setNextTagSucceed = true;
                m_PlaceHolderIndex++;
            }

            return setNextTagSucceed;
        }

        public bool SetNextCheckinIndex(int i_FriendIndex)
        {
            bool setNextCheckinSucceed = false;
            if (m_PlaceHolderIndex + 1 < m_Friends[i_FriendIndex].Checkins.Count)
            {
                setNextCheckinSucceed = true;
                m_PlaceHolderIndex++;
            }

            return setNextCheckinSucceed;
        }

        public bool SetPrevPlaceHolderIndex()
        {
            bool setPrevAlbumSucceed = false;

            if (m_PlaceHolderIndex - 1 >= 0)
            {
                setPrevAlbumSucceed = true;
                m_PlaceHolderIndex--;
                m_AlbumPictureIndex = 0;
            }

            return setPrevAlbumSucceed;
        }

        public bool SetPrevPictureAlbumIndex()
        {
            bool setPrevPictureInAlbumSucceed = false;

            if (m_AlbumPictureIndex - 1 >= 0)
            {
                setPrevPictureInAlbumSucceed = true;
                m_AlbumPictureIndex--;
            }

            return setPrevPictureInAlbumSucceed;
        }

        public bool SetNextPictureAlbumIndex(int i_FriendIndex)
        {
            bool setNextPictureInAlbumSucceed = false;

            if (m_AlbumPictureIndex + 1 < m_Friends[i_FriendIndex].Albums[m_PlaceHolderIndex].Photos.Count)
            {
                setNextPictureInAlbumSucceed = true;
                m_AlbumPictureIndex++;
            }

            return setNextPictureInAlbumSucceed;
        }

        public string GetFriendBirthdayOrAgeAttribute(int i_FriendIndex, int i_SortingBySelectedIndex = k_NotInitialized)
        {
            eSortingBy sortingOption = (eSortingBy)i_SortingBySelectedIndex;
            string returnValue = null;

            if (i_FriendIndex != k_IndexNotFound)
            {
                if (sortingOption == eSortingBy.Birthday)
                {
                    returnValue = $"Birthday Date: {m_Friends[i_FriendIndex].Birthday}";
                }
                else if (sortingOption == eSortingBy.Age)
                {
                    string birthday = m_Friends[i_FriendIndex].Birthday;
                    DateTime birthdayDate = new DateTime(
                         int.Parse(birthday.Substring(k_YearIndex, k_YearLength)),
                         int.Parse(birthday.Substring(k_MonthIndex, k_MonthLength)),
                         int.Parse(birthday.Substring(k_DayIndex, k_DayLength)));
                    returnValue = $"Age: {calculateAge(birthdayDate)}";
                }
            }

            return returnValue;
        }

        public void Sort(int i_Index)
        {
            sortFriends(i_Index);
        }

        private void sortFriends(int i_ComparisonIndex = k_NotInitialized)
        {
            eSortingBy comparisonBy = (eSortingBy)i_ComparisonIndex;
            switch (comparisonBy)
            {
                case eSortingBy.Default:
                    {
                        fetchFriends();
                        break;
                    }

                case eSortingBy.FirstName:
                    {
                        m_Friends.Sort(firstNameComparison);
                        break;
                    }

                case eSortingBy.LastName:
                    {
                        m_Friends.Sort(lastNameComparison);
                        break;
                    }

                case eSortingBy.Birthday:
                    {
                        m_Friends.Sort(birthDayComparison);
                        break;
                    }

                case eSortingBy.Age:
                    {
                        m_Friends.Sort(ageComparison);
                        break;
                    }

                case eSortingBy.MostPosts:
                    {
                        m_Friends.Sort(postsComparison);
                        break;
                    }

                case eSortingBy.MostCheckIns:
                    {
                        m_Friends.Sort(checkInsComparison);
                        break;
                    }

                case eSortingBy.MostTags:
                    {
                        m_Friends.Sort(tagsComparison);
                        break;
                    }

                case eSortingBy.MostAlbums:
                    {
                        m_Friends.Sort(albumsComparison);
                        break;
                    }
            }
        }

        private int firstNameComparison(FacebookUser i_FirstPerson, FacebookUser i_SecondPerson)
        {
            return i_FirstPerson.FirstName.CompareTo(i_SecondPerson.FirstName);
        }

        private int lastNameComparison(FacebookUser i_FirstPerson, FacebookUser i_SecondPerson)
        {
            return i_FirstPerson.LastName.CompareTo(i_SecondPerson.LastName);
        }

        private int birthDayComparison(FacebookUser i_FirstPerson, FacebookUser i_SecondPerson)
        {
            int returnValue, firstPersonMonth, secondPersonMonth, firstPersonDay, secondPersonDay;
            int.TryParse(i_FirstPerson.Birthday.Substring(k_MonthIndex, k_MonthLength), out firstPersonMonth);
            int.TryParse(i_SecondPerson.Birthday.Substring(k_MonthIndex, k_MonthLength), out secondPersonMonth);

            if (firstPersonMonth == secondPersonMonth)
            {
                int.TryParse(i_FirstPerson.Birthday.Substring(k_DayIndex, k_DayLength), out firstPersonDay);
                int.TryParse(i_SecondPerson.Birthday.Substring(k_DayIndex, k_DayLength), out secondPersonDay);
                returnValue = firstPersonDay < secondPersonDay ? k_NotChangePosition : k_ChangePositions;
            }
            else
            {
                returnValue = firstPersonMonth < secondPersonMonth ? k_NotChangePosition : k_ChangePositions;
            }

            return returnValue;
        }

        private int ageComparison(FacebookUser i_FirstPerson, FacebookUser i_SecondPerson)
        {
            DateTime firstPersonBirthday = new DateTime(
                 int.Parse(i_FirstPerson.Birthday.Substring(k_YearIndex, k_YearLength)),
                 int.Parse(i_FirstPerson.Birthday.Substring(k_MonthIndex, k_MonthLength)),
                 int.Parse(i_FirstPerson.Birthday.Substring(k_DayIndex, k_DayLength)));
            DateTime secondPersonBirthday = new DateTime(
                 int.Parse(i_SecondPerson.Birthday.Substring(k_YearIndex, k_YearLength)),
                 int.Parse(i_SecondPerson.Birthday.Substring(k_MonthIndex, k_MonthLength)),
                 int.Parse(i_SecondPerson.Birthday.Substring(k_DayIndex, k_DayLength)));
            int firstPersonAge = calculateAge(firstPersonBirthday);
            int secondPersonAge = calculateAge(secondPersonBirthday);

            return firstPersonAge < secondPersonAge ? k_NotChangePosition : k_ChangePositions;
        }

        private int checkInsComparison(FacebookUser i_FirstPerson, FacebookUser i_SecondPerson)
        {
            return i_FirstPerson.Checkins.Count.CompareTo(i_SecondPerson.Checkins.Count);
        }

        private int tagsComparison(FacebookUser i_FirstPerson, FacebookUser i_SecondPerson)
        {
            return i_FirstPerson.PhotosTaggedIn.Count.CompareTo(i_SecondPerson.PhotosTaggedIn.Count);
        }

        private int albumsComparison(FacebookUser i_FirstPerson, FacebookUser i_SecondPerson)
        {
            return i_FirstPerson.Albums.Count.CompareTo(i_SecondPerson.Albums.Count);
        }

        private int postsComparison(FacebookUser i_FirstPerson, FacebookUser i_SecondPerson)
        {
            return i_FirstPerson.Posts.Count.CompareTo(i_SecondPerson.Posts.Count);
        }

        private int calculateAge(DateTime i_Birthday)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - i_Birthday.Year;

            if ((now.Month == i_Birthday.Month && now.Day < i_Birthday.Day) || now.Month < i_Birthday.Month)
            {
                age--;
            }

            return age;
        }

        public bool UserConnected()
        {
            return m_LoggedInUser != null;
        }

        public int FindBestFriend()
        {
            int bestFriendIndex = k_BestFriendNotFound;
            Dictionary<FacebookUser, int> friendsHierarchy = new Dictionary<FacebookUser, int>();
            foreach (FacebookUser friend in m_Friends)
            {
                foreach (Post currentPost in friend.Posts)
                {
                    updateBestFriendDictionaryByLikePost(currentPost, friendsHierarchy, friend);
                    updateBestFriendDictionaryByCommentPost(currentPost, friendsHierarchy, friend);
                    updateBestFriendDictionaryByWithUsersPost(currentPost, friendsHierarchy, friend);
                    updateBestFriendDictionaryByTargetUsersPost(currentPost, friendsHierarchy, friend);
                }
            }

            bestFriendIndex = searchForBestFriendAfterAnalyzing(friendsHierarchy);

            return bestFriendIndex;
        }

        private int searchForBestFriendAfterAnalyzing(Dictionary<FacebookUser, int> i_FriendsHierarchy)
        {
            int bestFriendIndex = k_BestFriendNotFound;
            int index = 0;
            int bestFriendcommonFriendsAmount = 0;

            foreach (FacebookUser friend in m_Friends)
            {
                if (i_FriendsHierarchy.ContainsKey(friend))
                {
                    DateTime friendBirthdayDate = new DateTime(DateTime.Now.Year + 1, int.Parse(friend.Birthday.Substring(k_MonthIndex, k_MonthLength)), int.Parse(friend.Birthday.Substring(k_DayIndex, k_DayLength)));
                    if (birthdayMonthInRange(friendBirthdayDate))
                    {
                        if (i_FriendsHierarchy[friend] > bestFriendcommonFriendsAmount)
                        {
                            m_BestFriend = friend;
                            bestFriendcommonFriendsAmount = i_FriendsHierarchy[friend];
                            bestFriendIndex = index;
                        }
                        else if (i_FriendsHierarchy[friend] == bestFriendcommonFriendsAmount)
                        {
                            m_BestFriend = getEalierBirthdayFriend(friend, m_BestFriend);
                            if (m_BestFriend == friend)
                            {
                                bestFriendIndex = index;
                            }
                        }
                    }
                }

                index++;
            }

            return bestFriendIndex;
        }

        private void updateBestFriendDictionaryByTargetUsersPost(Post i_CurrentPost, Dictionary<FacebookUser, int> i_FriendsHierarchy, FacebookUser i_Friend)
        {
            try
            {
                if (i_CurrentPost.TargetUsers != null)
                {
                    foreach (User currentFriend in i_CurrentPost.TargetUsers)
                    {
                        if (currentFriend.Id == m_LoggedInUser.Id)
                        {
                            if (i_FriendsHierarchy.ContainsKey(i_Friend))
                            {
                                i_FriendsHierarchy[i_Friend] += 4;
                            }
                            else
                            {
                                i_FriendsHierarchy.Add(i_Friend, 4);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                /// the tagged users can not be supplied in some posts
            }
        }

        private void updateBestFriendDictionaryByWithUsersPost(Post i_CurrentPost, Dictionary<FacebookUser, int> i_FriendsHierarchy, FacebookUser i_Friend)
        {
            try
            {
                foreach (User currentFriend in i_CurrentPost.WithUsers)
                {
                    if (currentFriend.Id == m_LoggedInUser.Id)
                    {
                        if (i_FriendsHierarchy.ContainsKey(i_Friend))
                        {
                            i_FriendsHierarchy[i_Friend] += 3;
                        }
                        else
                        {
                            i_FriendsHierarchy.Add(i_Friend, 3);
                        }
                    }
                }
            }
            catch (Exception)
            {
                /// the tagged users can not be supplied in some posts
            }
        }

        private void updateBestFriendDictionaryByCommentPost(Post i_CurrentPost, Dictionary<FacebookUser, int> i_FriendsHierarchy, FacebookUser i_Friend)
        {
            try
            {
                foreach (Comment currentComment in i_CurrentPost.Comments)
                {
                    if (currentComment.From != null && currentComment.From.Id == m_LoggedInUser.Id)
                    {
                        if (i_FriendsHierarchy.ContainsKey(i_Friend))
                        {
                            i_FriendsHierarchy[i_Friend] += 2;
                        }
                        else
                        {
                            i_FriendsHierarchy.Add(i_Friend, 2);
                        }
                    }
                }
            }
            catch (Exception)
            {
                /// the comment can not be supplied in some posts
            }
        }

        private void updateBestFriendDictionaryByLikePost(Post i_CurrentPost, Dictionary<FacebookUser, int> i_FriendsHierarchy, FacebookUser i_Friend)
        {
            try
            {
                foreach (User currentUser in i_CurrentPost.LikedBy)
                {
                    if (currentUser.Id == m_LoggedInUser.Id)
                    {
                        if (i_FriendsHierarchy.ContainsKey(i_Friend))
                        {
                            i_FriendsHierarchy[i_Friend]++;
                        }
                        else
                        {
                            i_FriendsHierarchy.Add(i_Friend, 1);
                        }
                    }
                }
            }
            catch (Exception)
            {
                /// the likedByUsers can not be supplied in some posts
            }
        }

        private FacebookUser getEalierBirthdayFriend(FacebookUser i_FirstFriend, FacebookUser i_SecondFriend)
        {
            DateTime firstFriendBirthdayDate = new DateTime(DateTime.Now.Year + 1, int.Parse(i_FirstFriend.Birthday.Substring(k_MonthIndex, k_MonthLength)), int.Parse(i_FirstFriend.Birthday.Substring(k_DayIndex, k_DayLength)));
            DateTime secondFriendBirthdayDate = new DateTime(DateTime.Now.Year + 1, int.Parse(i_SecondFriend.Birthday.Substring(k_MonthIndex, k_MonthLength)), int.Parse(i_SecondFriend.Birthday.Substring(k_DayIndex, k_DayLength)));

            return firstFriendBirthdayDate < secondFriendBirthdayDate ? i_FirstFriend : i_SecondFriend;
        }

        private bool birthdayMonthInRange(DateTime i_FriendBirthdayDate)
        {
            return (i_FriendBirthdayDate - DateTime.Now).TotalDays <= 120;
        }

        public string GetBestFriendFullName()
        {
            return $"{m_BestFriend.FirstName} {m_BestFriend.LastName}";
        }

        public string GetBestFriendBirthdayDate()
        {
            return m_BestFriend.Birthday;
        }

        public bool IsBestFriendExist()
        {
            return m_BestFriend != null;
        }

        public void CreateEvent(string i_Description, string i_Location)
        {
            DateTime startTime, endTime;
            int birthdayYearDate = DateTime.Now.Month >= 11 ? DateTime.Now.Year + 1 : DateTime.Now.Year;

            startTime = new DateTime(birthdayYearDate, int.Parse(m_BestFriend.Birthday.Substring(k_MonthIndex, k_MonthLength)), int.Parse(m_BestFriend.Birthday.Substring(k_DayIndex, k_DayLength)), 19, 0, 0);
            endTime = new DateTime(birthdayYearDate, int.Parse(m_BestFriend.Birthday.Substring(k_MonthIndex, k_MonthLength)), int.Parse(m_BestFriend.Birthday.Substring(k_DayIndex, k_DayLength)), 22, 0, 0);
            try
            {
                m_LoggedInUser.CreateEvent(
                     $"Suprise party to {m_BestFriend.FirstName} ",
                     startTime,
                     endTime,
                     i_Description,
                     i_Location,
                     Event.ePrivacy.Secret);
            }
            catch (FacebookOAuthException)
            {
            }
        }

        public string GetBestFriendTopTag()
        {
            FacebookUser mostTagged = null;
            Dictionary<FacebookUser, int> taggedUsers = new Dictionary<FacebookUser, int>();

            foreach (Post currentPost in m_BestFriend.Posts)
            {
                try
                {
                    foreach (User currentUser in currentPost.TaggedUsers)
                    {
                        FacebookUser currentFriend = findFriend(currentUser);
                        if (taggedUsers.ContainsKey(currentFriend))
                        {
                            taggedUsers[currentFriend]++;
                        }
                        else
                        {
                            taggedUsers.Add(currentFriend, 1);
                        }
                    }
                }
                catch (Exception)
                {
                    /// the tagged users can not be supplied in some posts
                }
            }

            foreach (FacebookUser currentUser in taggedUsers.Keys)
            {
                try
                {
                    if (mostTagged == null)
                    {
                        mostTagged = currentUser;
                    }
                    else if (taggedUsers[currentUser] > taggedUsers[mostTagged])
                    {
                        mostTagged = currentUser;
                    }
                }
                catch (FacebookOAuthException)
                {
                    /// the tagged users can not be supplied in some posts
                }
            }

            return mostTagged == null ? null : mostTagged.Name;
        }

        private FacebookUser findFriend(User i_Friend)
        {
            FacebookUser currentFriend = null;
            foreach (FacebookUser friend in m_Friends)
            {
                if (friend.Id == i_Friend.Id)
                {
                    currentFriend = friend;
                    break;
                }
            }

            return currentFriend;
        }

        public string GetBestFriendTopCheckIn()
        {
            string mostTagged = null;
            Dictionary<string, int> checkIns = new Dictionary<string, int>();

            foreach (Checkin currentCheckIn in m_BestFriend.Checkins)
            {
                if (checkIns.ContainsKey(currentCheckIn.Place.Name))
                {
                    checkIns[currentCheckIn.Place.Name]++;
                }
                else
                {
                    checkIns.Add(currentCheckIn.Place.Name, 1);
                }
            }

            foreach (string currentCheckIn in checkIns.Keys)
            {
                if (mostTagged == null)
                {
                    mostTagged = currentCheckIn;
                }
                else if (checkIns[currentCheckIn] > checkIns[mostTagged])
                {
                    mostTagged = currentCheckIn;
                }
            }

            return mostTagged == null ? null : mostTagged;
        }

        public int GetBestFriendAmountOfAlbums()
        {
            return m_BestFriend.Albums.Count;
        }

        public string GetBestFriendGender()
        {
            return m_BestFriend.Gender.ToString();
        }
    }
}