using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper.ObjectModel;

namespace FacebookFeatures_Engine
{
     internal delegate void CreateEvent(string i_Name, DateTime i_StartTime, DateTime? i_EndTime = null, string i_Description = null, string i_Location = null, Event.ePrivacy i_PrivacyType = Event.ePrivacy.Open, string i_PlaceID = null);

     internal class FindBestFriendFeatureEngine
     {
          private const int k_MonthIndex = 0, k_DayIndex = 3, k_YearIndex = 6;
          private const int k_MonthLength = 2, k_DayLength = 2, k_YearLength = 4;
          private const int k_BestFriendNotFound = -1;

          public FacebookUser m_BestFriend { get; set; }

          public List<FacebookUser> m_Friends { get; set; }

          public string m_LoggedInUserId { get; set; }

          public event CreateEvent CreateEventNotifier;

          public int FindBestFriend()
          {
               int bestFriendIndex = k_BestFriendNotFound;
               if (m_BestFriend == null)
               {
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
               }
               else
               {
                    bestFriendIndex = searchBestFriendIndex();
               }

               return bestFriendIndex;
          }

          private int searchBestFriendIndex()
          {
               int bestFriendIndex = k_BestFriendNotFound;
               foreach (FacebookUser friend in m_Friends)
               {
                    bestFriendIndex++;
                    if (m_Friends[bestFriendIndex].Id == m_BestFriend.Id)
                    {
                         break;
                    }
               }

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
                         DateTime friendBirthdayDate = new DateTime(DateTime.Now.Year, int.Parse(friend.Birthday.Substring(k_MonthIndex, k_MonthLength)), int.Parse(friend.Birthday.Substring(k_DayIndex, k_DayLength)));
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
                              if (currentFriend.Id == m_LoggedInUserId)
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
                         if (currentFriend.Id == m_LoggedInUserId)
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
                         if (currentComment.From != null && currentComment.From.Id == m_LoggedInUserId)
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
                         if (currentUser.Id == m_LoggedInUserId)
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
                    CreateEventNotifier.Invoke(
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
