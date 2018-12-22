using System;
using System.Windows.Forms;
using FacebookFeatures_Engine;
using System.Threading;

namespace FacebookFeatures_UI
{
     public partial class FindBestFriendControl : UserControl
     {
          private const int k_InitialValue = -1, k_BestFriendNotFoundIndex = -1;
          private ManagerProxy m_Engine;
          
          public FindBestFriendControl()
          {
               InitializeComponent();
               m_Engine = ManagerProxy.GetEngineManager();
          }

          private void disableSecondFeatureControls()
          {
               Common.setVisibilityControls(
                    false,
                    labelFullName,
                    labelBirthdayDate,
                    labelGender,
                    labelMostTaggedUser,
                    labelMostCommonCheckin,
                    labelAlbums,
                    labelNameText,
                    labelBirthdayText,
                    labelGenderText,
                    labelMostTaggedUserText,
                    labelMostTaggedUser,
                    labelAmountOfAlbumsText,
                    pictureLargeURLPictureBox);
          }

          private void disableWholeControls()
          {
               disableSecondFeatureControls();
          }


          private void buttonFindBestFriend_Click(object sender, EventArgs e)
          {
               if (Common.s_AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature == 0)
               {
                    Common.s_AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature++;
                    Common.s_CurrentCalculationFindBestFriendFeature = "Find Best Friend";
                    new Thread(findBestFriend).Start();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show($"{ Common.s_CurrentCalculationFindBestFriendFeature} calculation is still alive")));
               }
          }

          private void findBestFriend()
          {
               const string k_NoExistFriendWithBirthday = "You don't have friends who have birthday in four months";

               if (m_Engine.UserConnected())
               {
                    FacebookUser bestFriend = m_Engine.FindBestFriend();
                    if (bestFriend != null)
                    {                         
                         Common.setVisibilityControls(true, labelMostCommonCheckin, labelMostTaggedUser, labelFullName, labelBirthdayDate, labelGender, labelAlbums, labelAmountOfAlbumsText, labelGenderText, labelNameText, pictureLargeURLPictureBox, labelBirthdayText, labelMostTaggedUserText, labelMostCommonCheckinText);
                         facebookUserBindingSource.DataSource = bestFriend;
                         /*
                         labelAlbumsText.Invoke(new Action(() => labelAlbumsText.Text = m_Engine.getBestFriendAmountOfAlbums().ToString()));
                         labelBirthdayDate.Invoke(new Action(() => labelBirthdayDate.Text = m_Engine.getBestFriendBirthdayDate()));
                         labelGenderText.Invoke(new Action(() => labelGenderText.Text = m_Engine.GetBestFriendGender()));
                         labelBestFriendNameText.Invoke(new Action(() => labelBestFriendNameText.Text = m_Engine.GetBestFriendFullName()));
                         pictureBoxBestFriendPicture.LoadAsync(m_Engine.GetFriendPicture(bestFriendIndex));
                         setMostTaggedUserTextLabel();
                         setMostCheckInTextLabel();
                         */
                    }
                    else
                    {
                         this.Invoke(new Action(() => MessageBox.Show(k_NoExistFriendWithBirthday)));
                    }
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(Common.NoConnectionToFacebook)));
               }
               Common.s_AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature--;
          }
          /*
          private void setMostCheckInTextLabel()
          {
               const string k_NoDataAvailable = "CheckIn data is not available";
              // string bestFriendMostTopCheckIn = m_Engine.getBestFriendTopCheckIn();

               if (bestFriendMostTopCheckIn != null)
               {
                    labelMostTaggedCheckinText.Invoke(new Action(() => labelMostTaggedCheckinText.Text = bestFriendMostTopCheckIn));
               }
               else
               {
                    labelMostTaggedCheckinText.Invoke(new Action(() => labelMostTaggedCheckinText.Text = k_NoDataAvailable));
               }
          }

          private void setMostTaggedUserTextLabel()
          {
               const string k_NoDataAvailable = "No tags available";
               string bestFriendMostTaggedUser = m_Engine.getBestFriendTopTag();

               if (bestFriendMostTaggedUser != null)
               {
                    labelMostTaggedUserText.Invoke(new Action(() => labelMostTaggedUserText.Text = bestFriendMostTaggedUser));
               }
               else
               {
                    labelMostTaggedUserText.Invoke(new Action(() => labelMostTaggedUserText.Text = k_NoDataAvailable));
               }
          }
          */
          private void buttonCreateBirthdayEvent_Click(object sender, EventArgs e)
          {
               if (Common.s_AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature == 0)
               {
                    Common.s_AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature++;
                    Common.s_CurrentCalculationSortingFriendsFeature = "Create Event";
                    new Thread(createEvent).Start(); ;
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show($"{ Common.s_CurrentCalculationFindBestFriendFeature} calculation is still alive")));
               }
          }

          private void createEvent()
          {
               const string k_BestFriendDidntFetchMessage = "First you need to find your best friend";
               if (m_Engine.UserConnected())
               {
                    if (m_Engine.IsBestFriendExist())
                    {
                         createBirthdayEvent();
                    }
                    else
                    {
                         this.Invoke(new Action(() => MessageBox.Show(k_BestFriendDidntFetchMessage)));
                    }
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show(Common.NoConnectionToFacebook)));
               }
               Common.s_AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature--;
          }

          private void createBirthdayEvent()
          {
               const string k_EventCreatedMessage = "suprise party event should be created. the feature blocked from version 2.0";
               if (checkLegalityBirthdayEvent())
               {
                    string description = null;
                    string location = null;
                    textBoxDescirption.Invoke(new Action(() => description = textBoxDescirption.Text));
                    textBoxLocation.Invoke(new Action(() => location = textBoxLocation.Text));
                    m_Engine.CreateEvent(description, location);
                    textBoxDescirption.Invoke(new Action(() => textBoxDescirption.Text = string.Empty));
                    textBoxLocation.Invoke(new Action(() => textBoxLocation.Text = string.Empty));
                    MessageBox.Show(k_EventCreatedMessage);
               }
          }

          private bool checkLegalityBirthdayEvent()
          {
               const string k_EmptyDescriptionError = "The description can't be empty", k_EmptyLocationError = "The location can't be empty";
               bool legalInput = true;
               string location = null;
               string description = null;
               textBoxDescirption.Invoke(new Action(() => description = textBoxDescirption.Text));
               textBoxDescirption.Invoke(new Action(() => location = textBoxLocation.Text));
               if (string.IsNullOrEmpty(description))
               {
                    legalInput = false;
                    MessageBox.Show(k_EmptyDescriptionError);
               }
               else if (string.IsNullOrEmpty(description))
               {
                    legalInput = false;
                    MessageBox.Show(k_EmptyLocationError);
               }

               return legalInput;
          }
     }
}
