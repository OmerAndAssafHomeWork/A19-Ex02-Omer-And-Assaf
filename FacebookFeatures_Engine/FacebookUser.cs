using System;
using FacebookWrapper.ObjectModel;
using Facebook;

namespace FacebookFeatures_Engine
{
    public class FacebookUser
    {
        private User m_FacebookUser;
          public string AmountOfAlbums { get; set; }
          public string MostCommonCheckin { get; set; }
          public string MostTaggedUser { get; set; }

        public FacebookUser(User i_FacebookUser)
        {
            m_FacebookUser = i_FacebookUser;
        }

        public FacebookObjectCollection<User> Friends
        {
            get
            {
                return m_FacebookUser.Friends;
            }
        }

        public string FirstName
        {
            get
            {
                return m_FacebookUser.FirstName;
            }
        }

        public string LastName
        {
            get
            {
                return m_FacebookUser.LastName;
            }
        }

        public FacebookObjectCollection<Album> Albums
        {
            get
            {
                try
                {
                    return m_FacebookUser.Albums;
                }
                catch (FacebookOAuthException ex)
                {
                    throw ex;
                }
            }
        }

        public string PictureLargeURL
        {
            get
            {
                return m_FacebookUser.PictureLargeURL;
            }
        }

        public FacebookObjectCollection<Photo> PhotosTaggedIn
        {
            get
            {
                try
                {
                    return m_FacebookUser.PhotosTaggedIn;
                }
                catch (FacebookOAuthException ex)
                {
                    throw ex;
                }
            }
        }

        public FacebookObjectCollection<Checkin> Checkins
        {
            get
            {
                try
                {
                    return m_FacebookUser.Checkins;
                }
                catch (FacebookOAuthException ex)
                {
                    throw ex;
                }
            }
        }

        public FacebookObjectCollection<Post> Posts
        {
            get
            {
                try
                {
                    return m_FacebookUser.Posts;
                }
                catch (FacebookOAuthException ex)
                {
                    throw ex;
                }
            }
        }

        public string Name
        {
            get
            {
                return m_FacebookUser.Name;
            }
        }

        public string Gender
        {
            get
            {
                return m_FacebookUser.Gender.ToString();
            }
        }

        public string Birthday
        {
            get
            {
                return m_FacebookUser.Birthday;
            }
        }

        public string Id
        {
            get
            {
                return m_FacebookUser.Id;
            }
        }

        public void CreateEvent(string i_Name, DateTime i_StartTime, DateTime? i_EndTime = null, string i_Description = null, string i_Location = null, Event.ePrivacy i_PrivacyType = Event.ePrivacy.Open, string i_PlaceID = null)
        {
            m_FacebookUser.CreateEvent_DeprecatedSinceV2(i_Name, i_StartTime, i_EndTime, i_Description, i_Location, i_PrivacyType, i_PlaceID);
        }
    }
}
