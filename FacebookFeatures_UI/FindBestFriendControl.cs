using System;
using System.Windows.Forms;
using FacebookFeatures_Engine;
using System.Threading;

namespace SotringFriends_UI
{
     public partial class FindBestFriendControl : UserControl
     {
          private const int k_InitialValue = -1, k_BestFriendNotFoundIndex = -1;
          private FeaturesEngine m_FeaturesEngine = null;

          public FindBestFriendControl(FeaturesEngine i_FeaturesEngine)
          {
               InitializeComponent();
               m_FeaturesEngine = i_FeaturesEngine;
          }

          private void disableSecondFeatureControls()
          {
               setVisibilityControls(
                    false,
                    labelFullName,
                    labelBirthdayDate,
                    labelGender,
                    labelMostTaggedUser,
                    labelMostCommonCheckin,
                    labelAlbums,
                    labelBestFriendNameText,
                    labelBirthdayDateText,
                    labelGenderText,
                    labelMostTaggedUserText,
                    labelMostTaggedCheckinText,
                    labelAlbumsText,
                    pictureBoxBestFriendPicture);
               labelBestFriendNameText.Text = string.Empty;
               labelBirthdayDateText.Text = string.Empty;
               labelGenderText.Text = string.Empty;
               labelMostTaggedUserText.Text = string.Empty;
               labelMostTaggedCheckinText.Text = string.Empty;
               labelAlbumsText.Text = string.Empty;
          }

          private void disableWholeControls()
          {
               disableSecondFeatureControls();
          }

          private void setVisibilityControls(bool i_Visiblity, params Control[] i_ControlsList)
          {
               foreach (Control currentControl in i_ControlsList)
               {
                    currentControl.Invoke(new Action(() => currentControl.Visible = i_Visiblity));
               }
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

               if (m_FeaturesEngine.UserConnected())
               {
                    int bestFriendIndex = m_FeaturesEngine.FindBestFriend();

                    if (bestFriendIndex != k_BestFriendNotFoundIndex)
                    {
                         setVisibilityControls(true, labelMostCommonCheckin, labelMostTaggedUser, labelFullName, labelBirthdayDate, labelGender, labelAlbums, labelAlbumsText, labelGenderText, labelBestFriendNameText, pictureBoxBestFriendPicture, labelBirthdayDateText, labelMostTaggedUserText, labelMostTaggedCheckinText);
                         labelAlbumsText.Invoke(new Action(() => labelAlbumsText.Text = m_FeaturesEngine.GetBestFriendAmountOfAlbums().ToString()));
                         labelGenderText.Invoke(new Action(() => labelGenderText.Text = m_FeaturesEngine.GetBestFriendGender()));
                         labelBestFriendNameText.Invoke(new Action(() => labelBestFriendNameText.Text = m_FeaturesEngine.GetBestFriendFullName()));
                         pictureBoxBestFriendPicture.LoadAsync(m_FeaturesEngine.GetFriendPicture(bestFriendIndex));
                         setMostTaggedUserTextLabel();
                         setMostCheckInTextLabel();
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

          private void setMostCheckInTextLabel()
          {
               const string k_NoDataAvailable = "CheckIn data is not available";
               string bestFriendMostTopCheckIn = m_FeaturesEngine.GetBestFriendTopCheckIn();

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
               string bestFriendMostTaggedUser = m_FeaturesEngine.GetBestFriendTopTag();

               if (bestFriendMostTaggedUser != null)
               {
                    labelMostTaggedUserText.Invoke(new Action(() => labelMostTaggedUserText.Text = bestFriendMostTaggedUser));
               }
               else
               {
                    labelMostTaggedUserText.Invoke(new Action(() => labelMostTaggedUserText.Text = k_NoDataAvailable));
               }
          }

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
               if (m_FeaturesEngine.UserConnected())
               {
                    if (m_FeaturesEngine.IsBestFriendExist())
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
                    m_FeaturesEngine.CreateEvent(description, location);
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
