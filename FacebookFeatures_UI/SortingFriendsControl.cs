using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookFeatures_Engine;
using eSortingByEnum;
using System.Threading;

namespace FacebookFeatures_UI
{
     public delegate void getAttributeInfo();
     public partial class SortingFriendsControl : UserControl
     {
          private const int k_InitialValue = -1, k_BestFriendNotFoundIndex = -1;
          private IManager m_Engine = null;
          private int m_currentFriendIndex = k_InitialValue;
          private event getAttributeInfo GetAttributeInfoNotifier;
          private string m_CurrentCalculationSortingFriendsFeature = null;

          public SortingFriendsControl()
          {
               InitializeComponent();
               m_Engine = ManagerProxy.GetEngineManager();
          }

          private void disableFirstFeatureControls()
          {
               Common.setVisibilityControls(
                    false,
                    pictureBoxFriend,
                    placeHolderLabel,
                    pictureBoxAlbumPhoto,
                    labelAttributePlaceHolder,
                    labelPhotoTitle,
                    buttonNextPlaceHolder,
                    buttonPrevPlaceHolder,
                    buttonPrevPicture,
                    buttonNextPicture);
          }

          private void disableWholeControls()
          {
               disableFirstFeatureControls();
          }

          public void FetchFriends()
          {
               List<string> g = new List<string>();
               List<string> friendsName = m_Engine.GetFriends();
               listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Clear()));
               foreach (string friendName in friendsName)
               {
                    listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Add(friendName)));
               }
          }

          private string getPosts()
          {
               string picture = null;
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               string post = m_Engine.GetPost(m_currentFriendIndex, ref picture);
               if (post != null)
               {
                    labelAttributePlaceHolder.Invoke(new Action(() => labelAttributePlaceHolder.Text = post));
               }

               if (picture != null)
               {
                    pictureBoxAlbumPhoto.Invoke(new Action(() => pictureBoxAlbumPhoto.Visible = true));
                    pictureBoxAlbumPhoto.LoadAsync(picture);
               }
               else
               {
                    pictureBoxAlbumPhoto.Invoke(new Action(() => pictureBoxAlbumPhoto.Visible = false));
               }
               return post;
          }

          private string getTags()
          {
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               string tag = m_Engine.GetTag(m_currentFriendIndex);

               if (tag != null)
               {
                    labelAttributePlaceHolder.Invoke(new Action(() => labelAttributePlaceHolder.Text = tag));
               }
               else
               {
                    labelAttributePlaceHolder.Invoke(new Action(() => labelAttributePlaceHolder.Text = " "));
               }
               return tag;
          }

          private string getCheckin()
          {
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               string checkin = m_Engine.GetCheckin(m_currentFriendIndex);

               if (checkin != null)
               {
                    labelAttributePlaceHolder.Invoke(new Action(() => labelAttributePlaceHolder.Text = checkin));
               }
               else
               {
                    labelAttributePlaceHolder.Invoke(new Action(() => labelAttributePlaceHolder.Text = " "));
               }
               return checkin;
          }

          private string getAlbumDetails()
          {
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               string photoFromAlbum = m_Engine.GetPictureFromAlbum(m_currentFriendIndex);
               
               if (photoFromAlbum != null)
               {
                    pictureBoxAlbumPhoto.LoadAsync(photoFromAlbum);
                    labelAttributePlaceHolder.Invoke(new Action (() => labelAttributePlaceHolder.Text = m_Engine.GetAlbumName(m_currentFriendIndex)));
                    labelPhotoTitle.Invoke(new Action (() => labelPhotoTitle.Text = m_Engine.GetPictureTitle(m_currentFriendIndex)));
                    Common.setVisibilityControls(
                         true,
                         pictureBoxAlbumPhoto,
                         labelAttributePlaceHolder,
                         labelPhotoTitle,
                         buttonNextPlaceHolder,
                         buttonPrevPlaceHolder,
                         buttonPrevPicture,
                         buttonNextPicture);
               }
               return photoFromAlbum;
          }

          private void clearButtonsEvents(params Button[] i_ListButtons)
          {
               foreach (Button currentButton in i_ListButtons)
               {
                    Common.ClearEvents(currentButton);
               }
          }

          private void disableAlbum(string i_Error)
          {
               Common.setVisibilityControls(false, labelAttributePlaceHolder, labelPhotoTitle, buttonNextPlaceHolder, buttonPrevPlaceHolder, buttonPrevPicture, buttonNextPicture);
               this.Invoke(new Action(() => MessageBox.Show(i_Error)));///Move to common
          }

          private void suitFunctionalityBySelectedIndex()
          {
               m_Engine.InitialAlbumIndexes();
               eSortingBy userChoice = eSortingBy.Default;
               comboBoxSortingOptions.Invoke(new Action(() => userChoice = (eSortingBy)comboBoxSortingOptions.SelectedIndex));
               switch (userChoice)
               {
                    case eSortingBy.Age:
                         {
                              setBirthdayOrAgeAttribute();
                              break;
                         }

                    case eSortingBy.Birthday:
                         {
                              setBirthdayOrAgeAttribute();
                              break;
                         }

                    case eSortingBy.MostAlbums:
                         {
                              setAlbumsAttributes();
                              break;
                         }

                    case eSortingBy.MostPosts:
                         {
                              setPostsAttributes();
                              break;
                         }

                    case eSortingBy.MostCheckIns:
                         {
                              setCheckInsAttributes();
                              break;
                         }

                    case eSortingBy.MostTags:
                         {
                              setTagsAttributes();
                              break;
                         }
               }
               Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature--;
          }

          private void setAttribute(string i_CurrentCalaculationMessage)
          {
               if (Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature == 0)
               {
                    Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature++;
                    m_CurrentCalculationSortingFriendsFeature = i_CurrentCalaculationMessage;
                    GetAttributeInfoNotifier.Invoke();
                    Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature--;
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show($"{m_CurrentCalculationSortingFriendsFeature} calculation is still working")));
               }
          }

          private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
          {
               if (Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature == 0)
               {
                    Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature++;
                    new Thread(displayFriendAttributes).Start();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show("Another calculation is still working")));
               }
          }

          private void displayFriendAttributes()
          {
               const string k_MoreThanAPersonSelectedError = "You can select only one person to show";
               bool onlyOneSelected = false;
               listBoxFriends.Invoke(new Action(() => onlyOneSelected = listBoxFriends.SelectedItems.Count == 1));
               if (onlyOneSelected)
               {
                    clearButtonsEvents(buttonNextPicture, buttonPrevPicture, buttonNextPlaceHolder, buttonPrevPlaceHolder);
                    int selectedIndex = k_InitialValue;
                    listBoxFriends.Invoke(new Action(() => selectedIndex = listBoxFriends.SelectedIndex));
                    string friendImageURL = m_Engine.GetFriendPicture(selectedIndex);
                    if (friendImageURL != null)
                    {
                         Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature++;
                         new Thread(suitFunctionalityBySelectedIndex).Start();
                         pictureBoxFriend.LoadAsync(friendImageURL);
                         pictureBoxFriend.Invoke(new Action(() => pictureBoxFriend.Visible = true));
                    }
                    else
                    {
                         pictureBoxFriend.Invoke(new Action(() =>pictureBoxFriend.Image = pictureBoxFriend.ErrorImage));
                    }
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(k_MoreThanAPersonSelectedError)));
               }

               Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature--;
          }

          private void setBirthdayOrAgeAttribute()
          {
               int userOptionIndex = k_InitialValue;
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               comboBoxSortingOptions.Invoke(new Action(() => userOptionIndex = comboBoxSortingOptions.SelectedIndex));
               string attribute = m_Engine.GetFriendBirthdayOrAgeAttribute(m_currentFriendIndex, userOptionIndex);

               if (attribute != null)
               {
                    placeHolderLabel.Invoke(new Action(() => placeHolderLabel.Text = attribute));
                    placeHolderLabel.Invoke(new Action(() => placeHolderLabel.Visible = true));
               }
               else
               {
                    placeHolderLabel.Invoke(new Action(() => placeHolderLabel.Visible = false));
               }
          }

          private void setTagsAttributes()
          {
               const string k_PrevTag = "Prev Tag", k_NextTag = "Next Tag";
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               string tagsWerentFoundMessage = $"{m_Engine.GetFriendFirstName(m_currentFriendIndex)} doesn't have Tags";

               if (getTags() != null)
               {
                    buttonPrevPlaceHolder.Invoke(new Action(() => buttonPrevPlaceHolder.Text = k_PrevTag));
                    buttonNextPlaceHolder.Invoke(new Action(() => buttonNextPlaceHolder.Text = k_NextTag));
                    buttonPrevPlaceHolder.Click += buttonPrevTag_Click;
                    buttonNextPlaceHolder.Click += buttonNextTag_Click;
                    Common.setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
               }
               else
               {
                    this.Invoke(new Action (() =>MessageBox.Show(tagsWerentFoundMessage)));
                    Common.setVisibilityControls(false, buttonPrevPicture, buttonNextPicture);
               }
          }

          private void setCheckInsAttributes()
          {
               const string k_PrevCheckin = "Prev Checkin", k_NextCheckin = "Next Checkin";
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               string checkinsWerentFound = $"{m_Engine.GetFriendFirstName(m_currentFriendIndex)} doesn't have checkins";
               if (getCheckin() != null)
               {
                    buttonPrevPlaceHolder.Invoke(new Action(() => buttonPrevPlaceHolder.Text = k_PrevCheckin));
                    buttonNextPlaceHolder.Invoke(new Action(() => buttonNextPlaceHolder.Text = k_NextCheckin));
                    buttonPrevPlaceHolder.Click += buttonPrevCheckIn_Click;
                    buttonNextPlaceHolder.Click += buttonNextCheckIn_Click;
                    Common.setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
               }
               else
               {
                    this.Invoke(new Action (() =>MessageBox.Show(checkinsWerentFound)));
                    Common.setVisibilityControls(false, buttonPrevPicture, buttonNextPicture);
               }
          }

          private void setPostsAttributes()
          {
               const string k_PrevPost = "Prev Post", k_NextPost = "Next Post";
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               string postsWerentFound = $"{m_Engine.GetFriendFirstName(m_currentFriendIndex)} doesn't have posts";
               if (getPosts() != null)
               {
                    buttonPrevPlaceHolder.Invoke(new Action(() => buttonPrevPlaceHolder.Text = k_PrevPost));
                    buttonNextPlaceHolder.Invoke(new Action(() => buttonNextPlaceHolder.Text = k_NextPost));
                    buttonPrevPlaceHolder.Click += buttonPrevPost_Click;
                    buttonNextPlaceHolder.Click += buttonNextPost_Click;
                    Common.setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
               }
               else
               {
                    this.Invoke(new Action (() =>MessageBox.Show(postsWerentFound)));
                    Common.setVisibilityControls(false, labelAttributePlaceHolder, buttonPrevPicture, buttonNextPicture);
               }
          }

          private void setAlbumsAttributes()
          {
               const string prevAlbum = "Prev Album", nextAlbum = "Next Album";
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               string albumsWerentFoundMessage = $"{m_Engine.GetFriendFirstName(m_currentFriendIndex)} selected doesn't have albums";
               if (getAlbumDetails() != null)
               {
                    buttonNextPlaceHolder.Invoke(new Action(() => buttonNextPlaceHolder.Text = nextAlbum));
                    buttonPrevPlaceHolder.Invoke(new Action(() => buttonPrevPlaceHolder.Text = prevAlbum));
                    buttonNextPlaceHolder.Click += buttonNextAlbum_Click;
                    buttonPrevPlaceHolder.Click += buttonPrevAlbum_Click;
                    buttonNextPicture.Click += buttonNextPicture_Click;
                    buttonPrevPicture.Click += buttonPrevPicture_Click;
                    Common.setVisibilityControls(true, labelPhotoTitle, buttonNextPicture, buttonPrevPicture, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
               }
               else
               {
                    disableAlbum(albumsWerentFoundMessage);
               }
          }

          private void comboBoxSortingOption_SelectedIndexChanged(object sender, EventArgs e)
          {
               if (Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature == 0)
               {
                    Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature++;
                    m_CurrentCalculationSortingFriendsFeature = "Selected Friend";
                    new Thread(sortFriendsByUserChoice).Start();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show($"{m_CurrentCalculationSortingFriendsFeature} calculation is still working")));
               }
          }

          private void sortFriendsByUserChoice()
          {
               try
               {
                    int currentUserSortingChoice = k_InitialValue;
                    if (m_Engine.UserConnected())
                    {
                         listBoxFriends.Invoke(new Action(() => currentUserSortingChoice = comboBoxSortingOptions.SelectedIndex));
                         m_Engine.Sort(currentUserSortingChoice);
                         clearButtonsEvents(buttonNextPlaceHolder, buttonPrevPlaceHolder, buttonNextPicture, buttonPrevPicture);
                         FetchFriends();
                         disableFirstFeatureControls();
                    }
                    else
                    {
                         if (currentUserSortingChoice != k_InitialValue)
                         {
                              this.Invoke(new Action(() =>MessageBox.Show(Common.NoConnectionToFacebook)));
                         }

                         comboBoxSortingOptions.Invoke(new Action(() => comboBoxSortingOptions.SelectedIndex = k_InitialValue));
                    }
                    Common.s_AmountOfAntoherThanMainThreadAliveThreadsSortingFriendsFeature--;
               }
               catch (Exception)
               {
                    this.Invoke(new Action(() =>MessageBox.Show(Common.FacebookError)));
               }
          }

          private void buttonPrevAlbum_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setPrevAlbum;
               setAttribute("Prev Album");
               GetAttributeInfoNotifier -= setPrevAlbum;
          }

          private void setPrevAlbum()
          {
               const string k_FirstAlbumError = "You are in the first album";
               if (m_Engine.SetPrevPlaceHolderIndex())
               {
                    getAlbumDetails();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(k_FirstAlbumError)));
               }
          }

          private void buttonNextAlbum_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setNextAlbum;
               setAttribute("Next Album");
               GetAttributeInfoNotifier -= setNextAlbum;
          }

          private void setNextAlbum()
          {
               const string k_LastAlbumError = "You are in the last album";
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               if (m_Engine.SetNextAlbumIndex(m_currentFriendIndex))
               {
                    getAlbumDetails();
               }
               else
               {
                    this.Invoke(new Action(() =>MessageBox.Show(k_LastAlbumError)));
               }
          }

          private void buttonPrevPicture_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setPrevPicture;
               setAttribute("Prev Picture");
               GetAttributeInfoNotifier -= setPrevPicture;
          }

          private void setPrevPicture()
          {
               const string k_FirstPictureError = "You are in the first picture album";
               if (m_Engine.SetPrevPictureAlbumIndex())
               {
                    getAlbumDetails();
               }
               else
               {
                    this.Invoke(new Action (() =>MessageBox.Show(k_FirstPictureError)));
               }

          }

          private void buttonNextPicture_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setNextPicture;
               setAttribute("Next Picture");
               GetAttributeInfoNotifier -= setNextPicture;
          }

          private void setNextPicture()
          {
               const string k_LastPictureError = "You are in the last picture album";
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               if (m_Engine.SetNextPictureAlbumIndex(m_currentFriendIndex))
               {
                    getAlbumDetails();
               }
               else
               {
                    this.Invoke(new Action(() =>MessageBox.Show(k_LastPictureError)));
               }

          }

          private void buttonPrevCheckIn_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setPrevCheckin;
               setAttribute("Prev Checkin");
               GetAttributeInfoNotifier -= setPrevCheckin;
          }

          private void setPrevCheckin()
          {
               const string k_FirstCheckinError = "You are in the first checkin";
               if (m_Engine.SetPrevPlaceHolderIndex())
               {
                    getCheckin();
               }
               else
               {
                    this.Invoke(new Action(() =>MessageBox.Show(k_FirstCheckinError)));
               }
          }

          private void buttonNextCheckIn_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setNextCheckin;
               setAttribute("Next Checkin");
               GetAttributeInfoNotifier -= setNextCheckin;
          }

          private void setNextCheckin()
          {
               const string k_LastCheckinError = "You are in the last checkin";
               listBoxFriends.Invoke(new Action(() => m_currentFriendIndex = listBoxFriends.SelectedIndex));
               if (m_Engine.SetNextCheckinIndex(m_currentFriendIndex))
               {
                    getCheckin();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(k_LastCheckinError)));
               }
          }

          private void buttonPrevPost_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setPrevPost;
               setAttribute("Prev Post");
               GetAttributeInfoNotifier -= setPrevPost;
          }

          private void setPrevPost()
          {
               const string k_FirstPostError = "You are in the first post";
               if (m_Engine.SetPrevPlaceHolderIndex())
               {
                    getPosts();
               }
               else
               {
                    this.Invoke(new Action(() =>MessageBox.Show(k_FirstPostError)));
               }

          }

          private void buttonNextPost_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setNextPost;
               setAttribute("Next Post");
               GetAttributeInfoNotifier -= setNextPost;
          }

          private void setNextPost()
          {
               const string k_LastPostError = "You are in the last post";
               if (m_Engine.SetNextPostIndex(listBoxFriends.SelectedIndex))
               {
                    getPosts();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(k_LastPostError)));
               }

          }

          private void buttonPrevTag_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setPrevTag;
               setAttribute("Prev Tag");
               GetAttributeInfoNotifier -= setPrevTag;
          }

          private void setPrevTag()
          {
               const string k_FirstTagError = "You are in the first tag";
               if (m_Engine.SetPrevPlaceHolderIndex())
               {
                    getTags();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(k_FirstTagError)));
               }
          }

          private void buttonNextTag_Click(object sender, EventArgs e)
          {
               GetAttributeInfoNotifier += setNextTag;
               setAttribute("Next Tag");
               GetAttributeInfoNotifier -= setNextTag;
          }

          private void setNextTag()
          {
               const string k_LastTagError = "You are in the last tag";
               if (m_Engine.SetNextTagIndex(listBoxFriends.SelectedIndex))
               {
                    getTags();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(k_LastTagError)));
               }
          }
     }
}
