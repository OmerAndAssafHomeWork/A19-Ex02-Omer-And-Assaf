using System;
using System.Windows.Forms;
using System.Threading;
using FacebookFeatures_Engine;

namespace FacebookFeatures_UI
{
     public partial class FindBestFriendControl : UserControl
     {
          private const int k_InitialValue = -1, k_BestFriendNotFoundIndex = -1;
          private IManager m_EngineManager;

          public FindBestFriendControl()
          {
               InitializeComponent();
               m_EngineManager = ManagerProxy.GetEngineManager();
          }

          private void disableSecondFeatureControls()
          {
               Common.SetVisibilityControls(
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
               if (Common.AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature == 0)
               {
                    Common.AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature++;
                    Common.CurrentCalculationFindBestFriendFeature = "Find Best Friend";
                    new Thread(findBestFriend).Start();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show($"{ Common.CurrentCalculationFindBestFriendFeature} calculation is still alive")));
               }
          }

          private void findBestFriend()
          {
               const string k_NoExistFriendWithBirthday = "You don't have friends who have birthday in four months";

               if (m_EngineManager.UserConnected())
               {
                m_EngineManager.SetBirthdayInRangeMethod(birthdayDate =>(birthdayDate - DateTime.Now).TotalDays <= 120);
                FacebookUser bestFriend = m_EngineManager.FindBestFriend();
                    if (bestFriend != null)
                    {
                         facebookUserBindingSource.DataSource = bestFriend;
                         Common.SetVisibilityControls(true, labelMostCommonCheckin, labelMostTaggedUser, labelFullName, labelBirthdayDate, labelGender, labelAlbums, labelAmountOfAlbumsText, labelGenderText, labelNameText, pictureLargeURLPictureBox, labelBirthdayText, labelMostTaggedUserText, labelMostCommonCheckinText);
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

               Common.AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature--;
          }

          private void buttonCreateBirthdayEvent_Click(object sender, EventArgs e)
          {
               if (Common.AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature == 0)
               {
                    Common.AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature++;
                    Common.CurrentCalculationFindBestFriendFeature = "Create Event";
                    new Thread(createEvent).Start();
               }
               else
               {
                    this.Invoke(new Action(() => MessageBox.Show($"{ Common.CurrentCalculationFindBestFriendFeature} calculation is still alive")));
               }
          }

          private void createEvent()
          {
               const string k_BestFriendDidntFetchMessage = "First you need to find your best friend";
               if (m_EngineManager.UserConnected())
               {
                    if (m_EngineManager.IsBestFriendExist())
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

               Common.AmountOfAntoherThanMainThreadAliveThreadsFindBestFriendFeature--;
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
                    m_EngineManager.CreateEvent(description, location);
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
               else if (string.IsNullOrEmpty(location))
               {
                    legalInput = false;
                    MessageBox.Show(k_EmptyLocationError);
               }

               return legalInput;
          }
     }
}
