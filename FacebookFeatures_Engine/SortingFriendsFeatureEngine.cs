using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSortingByEnum;
using FacebookWrapper.ObjectModel;

namespace FacebookFeatures_Engine
{
    internal delegate void FetchFriends();

    internal class SortingFriendsFeatureEngine : IFilterSort
    {
        private const int k_MonthIndex = 0, k_DayIndex = 3, k_YearIndex = 6;
        private const int k_MonthLength = 2, k_DayLength = 2, k_YearLength = 4;
        private const int k_NotInitialized = -1, k_ChangePositions = 1, k_NotChangePosition = -1, k_IndexNotFound = -1;
        private int m_AlbumPictureIndex = 0;
        private int m_PlaceHolderIndex = 0;

        public event FetchFriends m_FetchFriendsNotifier;

        public List<FacebookUser> m_Friends { get; set; }

        public string GetFriendFirstName(int i_FriendIndex)
        {
            return m_Friends[i_FriendIndex].FirstName;
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
                        m_FetchFriendsNotifier.Invoke();
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
    }
}
